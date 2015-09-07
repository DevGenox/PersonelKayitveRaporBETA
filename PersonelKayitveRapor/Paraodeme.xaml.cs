using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MongoDB.Driver.Linq;
using PersonelKayitveRapor;
using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace PersonelKayitveRapor
{
    /// <summary>
    /// Interaction logic for Paraodeme.xaml
    /// </summary>
    public partial class Paraodeme : Window
    {
        public Paraodeme()
        {
            InitializeComponent();
            
            loadeleman();
        }
        private void loadeleman()
        {
            var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
            foreach (var kul in kullanicilar)
            {
                ComboBoxItem personel = new ComboBoxItem();
                personel.Content = kul.Adi + " " + kul.Soyadi;
                elemansecP.Items.Add(personel);
            }

        }

        private void ver_Click(object sender, RoutedEventArgs e)
        {
            VerilenPara yenipara = new VerilenPara();
            yenipara._idpara = ObjectId.GenerateNewId();
            if (Costomverilenzaman.Text != "")
            {
                yenipara.verilenTarih = Costomverilenzaman.SelectedDate;
                yenipara.verilenZaman = Convert.ToDateTime(saat.Text);
                yenipara.verilenZaman.ToString("hh:mm");
            }
            else
            {
                yenipara.verilenTarih = DateTime.Now;
                yenipara.verilenZaman = DateTime.Now;
            }
            yenipara.verilenAdiSoyadi = elemansecP.Text;
            yenipara.para = Convert.ToInt32(verilenpara.Text);
            msc.Paracol.Insert(yenipara);
            verilenpara.Text = "";
            MessageBox.Show("Para ödeme işlemi başarlı oldu!");
        }
    }
}
