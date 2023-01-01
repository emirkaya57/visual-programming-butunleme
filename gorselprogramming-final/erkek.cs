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

namespace gorselprogramming_final
{
    public partial class erkek : Form
    {
        public erkek()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=voleybol1.accdb");
        OleDbCommand komut = new OleDbCommand();

 
     

        private void button1_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand("insert into oyuncular (AdiSoyadi,tc,yas,telefon,takim) values ('" + adsoyad.Text + "','" + tc.Text + "','" + yas.Text + "','" + telefon.Text + "','" + takim.Text + "',  ");
           komut.Connection = baglan;
            komut.ExecuteNonQuery();
            baglan.Close();

            adsoyad.Clear();
            tc.Clear();
            yas.Clear();
            telefon.Clear();
            takim.Clear();
            baglan.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("Select * from oyuncular", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void erkek_Load(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from oyuncular", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "update oyuncular set AdiSoyadi='" + adsoyad.Text + "',takim='" + takim.Text + "',yas='" + yas.Text + "' where tc=" + tc.Text + "";
            komut.ExecuteNonQuery();
           

            OleDbDataAdapter da = new OleDbDataAdapter("Select * from oyuncular", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "delete from oyuncular where tc=" + tc.Text + "";
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            kadin uyg = new kadin();
            uyg.ShowDialog();
        }

        private void  dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                dataGridView1.CurrentRow.Selected = true;
                adsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells["AdiSoyadi"].FormattedValue.ToString();
                tc.Text = dataGridView1.Rows[e.RowIndex].Cells["tc"].FormattedValue.ToString();
                yas.Text = dataGridView1.Rows[e.RowIndex].Cells["yas"].FormattedValue.ToString();
                telefon.Text = dataGridView1.Rows[e.RowIndex].Cells["telefon"].FormattedValue.ToString();
                takim.Text = dataGridView1.Rows[e.RowIndex].Cells["takim"].FormattedValue.ToString();

        }
    }
}
