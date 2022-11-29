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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "serviceAboutTaxiDataSet.Drivers". При необходимости она может быть перемещена или удалена.
            this.driversTableAdapter.Fill(this.serviceAboutTaxiDataSet.Drivers);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDriverForm addDriverForm= new AddDriverForm();
            addDriverForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string deleteSqlLine = @"DELETE FROM Drivers WHERE DriverID=@id";
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(
                            deleteSqlLine, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Запись была успешно удалена", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string fillSqlLine = "SELECT * FROM Drivers";
                        SqlConnection sqlconn = new SqlConnection(Constants.ConnectionString);
                        sqlconn.Open();
                        SqlDataAdapter oda = new SqlDataAdapter(fillSqlLine, sqlconn);
                        DataTable dt = new DataTable();
                        oda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        sqlconn.Close();


                        connection.Close();
                    }
                }
            }
        }
    }
}
