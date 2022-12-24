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
    public partial class ClietnCurrentOrder : Form
    {
        private int clientID = -1;
        public ClietnCurrentOrder(int clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
        }

        private void ClietnCurrentOrder_Load(object sender, EventArgs e)
        {
            int carID = findingCarID();
            if(carID > 0)
            {
                int driverID = findingDriverID(carID);

                fillLabels(carID);
                fillClientsLabels(carID);
                fillDriversLabels(driverID);
            }
            else
            {
                MessageBox.Show("У вас немає поточних заказів", "Поточний заказ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }            
        }

        private int findingCarID()
        {
            int carID = -1;
            //Finding carID of this driver
            string findingClientID = @"SELECT CarID FROM Orders WHERE ClientID=@id AND OrderState=0;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingClientID, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", clientID);

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

            return carID;
        }
        private int findingDriverID(int carID)
        {
            int driverID = -1;
            //Finding carID of this driver
            string findingClientID = @"SELECT DriverID FROM Cars WHERE CarID=@id;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingClientID, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", carID);

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

            return driverID;
        }

        private void fillLabels(int carID)
        {
            string sqlQuery = @"SELECT StartAddres, EndAddres, CarDeliveryTime, Price FROM Orders WHERE ClientID=@id AND OrderState=0;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    sqlQuery, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", clientID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            StartAdressLabel.Text = reader1["StartAddres"].ToString();
                            EndAdressLabel.Text = reader1["EndAddres"].ToString();
                            TimeLabel.Text = reader1["CarDeliveryTime"].ToString();
                            PriceLabel.Text = reader1["Price"].ToString();
                        }
                    }

                    reader1.Close();
                }
            }
        }
        private void fillClientsLabels(int carID)
        {
            string sqlQuery = @"SELECT CarNumber, Brand, Model, Color FROM Cars WHERE CarID=@id;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    sqlQuery, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", carID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            BrandLabel.Text = reader1["Brand"].ToString();
                            ModelLabel.Text = reader1["Model"].ToString();
                            NomerLabel.Text = reader1["CarNumber"].ToString();
                            ColorLabel.Text = reader1["Color"].ToString(); 
                        }
                    }

                    reader1.Close();
                }
            }
        }

        private void fillDriversLabels(int driverID)
        {
            string sqlQuery = @"SELECT PhoneNumber FROM Drivers WHERE DriverID=@id;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    sqlQuery, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("id", driverID);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            PhoneLabel.Text = reader1["PhoneNumber"].ToString();
                        }
                    }

                    reader1.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
