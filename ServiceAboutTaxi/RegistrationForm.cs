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
    public partial class RegistrationForm : Form
    {
        private bool isSeenPsw;
        private bool isVisible;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isSeenPsw)
            {
                isSeenPsw = false;
            }
            else
            {
                isSeenPsw = true;
            }
            PasswordTextBox.UseSystemPasswordChar = !isSeenPsw;
            RepeatPasswordTextBox.UseSystemPasswordChar = !isSeenPsw;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isVisible = false;
            string selectedLogin = "SELECT Login FROM Users";
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
                        if (reader[0].ToString() == LoginTextBox.Text)
                        {
                            isVisible = true;
                            break;
                        }
                    }
                    LoginErrorLabel.Visible = isVisible;
                }
                connection.Close();
            }
            
            if (PasswordTextBox.Text.Length < 8 && !isVisible)
            {
                PasswordLengthErrorLabel.Visible = true;
            }
            else if(PasswordTextBox.Text != RepeatPasswordTextBox.Text)
            {
                PasswordLengthErrorLabel.Visible = false;
                PasswordsErrorLabel.Visible = true;
            }
            else
            {
                PasswordLengthErrorLabel.Visible = false;
                PasswordsErrorLabel.Visible = false;
                UsersTableAdapter usersTableAdapter= new UsersTableAdapter();

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
                        LoginErrorLabel.Visible = isVisible;
                    }
                    connection.Close();
                }

                usersTableAdapter.Insert(userID, LoginTextBox.Text,
                    PasswordTextBox.Text, "Користувач");
                Close();
            }            
        }
    }
}
