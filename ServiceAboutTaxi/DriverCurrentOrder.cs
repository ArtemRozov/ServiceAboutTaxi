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
    public partial class DriverCurrentOrder : Form
    {
        private int carID = -1;
        private int clientID = -1;
        public DriverCurrentOrder(int carID)
        {
            InitializeComponent();
            this.carID = carID;
        }

        private void DriverCurrentOrder_Load(object sender, EventArgs e)
        {
            clientID = findingClientID();
            if(clientID > 0)
            {
                fillLabels();
                fillClientsLabels();
            }
            else
            {
                MessageBox.Show("У вас немає поточних заказів", "Поточний заказ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
                       
        }

        private int findingClientID()
        {
            int clientID = -1;
            //Finding carID of this driver
            string findingClientID = @"SELECT clientID FROM Orders WHERE CarID=@id AND OrderState=0;";

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
                            clientID = (int)reader1["ClientID"];
                        }
                    }

                    reader1.Close();
                }
            }

            return clientID;
        }
        private void fillLabels()
        {
            string sqlQuery = @"SELECT StartAddres, EndAddres, CarDeliveryTime FROM Orders WHERE CarID=@id AND OrderState=0;";

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
                            FirstAdressLabel.Text = reader1["StartAddres"].ToString();
                            LastAdressLabel.Text = reader1["EndAddres"].ToString();
                            TimeLabel.Text = reader1["CarDeliveryTime"].ToString();
                        }
                    }

                    reader1.Close();
                }
            }
        }
        private void fillClientsLabels()
        {
            string sqlQuery = @"SELECT PhoneNumber, Name FROM Clients WHERE ClientID=@id;";

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
                            ClientPhoneLabel.Text = reader1["PhoneNumber"].ToString();
                            ClientNameLabel.Text = reader1["Name"].ToString();
                        }
                    }

                    reader1.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що хочете завершити заказ?",
                "Завершення заказу", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string updateDriver = @"UPDATE Orders SET OrderState=1 WHERE CarID=@id AND OrderState=0";
                using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(
                    updateDriver, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("id", carID);
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Замовлення успішно завершено!", "Поточне замовлення",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
