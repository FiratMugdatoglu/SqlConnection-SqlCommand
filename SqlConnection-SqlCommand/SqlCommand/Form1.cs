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

namespace SqlCommand_Lesson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-2M7U78F\\SQLEXPRESS;Database=Library;Trusted_connection=True;");

            string insertSql = "Insert into Member Values (@tc,@namesurname,@age,@gender,@phonenumber,@address,@email,@numberofbooksread)";
            SqlCommand command = new SqlCommand(insertSql,connection);
            command.Parameters.AddWithValue("tc","26");
            command.Parameters.AddWithValue("namesurname", "Ahmet Bayık");
            command.Parameters.AddWithValue("age", "26");
            command.Parameters.AddWithValue("gender", "Erkek");
            command.Parameters.AddWithValue("phonenumber", "123123");
            command.Parameters.AddWithValue("address", "sadsdasd");
            command.Parameters.AddWithValue("email", "ahmetbayık@gmail.com");
            command.Parameters.AddWithValue("numberofbooksread", "");
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-2M7U78F\\SQLEXPRESS;Database=Library;Trusted_connection=True;");
   
          
            string selectSql = "Select * from Member ";
            string selectWhereClause = "where tc like '%' + @tc + '%'";
            SqlCommand command = new SqlCommand();//SqlCommand bizim veritabanı üzerinde yapmak istediğimiz işlemlerin ADO tarafında belirtilmesini sağlayan sınıftır.
            command.Connection = connection;
            
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                selectSql += selectWhereClause;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("tc",textBox1.Text);
            }
            command.CommandText = selectSql;
            DataTable table = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            connection.Close();
            dataGridView1.DataSource = table;
        }
    }
}
