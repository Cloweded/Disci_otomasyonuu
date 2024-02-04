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

namespace Dişçi_Otomasyonu
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            fillHasta();
            fillTedavi();
        }

        ConnectionString MyCon = new ConnectionString();
        private void fillHasta()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from Personel_Hasta_Giris", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            radcb.ValueMember = "HAd";
            radcb.DataSource = dt;
            baglanti.Close();
        }

        private void fillTedavi()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TAd from Tedavidbo", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TAd", typeof(string));
            dt.Load(rdr);
            rtedavi.ValueMember = "TAd";
            rtedavi.DataSource = dt;
            baglanti.Close();
        }

        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Randevudbo";
            DataSet ds = Hs.ShowHasta(query);
            randevudata.DataSource = ds.Tables[0];

        }



        void filter()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Randevudbo where Hasta like '%" + guna2TextBox7.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            randevudata.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            radcb.Text = "";
            rtarih.Text = "";
            rsaat.Text = "";
            rtedavi.Text = "";
            
            

        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void rhad_TextChanged(object sender, EventArgs e)
        {

        }

        private void rkaydet_Click(object sender, EventArgs e)
        {
            string query = "insert into Randevudbo values('" + radcb.SelectedValue.ToString() + "','" + rtedavi.SelectedValue.ToString() + "','" + rtarih.Text.ToString() + "','" + rsaat.Text + "')";
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
        private void rdüz_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek Randevuyu Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update Randevudbo set Hasta='" + radcb.SelectedValue.ToString() + "',Tedavi='" + rtedavi.SelectedValue.ToString() + "',RTarihi='" + rtarih.Text + "',RSaat='" + rsaat.Text + "' where RId=" + key + ";"; Hs.HastaSil(query);
                    MessageBox.Show("Randevu İşlemi Başarıyla Güncellendi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }



        


        private void randevudata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            radcb.SelectedValue = randevudata.SelectedRows[0].Cells[1].Value.ToString();
            rtedavi.SelectedValue = randevudata.SelectedRows[0].Cells[2].Value.ToString();
            rsaat.SelectedValue = randevudata.SelectedRows[0].Cells[3].Value.ToString();
            rsaat.SelectedItem = randevudata.SelectedRows[0].Cells[3].Value.ToString();
            rsaat.SelectedText = randevudata.SelectedRows[0].Cells[3].Value.ToString();
            //rsaat. = randevudata.SelectedRows[0].Cells[4].Value.ToString();


            //object cellValue = randevudata.SelectedRows[0].Cells[3].Value;

            //if (cellValue != null)
            //{
            //    if (cellValue is DateTime)
            //    {
            //        // Hücrede zaten DateTime tipinde bir değer var
            //        DateTime selectedDate = (DateTime)cellValue;
            //        randevudata.Text = selectedDate.ToString("yyyy-MM-dd");
            //    }
            //    else if (DateTime.TryParse(cellValue.ToString(), out DateTime parsedDate))
            //    {
            //        // Dönüşüm başarılı
            //        randevudata.Text = parsedDate.ToString("yyyy-MM-dd");
            //    }
            //    else
            //    {
            //        // Dönüşüm başarısız
            //        //MessageBox.Show("Geçerli bir tarih değeri bulunamadı.");
            //    }
            //}
            //else
            //{
            //    // Hücre değeri null ise
            //    MessageBox.Show("Hücre değeri null.");
            //}






          
           
        }

        private void rsil_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Randevuyu Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete  from Randevudbo where RId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu Başarıyla Silindi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void randevudata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void randevudata_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {

        }

        private void rara_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void ryenile_Click(object sender, EventArgs e)
        {
            Reset();
            uyeler();
        }
        Bitmap bitmap;
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            int height = randevudata.Height;
            randevudata.Height = randevudata.RowCount * randevudata.RowTemplate.Height * 2;
            bitmap = new Bitmap(randevudata.Width, randevudata.Height);
            randevudata.DrawToBitmap(bitmap, new Rectangle(0, 10, randevudata.Width, randevudata.Height));
            randevudata.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
