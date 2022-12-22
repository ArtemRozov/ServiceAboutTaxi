using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ServiceAboutTaxi
{
    public partial class ReportDriverForm : Form
    {

        //Имя каталога открываемого файла БД
        string catName = "";
        //Непосредственное имя самого файла БД
        string fileName = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Объект документа пдф
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            
            //Создаем объект записи пдф-документа в файл
            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

            //Открываем документ
            doc.Open();

            //Определение шрифта необходимо для сохранения кириллического текста
            //Иначе мы не увидим кириллический текст
            //Если мы работаем только с англоязычными текстами, то шрифт можно не указывать
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
            PdfPTable table = new PdfPTable(dataGridView1.ColumnCount);

            //Добавим в таблицу общий заголовок
            PdfPCell cell = new PdfPCell(new Phrase("БД " + fileName + ", таблица №"));

            cell.Colspan = dataGridView1.ColumnCount;
            cell.HorizontalAlignment = 1;
            //Убираем границу первой ячейки, чтобы балы как заголовок
            cell.Border = 0;
            table.AddCell(cell);

            //Сначала добавляем заголовки таблицы
            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                cell = new PdfPCell(new Phrase(new Phrase(dataGridView1.Columns[j].Name, font)));
                //Фоновый цвет (необязательно, просто сделаем по красивее)
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }

            //Добавляем все остальные ячейки
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int k = 0; k < dataGridView1.ColumnCount; k++)
                {
                    table.AddCell(new Phrase(dataGridView1.Rows[j].Cells[k].Value.ToString(), font));
                }
            }
            //Добавляем таблицу в документ
            doc.Add(table);
            
            //Закрываем документ
            doc.Close();

            MessageBox.Show("Pdf-документ сохранен");
        }
    }
}
