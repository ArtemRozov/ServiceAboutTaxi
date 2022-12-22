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
    public partial class UserFormAdding : Form
    {
        public UserFormAdding()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrdersTableAdapter ordersTableAdapter = new OrdersTableAdapter();
            int orderID = 1;
            string findingUserID = "SELECT OrderID FROM Orders";
            using (SqlConnection connection = new SqlConnection(
                Constants.ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    findingUserID, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (true) //reader.Read()
                    {
                        if (checkUniqueUserID(orderID))
                        {
                            break;
                        }
                        orderID++;
                    }
                }

                command.Dispose();
                connection.Close();
            }

            //Знаходимо clientID за допомогою Constants.UserID
            int clientID = -1;
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

                //Знаходимо найкращого вільного водія
                int bestDriverID = -1;
                int maxRate = -1;
                string findingDriverID = "SELECT DriverID, Rating FROM Drivers WHERE Freedom='1';";

                using (SqlConnection connection = new SqlConnection(
                            Constants.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(
                        findingDriverID, connection);
                    connection.Open();

                    using (SqlDataReader reader1 = command.ExecuteReader())
                    {
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                if ((int)reader1["Rating"] > maxRate)
                                {
                                    maxRate = (int)reader1["Rating"];
                                    bestDriverID = (int)reader1["DriverID"];
                                }                                
                            }
                        }

                        reader1.Close();
                    }
                    command.Dispose();
                    connection.Close();
                }

                //Знаходимо CarID найкращого водія
                int carID = -1;
                string findingCarID = @"SELECT CarID FROM Cars WHERE DriverID=2;";

                using (SqlConnection connection = new SqlConnection(
                            Constants.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(
                        findingCarID, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("id", bestDriverID);

                    using (SqlDataReader reader1 = command.ExecuteReader())
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
                    command.Dispose();
                    connection.Close();
                }

                // Додавання заказу
                if (clientID >= 0)
                {
                    // Створення заказу у БД
                    Random rnd = new Random();
                    ordersTableAdapter.Insert
                    (
                        orderID,
                        FirstAddressTextBox.Text,
                        EndAddressTextBox.Text,
                        rnd.Next(100, 200),
                        0,
                        DateTime.Now,
                        DateTime.Now, //Change it (додати 5 хвилин від часу заказу авто)
                        DateTime.Now, //Change it too (рандомно додаємо час, щоб зрозуміти коли приїдемо)
                        DateTime.Parse(CarDeliveryTimeTextBox.Text),
                        int.Parse(PassengersCountTextBox.Text),
                        carID, //Change it to carId in some way (automatization task)
                        clientID 
                     );

                    MessageBox.Show("Запись была успешно добавлена", "Добавление записи",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                connection1.Close();
            }
            
            Close();
        }

        private bool checkUniqueUserID(int orderID)
        {
            string selectedOrderID = "SELECT OrderID FROM Orders";
            using (SqlConnection connection = new SqlConnection(
               Constants.ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    selectedOrderID, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == orderID.ToString())
                        {
                            return false;
                        }
                    }
                }
                connection.Close();
            }

            return true;
        }
    }
}
