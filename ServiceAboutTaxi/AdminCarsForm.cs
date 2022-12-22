using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceAboutTaxi
{
    public partial class AdminCarsForm : Form
    {
        public AdminCarsForm()
        {
            InitializeComponent();
        }

        private void AdminCarsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "serviceAboutTaxiDataSet.Cars". При необходимости она может быть перемещена или удалена.
            this.carsTableAdapter.Fill(this.serviceAboutTaxiDataSet.Cars);

        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            AdminClientForm adminClientForm = new AdminClientForm();
            adminClientForm.Show();
            Close();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            Close();
        }

        private void AddCar_Click(object sender, EventArgs e)
        {
            AddCarForm addCarForm = new AddCarForm();
            addCarForm.ShowDialog();
        }

        private void AdminCarsForm_Activated(object sender, EventArgs e)
        {
            string fillSqlLine = "SELECT * FROM Cars";
            SqlConnection sqlconn = new SqlConnection(Constants.ConnectionString);
            sqlconn.Open();
            SqlDataAdapter oda = new SqlDataAdapter(fillSqlLine, sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string cId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string deleteSqlCarsLine = @"DELETE FROM Cars WHERE CarID=@id";

                    using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(
                            deleteSqlCarsLine, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("id", cId);
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Запись была успешно удалена", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string fillSqlLine = "SELECT * FROM Cars";
                        SqlConnection sqlconn = new SqlConnection(Constants.ConnectionString);
                        sqlconn.Open();
                        SqlDataAdapter oda = new SqlDataAdapter(fillSqlLine, sqlconn);
                        DataTable dt = new DataTable();
                        oda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        sqlconn.Close();
                    }
                }
            }
        }

        private void AdminCarsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            carsTableAdapter.Update(serviceAboutTaxiDataSet);
        }
    }
}
