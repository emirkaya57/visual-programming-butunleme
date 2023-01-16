using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace gorselprogramming_final
{
    public partial class Form1 : Form
    {MySql.Data.MySqlClient.MySqlConnection baglan;
        public Form1()
        {
            InitializeComponent();
            try
            {

                baglan = new MySql.Data.MySqlClient.MySqlConnection("server=localhost; uid=root;pwd=; database=db_voleybol");
                baglan.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException hata)
            {
                MessageBox.Show(hata.Message);

            }
        }

        bool kontrol;
        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = textBox1.Text;
            string sifre = textBox2.Text;

            if (textBox1.Text == "Kullanıcı adı" || textBox2.Text == "Şifre")
            {
                MessageBox.Show("boş bırakmayınız");
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand("SELECT*FROM kullanicilar", baglan);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (kullanici == dr["username"].ToString().TrimEnd() && sifre == dr["password"].ToString().TrimEnd())
                    {

                        kontrol = true;
                        break;

                    }
                    else
                    {
                        kontrol = false;
                    }
                }
                dr.Close();

                if (kontrol)
                {
                    erkek nn = new erkek();
                    nn.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("kullanıcı adı veya şifre hatalı");
                }


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            üyeol git = new üyeol();
            git.Show(Owner);
            this.Hide();
        }
    }

        }
    

