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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gorselprogramming_final
{
    public partial class kayıtekle : Form
    {
        MySql.Data.MySqlClient.MySqlConnection baglan;
        public kayıtekle()
        {
            InitializeComponent();
        }

        private void kayıtekle_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Alan bırakmayınız ");
            }




            else
            {
                baglan = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db_voleybol");

                baglan.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbl_oyuncu(isim_soyisim, aciklama,takim_id ) values(@isim_soyisim, @aciklama,@takim_id)", baglan);
                cmd.Parameters.AddWithValue("@isim_soyisim", textBox1.Text);
                cmd.Parameters.AddWithValue("@takim_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@aciklama", listBox1.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Kaydınız Başarıyla Oluşturuldu", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                erkek git = new erkek();
                git.Show();
                this.Hide();


            }
        }

        
    }
}
