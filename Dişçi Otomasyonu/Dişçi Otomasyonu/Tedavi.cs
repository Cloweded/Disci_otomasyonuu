using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dişçi_Otomasyonu
{
    public partial class Tedavi : Form
    {
        

        public Tedavi()
        {
            InitializeComponent();
        }




        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Tedavidbo";
            DataSet ds = Hs.ShowHasta(query);
            tedavidata.DataSource = ds.Tables[0];

        }



        void filter()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Tedavidbo where TAd like '%" + guna2TextBox7.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            tedavidata.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            tedaviad.Text = "";
            tedaviucret.Text = "";
            tedaviacık.Text = "";

        }



        private void Tedavi_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void tedavikaydet_Click(object sender, EventArgs e)
        {
            string query = "insert into Tedavidbo values('" + tedaviad.Text + "','" + tedaviucret.Text + "','" + tedaviacık.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Tedavi Başarıyla Eklendi");
                uyeler();
                Reset();


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int key = 0;

        private void tedaviduzen_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update Tedavidbo set TAd='" +tedaviad.Text + "',TUcret='" + tedaviucret.Text + "',TAcıklama='" + tedaviacık.Text + "' where TId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi İşlemi Başarıyla Güncellendi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        
        private void tedavisil_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete  from Tedavidbo where TId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi İşlemi Başarıyla Silindi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void tedavidata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tedavidata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tedaviad.Text = tedavidata.SelectedRows[0].Cells[1].Value.ToString();
            tedaviucret.Text = tedavidata.SelectedRows[0].Cells[2].Value.ToString();
            tedaviacık.Text = tedavidata.SelectedRows[0].Cells[3].Value.ToString();

            if (tedaviad.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(tedavidata.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void tedaviara_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void tedaviyen_Click(object sender, EventArgs e)
        {
            Reset();
            uyeler();
        }

        private void tedaviad_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

    }
}
