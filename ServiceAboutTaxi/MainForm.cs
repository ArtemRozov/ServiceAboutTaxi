using ServiceAboutTaxi.ServiceAboutTaxiDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ServiceAboutTaxi
{
    public partial class MainForm : Form
    {
        private bool isFind;
        private bool isSeenPsw;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedLogin = "SELECT Login, Psw, Role FROM Users";
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
                            if (reader[1].ToString() == PasswordTextBox.Text)
                            {
                                if (reader[2].ToString() == "Системний адміністратор")
                                {
                                    // Обнуляємо юзерІД в константах, коли аккаунт не юзера
                                    Constants.CurrentUserID = 0;

                                    AdminForm adminForm = new AdminForm();
                                    adminForm.Show();
                                    isFind = true;
                                    InvalidLoginLabel.Visible = false;
                                } else if(reader[2].ToString() == "Водій")
                                {
                                    // Знаходимо юзерІД, та закидуємо в Констант клас,
                                    // щоб розуміти, хто це в нас зайшов.
                                    findUserID(reader[0]);

                                    //Вмикаємо наступну форму
                                    DriverForm driverForm = new DriverForm();
                                    driverForm.Show();
                                    isFind = true;
                                    InvalidLoginLabel.Visible = false;
                                } else if (reader[2].ToString() == "Користувач")
                                {
                                    // Знаходимо юзерІД, та закидуємо в Констант клас,
                                    // щоб розуміти, хто це в нас зайшов.
                                    findUserID(reader[0]);

                                    UserForm userForm = new UserForm();
                                    userForm.Show();
                                    isFind = true;
                                    InvalidLoginLabel.Visible = false;
                                } else
                                {
                                    isFind = false;
                                }
                            }
                        }
                    }
                    if (!InvalidLoginLabel.Visible && !isFind)
                    {
                        InvalidLoginLabel.Visible = true;
                    }
                }
                connection.Close();
            }
        }

        private void findUserID(object value)
        {
            int userID = -1;
            string findingDriverID = @"SELECT UserID FROM Users WHERE Login=@log;";

            using (SqlConnection connection1 = new SqlConnection(
                        Constants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    findingDriverID, connection1);
                connection1.Open();
                cmd.Parameters.AddWithValue("log", value);

                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            userID = (int)reader1["UserID"];
                        }
                    }

                    reader1.Close();
                }

                if (userID >= 0)
                {
                    Constants.CurrentUserID = userID;
                }

                connection1.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Teal;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.SkyBlue;
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(isSeenPsw)
            {
                isSeenPsw = false;
            }
            else
            {                            
                isSeenPsw = true;
            }
            PasswordTextBox.UseSystemPasswordChar = !isSeenPsw;
        }
    }
}
