using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ServiceAboutTaxi
{
    public partial class UserForm : Form
    {
        private int clientID = -1;
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "serviceAboutTaxiDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.serviceAboutTaxiDataSet.Orders);
            clientID = findingClientID();
        }

        // ДОРОБЛЕННЯ
        // Видалення заказу (відмова від заказу, тільки якщо заказ ще не почався)
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string cId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string deleteSqlOrdersLine = @"DELETE FROM Orders WHERE OrderID=@id";

                    using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(
                            deleteSqlOrdersLine, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("id", cId);
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Запись была успешно удалена", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string fillSqlLine = "SELECT * FROM Orders WHERE ClientID='" + clientID.ToString() + "'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            UserFormAdding userFormAdding = new UserFormAdding();
            userFormAdding.ShowDialog();
        }

        private void UserForm_Activated(object sender, EventArgs e)
        {
            string fillSqlLine = "SELECT * FROM Orders WHERE ClientID='" + clientID.ToString() + "'";
            SqlConnection sqlconn = new SqlConnection(Constants.ConnectionString);
            sqlconn.Open();

            SqlDataAdapter oda = new SqlDataAdapter(fillSqlLine, sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlconn.Close();
        }

        private int findingClientID()
        {
            int clientID = -1;
            // Знаходження клієнтського ід
            string findingClientID = @"SELECT ClientID FROM Clients WHERE UserID=@id;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingClientID, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", Constants.CurrentUserID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            clientID = (int)reader1["ClientID"];
                        }
                    }

                    reader1.Close();
                }
            }

            return clientID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClietnCurrentOrder clietnCurrentOrder = new ClietnCurrentOrder(clientID);
            clietnCurrentOrder.ShowDialog();
        }
    }
}
