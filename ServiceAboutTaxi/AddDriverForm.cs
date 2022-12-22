using ServiceAboutTaxi.ServiceAboutTaxiDataSetTableAdapters;
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
    public partial class AddDriverForm : Form
    {
        public AddDriverForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DriversTableAdapter driversTableAdapter = new DriversTableAdapter();

            int driverID = 1;
            string findingDriverID = "SELECT DriverID FROM Drivers";
            using (SqlConnection connection = new SqlConnection(
               Constants.ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    findingDriverID, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        driverID++;
                    }
                }
                connection.Close();
            }

            UsersTableAdapter usersTableAdapter = new UsersTableAdapter();

            int userID = 1;
            string findingUserID = "SELECT Login FROM Users";
            using (SqlConnection connection = new SqlConnection(
               Constants.ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    findingUserID, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userID++;
                    }
                }
                connection.Close();
            }

            usersTableAdapter.Insert(userID,
                LoginTextBox.Text,
                PswTextBox.Text,
                "Водій");

            driversTableAdapter.Insert(driverID, 
                SNPTextBox.Text, 
                DateTime.Parse(BornDateTimePicker.Text),
                PassSeriesTextBox.Text,
                PassNoTextBox.Text,
                DateTime.Parse(EmploymentDateTimePicker.Text),
                PhoneTextBox.Text,
                5,
                false,
                userID);

            MessageBox.Show("Запись была успешно добавлена", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
