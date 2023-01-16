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

namespace gorselprogramming_final
{
    public partial class üyeol : Form
    {
        MySql.Data.MySqlClient.MySqlConnection baglan;
        public üyeol()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Alan bırakmayınız ");
            }




            else
            {
                baglan = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db_voleybol");

                baglan.Open();
                MySqlCommand cmd = new MySqlCommand("insert into kullanicilar(username, password ) values(@username, @password)", baglan);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Kaydınız Başarıyla Oluşturuldu", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                

                Form1 git =new Form1();
                git.Show();
                this.Hide();


            }
        }
    }
}
