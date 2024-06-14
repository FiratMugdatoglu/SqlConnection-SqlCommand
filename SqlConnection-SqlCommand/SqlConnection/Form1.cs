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

namespace SqlConnection_Lesson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-2M7U78F\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");//Veritabanına bağlandık
            //connection.ConnectionString = "";
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Member",connection);//Veri tabanından verileri aldık.
            DataTable table = new DataTable();//Veritabanından aldığımız veriler için tablo oluşturduk.
            adapter.Fill(table);//Veri tabanından aldığımız verileri oluşturduğumuz tabloya doldurduk.
            dataGridView1.DataSource= table;//doldurduğumuz tabloyu dataGridView1 aktardık.
            //connection.Open();//DataAdapter için open ve close kullanmamıza gerek yok.
            //label1.Text = connection.State.ToString();
            //connection.Close();
            //label2.Text = connection.State.ToString();
        }
    }
}
