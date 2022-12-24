using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceAboutTaxi
{
    public partial class AdminPriceForm : Form
    {
        public AdminPriceForm()
        {
            InitializeComponent();
        }

        private void AdminPriceForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "serviceAboutTaxiDataSet.Prices". При необходимости она может быть перемещена или удалена.
            this.pricesTableAdapter.Fill(this.serviceAboutTaxiDataSet.Prices);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "serviceAboutTaxiDataSet.Prices". При необходимости она может быть перемещена или удалена.
            this.pricesTableAdapter.Fill(this.serviceAboutTaxiDataSet.Prices);

        }

        private void AdminPriceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pricesTableAdapter.Update(serviceAboutTaxiDataSet);
        }
    }
}
