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
using System.Data.OleDb;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace gorselprogramming_final
{
    public partial class kadin : Form
    {
        MySql.Data.MySqlClient.MySqlConnection baglan;
        public kadin()
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





        private void button1_Click(object sender, EventArgs e)
        {
            kadinkayit git = new kadinkayit();
            git.Show();
            this.Close();


        }


        private void button3_Click(object sender, EventArgs e)
        {
            string baslk = "1";
            MySqlCommand cmd = new MySqlCommand("SELECT*FROM tbl_oyuncu WHERE takim_id='" + baslk + "'", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[1] + "      " + dr[2]);

            }
            dr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            erkek git = new erkek();
            git.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string baslk = "2";
            MySqlCommand cmd = new MySqlCommand("SELECT*FROM tbl_oyuncu WHERE takim_id='" + baslk + "'", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            cmd.CommandText = "update tbl_oyuncu set isim_soyisim='" + adsoyad.Text + "',takim_id='" + tc.Text + "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string baslk = "2";
            MySqlCommand cmd = new MySqlCommand("SELECT*FROM tbl_oyuncu WHERE takim_id='" + baslk + "'", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            cmd.CommandText = "delete from tbl_oyuncu where isim_soyisim=" + adsoyad.Text + "";
        }
    }
}
