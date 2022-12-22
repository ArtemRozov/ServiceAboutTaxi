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
    public partial class ReportDriverForm : Form
    {
        public ReportDriverForm()
        {
            InitializeComponent();
        }

        private void ReportDriverForm_Load(object sender, EventArgs e)
        {
            string fillSqlLine = "SELECT SNP, Brand, Model, COUNT(Orders.CarID), SUM(Price) FROM Drivers, Orders, Cars WHERE Orders.CarId = Cars.CarID AND Cars.DriverID = Drivers.DriverID GROUP BY SNP, Brand, Model;";
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
