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

namespace Siberian
{
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select * from Сотрудники where Логин = '{loginUser}' and Пароль = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                Form3 form3 = new Form3();
                form3.Owner = this;
                form3.ShowDialog();
            }

            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(pictureBox3.Visible == true)
            {
                textBox2.PasswordChar = '•';
            }
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            textBox2.PasswordChar = '\0';
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            textBox2.PasswordChar = '•';
            pictureBox5.Visible = true;
        }
    }
}
