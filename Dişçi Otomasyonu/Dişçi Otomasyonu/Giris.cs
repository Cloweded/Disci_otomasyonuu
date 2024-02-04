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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

            guna2TextBox1.PasswordChar = '*';

        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {


            string kullaniciAdi = guna2TextBox6.Text;
            string sifre = guna2TextBox1.Text;

           
            string DoktorAd = "doktor";
            string DoktorSifre = "123456";

            string personelAdi = "personel";
            string personelSifre = "654321";

            if (kullaniciAdi == DoktorAd && sifre == DoktorSifre)
            {
               
                Anasayfa doktorform = new Anasayfa();
                doktorform.Show();
                this.Hide();
            }
            else if (kullaniciAdi == personelAdi && sifre == personelSifre)
            {
                
                Anasayfa personel2Form = new Anasayfa();
                personel2Form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }

        private void guna2Button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                guna2Button1.PerformClick();
            }
        }
    }
}
