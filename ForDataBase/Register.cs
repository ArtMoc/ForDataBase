using MySql.Data.MySqlClient;
using System;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Все поля обязтательны к заполнению");
            }
            else if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("Пароли должны совпадать");
            }
            else
            {
                try
                {
                    string connStr = "Server=Localhost;Database=testbd;Uid=root;Pwd=root";
                    MySqlConnection mySqlConnection = new MySqlConnection(connStr);
                    mySqlConnection.Open();
                    string query = $"INSERT INTO users (login, pass)" +
                        $"VALUES ('{textBox1.Text}', '{textBox2.Text}')";
                    MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                    command.ExecuteNonQuery();
                    mySqlConnection.Close();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Данный логин уже занят");
                }
            }
        }
    }
}
