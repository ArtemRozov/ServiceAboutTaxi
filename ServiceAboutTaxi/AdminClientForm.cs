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
    public partial class AdminClientForm : Form
    {
        public AdminClientForm()
        {
            InitializeComponent();
        }

        private void AdminClientForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "serviceAboutTaxiDataSet.Clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.serviceAboutTaxiDataSet.Clients);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminClientForm_Activated(object sender, EventArgs e)
        {
            string fillSqlLine = "SELECT * FROM Clients";
            SqlConnection sqlconn = new SqlConnection(Constants.ConnectionString);
            sqlconn.Open();
            SqlDataAdapter oda = new SqlDataAdapter(fillSqlLine, sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string cId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string uId = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string deleteSqlDriversLine = @"DELETE FROM Clients WHERE ClientID=@id";
                    string deleteSqlUsersLine = @"DELETE FROM Users WHERE UserID=@id";

                    using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(
                            deleteSqlDriversLine, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("id", cId);
                        command.ExecuteNonQuery();
                        connection.Close();

                        SqlCommand command2 = new SqlCommand(
                            deleteSqlUsersLine, connection);
                        connection.Open();
                        command2.Parameters.AddWithValue("id", uId);
                        command2.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Запись была успешно удалена", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string fillSqlLine = "SELECT * FROM Clients";
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

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm= new AdminForm();
            adminForm.Show();
            Close();
        }
    }
}
