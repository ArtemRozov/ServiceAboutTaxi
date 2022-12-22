using ServiceAboutTaxi.ServiceAboutTaxiDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceAboutTaxi
{
    public partial class AddCarForm : Form
    {
        public AddCarForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            CarsTableAdapter carsTableAdapter = new CarsTableAdapter();

            int carID = 1;
            string findingCarID = "SELECT CarID FROM Cars";
            using (SqlConnection connection = new SqlConnection(
               Constants.ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    findingCarID, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (checkUniqueCarID(carID))
                        {
                            break;
                        }
                        carID++;
                    }
                }
                connection.Close();
            }

            string findingDriverID = @"SELECT DriverID FROM Drivers WHERE PassNo=@passNumber;";

            using (SqlConnection connection = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    findingDriverID, connection);
                connection.Open();
                command.Parameters.AddWithValue("passNumber", PassNoTextBox.Text); 

                int driverID = -1;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                     {
                        while (reader.Read())
                        {
                            driverID = (int)reader["DriverID"];
                        }
                    }

                    reader.Close();
                }

                int priceID = 1;
                switch (CarClassComboBox.Text)
                {
                    case "Econom": priceID = 1; break;
                    case "Medium": priceID = 2;  break;
                    case "Buiseness": priceID = 3; break;
                }

                if(driverID >= 0)
                {
                    carsTableAdapter.Insert
                    (
                        carID,
                        CarNomerTextBox.Text,
                        BrandTextBox.Text,
                        ModelTextBox.Text,
                        DateTime.Parse(ManufactureYearDateTimePicker.Text),
                        ColorTextBox.Text,
                        int.Parse(TrunkSizeTextBox.Text),
                        int.Parse(PassengersCountTextBox.Text),
                        driverID,  
                        priceID
                    );

                    MessageBox.Show("Запись была успешно добавлена", "Добавление записи",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   
                
                connection.Close();               
            }
            Close();
        }
        private bool checkUniqueCarID(int carID)
        {
            string selectedLogin = "SELECT CarID FROM Cars";
            using (SqlConnection connection = new SqlConnection(
               Constants.ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    selectedLogin, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == carID.ToString())
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
