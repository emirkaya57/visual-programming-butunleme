using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gorselprogramming_final
{
    public partial class kadin : Form
    {
        public kadin()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=voleybol1.accdb");
        OleDbCommand komut = new OleDbCommand();

        private void kadin_Load(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from kadin", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_click(object sender, EventArgs e)
        {
            komut = new OleDbCommand("insert into kadin (id,adi_soyadi,dogum_tarihi,takim,) values ('" + textBox4.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "' ");
            komut.Connection = baglan;
            komut.ExecuteNonQuery();
            baglan.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            baglan.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("Select * from kadin", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "update kadin set id='" + textBox4.Text + "',takim='" + textBox3.Text + "',dogum_tarihi='" + textBox2.Text + "' where adi_soyadi=" + textBox1.Text + "";
            komut.ExecuteNonQuery();
            baglan.Close();

            OleDbDataAdapter da = new OleDbDataAdapter("Select * from kadin", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "delete from kadin where id=" + textBox4.Text + "";
            komut.ExecuteNonQuery();
            baglan.Close();
        }
    }
}
