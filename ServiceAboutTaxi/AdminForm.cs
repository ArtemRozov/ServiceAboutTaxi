using ServiceAboutTaxi.ServiceAboutTaxiDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
                string dId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string uId = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();

                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string deleteSqlDriversLine = @"DELETE FROM Drivers WHERE DriverID=@id";
                    string deleteSqlUsersLine = @"DELETE FROM Users WHERE UserID=@id";

                    using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(
                            deleteSqlDriversLine, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("id", dId);
                        command.ExecuteNonQuery();
                        connection.Close();

                        SqlCommand command2 = new SqlCommand(
                            deleteSqlUsersLine, connection);
                        connection.Open();
                        command2.Parameters.AddWithValue("id", uId);
                        command2.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Запись была успешно удалена", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string fillSqlLine = "SELECT * FROM Drivers";
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

        private void AdminForm_Activated(object sender, EventArgs e)
        {
            string fillSqlLine = "SELECT * FROM Drivers";
            SqlConnection sqlconn = new SqlConnection(Constants.ConnectionString);
            sqlconn.Open();
            SqlDataAdapter oda = new SqlDataAdapter(fillSqlLine, sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            AdminClientForm adminClientForm= new AdminClientForm();
            adminClientForm.Show();
            Close();
        }

        private void CarsButton_Click(object sender, EventArgs e)
        {
            AdminCarsForm adminCarsForm = new AdminCarsForm();
            adminCarsForm.Show();
            Close();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
                return;

            var values = SearchTextBox.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                foreach (string value in values)
                {
                    var row = dataGridView1.Rows[i];

                    if (row.Cells["sNPDataGridViewTextBoxColumn"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void PriceButton_Click(object sender, EventArgs e)
        {
            AdminPriceForm priceForm = new AdminPriceForm();    
            priceForm.Show();
            Close();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            driversTableAdapter.Update(serviceAboutTaxiDataSet);
        }

        private void отриматиЗвітПоЗаказахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDriverForm reportDriver = new ReportDriverForm();
            reportDriver.ShowDialog();
        }
    }
}
