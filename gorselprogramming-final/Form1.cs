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

namespace gorselprogramming_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int ks;
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=voleybol1.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT COUNT(*) FROM kullanici where uyeadi=@uyeadi and uyesifre=@uyesifre", baglan);
            komut.Parameters.Add("@uyeadi", textBox1.Text);
            komut.Parameters.Add("@uyesifre", textBox2.Text);
            ks = int.Parse(komut.ExecuteScalar().ToString());

            if (ks == 1)
            {
                this.Hide();
                erkek uyg = new erkek();
                uyg.ShowDialog();
            }
            else
                MessageBox.Show("Giriş Başarısız");
            baglan.Close();

        }
    }
}
