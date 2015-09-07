using System;
using System.Linq;
using System.Windows;
using MongoDB.Driver.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Windows.Documents;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace PersonelKayitveRapor
{
    /// <summary>
    /// Interaction logic for Elemanlistesi.xaml
    /// </summary>
    public partial class Elemanlistesi : Window
    {
        
        bool listelendi = false;
        public Elemanlistesi()
        {
            var process = Process.GetProcessesByName("mongod").FirstOrDefault();
            try
            {


                if (process == null)
                {
                    //// File.Delete(".\\datawiredtiger\\db\\mongod.lock");
                    // Process p = new Process();
                    // p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    // p.StartInfo.FileName = ".\\mongod.exe";
                    // p.StartInfo.Arguments = "--storageEngine wiredTiger  --wiredTigerIndexPrefixCompression false --nojournal  --dbpath .\\datawiredtiger\\db";//--sslAllowInvalidHostnames--sslAllowInvalidCertificates 
                    // p.Start();

                    File.Delete(".\\datawiredtiger\\db\\mongod.lock");
                    Process p = new Process();
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo.FileName = ".\\mongod.exe";
                    p.StartInfo.Arguments = "--storageEngine wiredTiger --syncdelay 3 --wiredTigerCacheSizeGB 2 --wiredTigerIndexPrefixCompression false --nojournal  --dbpath .\\datawiredtiger\\db";//--wiredTigerCollectionBlockCompressor none
                    p.Start();



                    //File.Delete(".\\data\\db\\mongod.lock");
                    //Process p = new Process();
                    //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //p.StartInfo.FileName = ".\\mongod.exe";
                    //p.StartInfo.Arguments = " --nojournal --dbpath .\\data\\db";//--auth
                    //p.Start();



                }


            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Server Başlatılamadı...");
                // File.Delete(".\\data\\db\\mongod.lock");
            }

            InitializeComponent();
               loadeleman();

        }

        private void Yenile()
        {
            loadeleman();
            if (listelendi)
            {
             //   listBox.Items.Clear();
                loadeleman();
            }
        }

        private void ListeyiYenile_Click(object sender, RoutedEventArgs e)
        {
            Yenile();
        }
        
        public void loadeleman()
        {
            double toplam = 0;
            listelendi = true;
            List<InsanClass> liste = new List<InsanClass>();
            var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
            foreach (var kul in kullanicilar)
            {
                liste.Add(new InsanClass { _idkisi = kul._idkisi, pozisyon=kul.pozisyon, ParentId=kul.ParentId, Cinsiyet = kul.Cinsiyet, Adi = kul.Adi, Soyadi = kul.Soyadi, Adres = kul.Adres, Tel = kul.Tel, Maas = kul.Maas, TCNo = kul.TCNo, Resim = kul.Resim, KayitTarihi = kul.KayitTarihi });
                toplam += kul.Maas;


            }

            dataGrid.ItemsSource = liste;

            gider.Content = Convert.ToString(toplam);




        }

        private void yenieleman_Click(object sender, RoutedEventArgs e)
        {
            Elemanekle window = new Elemanekle();
            window.Closed += (ss, ee) => { Yenile(); };
            window.Show();

        }

        private void Verileriyoket_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Databsede bulunan tüm müşteriler silinecek.\nİşleme devam etmek istediğinize emin misiniz?", "Uyar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                return;
            }

            msc.DropTables();
            Yenile();
        }

        private void maaspanel_Click(object sender, RoutedEventArgs e)
        {
            Paralistesi window2 = new Paralistesi();
            window2.Show();
        }

        private void paraodeme_Click(object sender, RoutedEventArgs e)
        {
            Paraodeme window3 = new Paraodeme();
            window3.Show();
        }

        private void Eleman_sil(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Seçtiğiniz elemanın bilgileri silinecek.\nİşleme devam etmek istediğinize emin misiniz?", "Uyar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                return;
            }
            InsanClass bc = (InsanClass)dataGrid.SelectedItem;
            InsanClass.Sil(Convert.ToString(bc._idkisi));
            loadeleman();
        }
        private void Eleman_Duzenle(object sender, RoutedEventArgs e)
        {
            Elemanduzenle Elemanduzenlemepenceresi = new Elemanduzenle();
            Elemanduzenlemepenceresi.Show();
            InsanClass bc = (InsanClass)dataGrid.SelectedItem;
            var eleman = msc.Insancol.FindOneByIdAs<InsanClass>(bc._idkisi);
            Elemanduzenlemepenceresi.eleman = eleman;
            if (eleman.Resim != null)
            {
                var ImageSource = YardimciAraclar.LoadImage(eleman.Resim);
                Elemanduzenlemepenceresi.profilresim.Source = ImageSource;
            }
            Elemanduzenlemepenceresi.txTC.Text = eleman.TCNo;
            Elemanduzenlemepenceresi.txAdi.Text = eleman.Adi;
            Elemanduzenlemepenceresi.txSoy.Text = eleman.Soyadi;
            Elemanduzenlemepenceresi.cboxCinsiyet.Text = eleman.Cinsiyet;
            Elemanduzenlemepenceresi.cboxGorev.Text = eleman.pozisyon;
            Elemanduzenlemepenceresi.txTel.Text = eleman.Tel;
            Elemanduzenlemepenceresi.txAdres.Text = eleman.Adres;
            Elemanduzenlemepenceresi.txMaas.Text =Convert.ToString(eleman.Maas);
            Elemanduzenlemepenceresi.Closed += ChildWindowClosed;
           
            
        }
        private void ChildWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= ChildWindowClosed;
            loadeleman();
        }

        private void organization_Click(object sender, RoutedEventArgs e)
        {
            Agac organizasyonwin = new Agac();
            organizasyonwin.Show();
        }
    }
}

