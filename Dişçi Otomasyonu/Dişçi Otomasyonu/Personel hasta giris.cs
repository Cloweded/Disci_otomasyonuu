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
    public partial class Personel_hasta_giris : Form
    {
        public Personel_hasta_giris()
        {
            InitializeComponent();
        }
        

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void hastakaydet_Click(object sender, EventArgs e)
        {
            string query= "insert into Personel_Hasta_Giris values('"+hastaad.Text+"' ,'"+hastailetisim.Text+ "','" + hastaadres.Text + "' , '" +hastadogumdate.Text+"' , '"+hastacinsiyet.SelectedItem.ToString()+"' )";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Hasta Başarıyla Eklendi");
                uyeler();
                Reset();

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        
        }


        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Personel_Hasta_Giris";
            DataSet ds = Hs.ShowHasta(query);
            hastadatagrid.DataSource = ds.Tables[0];

        }



        void filter()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Personel_Hasta_Giris where HAd like '%" + hastaara.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            hastadatagrid.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            hastaad.Text = "";
            hastailetisim.Text = "";
            hastadogumdate.Text = "";
            hastaadres.Text = "";
            hastacinsiyet.SelectedItem = "";
            
        }


        private void Personel_hasta_giris_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }

        int key = 0;

        private void hastadatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hastaad.Text = hastadatagrid.SelectedRows[0].Cells[1].Value.ToString();
            hastailetisim.Text = hastadatagrid.SelectedRows[0].Cells[2].Value.ToString();
            object cellValue = hastadatagrid.SelectedRows[0].Cells[4].Value;

            if (cellValue != null)
            {
                if (cellValue is DateTime)
                {
                    // Hücrede zaten DateTime tipinde bir değer var
                    DateTime selectedDate = (DateTime)cellValue;
                    hastadogumdate.Text = selectedDate.ToString("yyyy-MM-dd");
                }
                else if (DateTime.TryParse(cellValue.ToString(), out DateTime parsedDate))
                {
                    // Dönüşüm başarılı
                    hastadogumdate.Text = parsedDate.ToString("yyyy-MM-dd");
                }
            }

            hastaadres.Text = hastadatagrid.SelectedRows[0].Cells[3].Value.ToString();
            hastacinsiyet.SelectedItem = hastadatagrid.SelectedRows[0].Cells[5].Value.ToString();


            if (hastaad.Text == "")
            {
                key = 0;

            }

            else
            {
                key = Convert.ToInt32(hastadatagrid.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void hastasil_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if(key == 0)
            {
                MessageBox.Show("Silenecek hastayı seçiniz");

            }
            else
            {
                try
                {
                    string query = "delete  from Personel_Hasta_Giris where HId = " + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Hasta Başarıyla Silinmiştir.");
                    uyeler();
                    Reset();
                   
                }

                catch (Exception Ex)

                { 
                    MessageBox.Show(Ex.Message);
                }
                
            }
        }

        private void hastaduzenle_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek hastayı seçiniz");

            }
            else
            {
                try
                {
                    string query = "Update Personel_Hasta_Giris set HAd='" + hastaad.Text + "',HTelefon='" + hastailetisim.Text + "',HAdres='" + hastaadres.Text + "',HDTarih='" + hastadogumdate.Text + "',HCinsiyet='" +hastacinsiyet.SelectedItem.ToString() + "' where HId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
                    uyeler();
                    Reset();

                }

                catch (Exception Ex)

                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void hastaarabuton_Click(object sender, EventArgs e)
        {
            filter();

        }

        private void hastayenile_Click(object sender, EventArgs e)
        {
            Reset();
            uyeler();
        }

        private void hastacıkıs_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
