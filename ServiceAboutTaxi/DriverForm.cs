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
    public partial class DriverForm : Form
    {
        private int carID = -1;
        private int driverID = -1;
        public DriverForm()
        {
            InitializeComponent();
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "serviceAboutTaxiDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.serviceAboutTaxiDataSet.Orders);

            // finding driverID of this user(from Constatnts class)
            string findingDriverID = @"SELECT DriverID FROM Drivers WHERE UserID=@id;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingDriverID, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", Constants.CurrentUserID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            driverID = (int)reader1["DriverID"];
                        }
                    }

                    reader1.Close();
                }
            }

            //Finding carID of this driver
            string findingCarID = @"SELECT CarID FROM Cars WHERE DriverID=@id;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingCarID, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", driverID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            carID = (int)reader1["CarID"];
                        }
                    }

                    reader1.Close();
                }
            }

            //Виставляємо чек бокс про вільність
            string findingCheckBox = @"SELECT Freedom FROM Drivers WHERE DriverID=@id;";
            bool state = false;

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingCheckBox, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", driverID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            state = (bool)reader1["Freedom"];
                        }
                    }

                    reader1.Close();
                }
            }

            checkBox1.Checked = state;
        }

        private void DriverForm_Activated(object sender, EventArgs e)
        {
            string fillSqlLine = "SELECT * FROM Orders WHERE CarID='" + carID.ToString() + "'";
            SqlConnection sqlconn = new SqlConnection(Constants.ConnectionString);
            sqlconn.Open();

            SqlDataAdapter oda = new SqlDataAdapter(fillSqlLine, sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlconn.Close();

            // Перевірка чи є в водія поточний заказ
            string findingCheckBox = @"SELECT OrderID FROM Orders WHERE CarID=@id AND OrderState=0;";
            bool state = true;

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingCheckBox, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", carID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            state = false;
                        }
                    }

                    reader1.Close();
                }
            }

            checkBox1.Enabled = state;
        }

        private void CurrentOrderButton_Click(object sender, EventArgs e)
        {
            DriverCurrentOrder driverCurrentOrder = new DriverCurrentOrder(carID);
            driverCurrentOrder.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string updateDriver = @"UPDATE Drivers SET Freedom='1' WHERE DriverID=@id";
                using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(
                    updateDriver, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("id", driverID);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                string updateDriver = @"UPDATE Drivers SET Freedom='0' WHERE DriverID=@id";
                using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(
                    updateDriver, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("id", driverID);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
