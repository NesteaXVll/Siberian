using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Siberian
{
    public partial class Form4 : Form
    {
        DataBase dataBase = new DataBase();
        public Form4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            var FIO = textBox1.Text;
            var number_phone = textBox2.Text;
            
            string querystring = $"insert into Постояльцы(ФИО, [Контактный номер]) values('{FIO}', '{number_phone}')";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            var s = textBox4.Text;
            var po = textBox5.Text;
            var number = textBox3.Text;
            string id_klienta = "";
            string id_nomera = "";

            string querystring2 = $"select [ID номера] from Номера where [№ номера] = '{number}'";
            SqlCommand command2 = new SqlCommand(querystring2, dataBase.getConnection()); // ЭТОТ НАДО СДЕЛАТЬ

            string querystring3 = $"select [ID постояльца] from Постояльцы where ФИО = '{FIO}'";
            SqlCommand command3 = new SqlCommand(querystring3, dataBase.getConnection()); // ЭТОТ

           

            dataBase.openConnection();
            command.ExecuteNonQuery();
            //dataBase.closeConnection();

            

            try
            {
                DataSet ss = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command2;
                adapter.Fill(ss);
                id_nomera = ss.Tables[0].Rows[0]["ID номера"].ToString();
            }
            catch (Exception ex)
            {

            }
            //MessageBox.Show(id_nomera);

            
            try
            {
                DataSet ss1 = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter();
                adapter1.SelectCommand = command3;
                adapter1.Fill(ss1);
                id_klienta = ss1.Tables[0].Rows[0]["ID постояльца"].ToString();
            }
            catch (Exception ex)
            {

            }
            //MessageBox.Show(id_klienta);

            string querystring4 = $"insert into Бронирование ([ID постояльца], [ID номера], [Дата начала], [Дата окончания]) values('{id_klienta}', '{id_nomera}', '{s}', '{po}')";
            SqlCommand command4 = new SqlCommand(querystring4, dataBase.getConnection()); // И ВОТ ЭТОТ ИСХОДЯ ИЗ 1 и 2
            command4.ExecuteNonQuery();
        }
    }
}
