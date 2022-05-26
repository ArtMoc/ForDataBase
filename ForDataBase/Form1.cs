using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForDataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "Server=Localhost;Database=testbd;Uid=root;Pwd=root";
            MySqlConnection mySqlConnection = new MySqlConnection(connStr);
            mySqlConnection.Open();
            string query = $"Select * from users where login ='{textBox1.Text}'" +
                $" and pass='{textBox2.Text}'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Нет такой учетной записи");
            }
            mySqlConnection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
