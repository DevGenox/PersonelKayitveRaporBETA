using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.ComponentModel;

namespace PersonelKayitveRapor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Elemanduzenle : Window
    {
        /*       private const int GWL_STYLE = -16;            
               private const int WS_SYSMENU = 0x80000;                                             //X kapatma

               [DllImport("user32.dll", SetLastError = true)]
               private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

               [DllImport("user32.dll")]
               private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
               private void Window_Loaded(object sender, RoutedEventArgs e)
               {
                   var hwnd = new WindowInteropHelper(this).Handle;
                   SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
               }
               */

        public Elemanduzenle()
        {

            InitializeComponent();

      /*      var hwnd = new WindowInteropHelper(this).Handle;                                      //X kapatma
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);*/

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
            //   this.LocationChanged += AnaPencere_LocationChanged;
            //   msc.Alinti.Remove(MongoDB.Driver.Builders.Query.EQ("_id", new ObjectId("5317d476ee06bc07349ca5d3")));

            //  anaPen = this;
            //  stkPen = stkTaban;
            //try
            //{
            //    lbBilgiler.Text = msc.Kaynak.Count().ToString() + " Kaynak             " + msc.Nusha.Count().ToString() + " Nüsha";

            //}
            //catch (Exception)
            //{
            //    MessageBoxResult result = MessageBox.Show("Ayarlar Yüklenemedi...");

            //}
            //var lang = System.Windows.Forms.InputLanguage.InstalledInputLanguages;
            //System.Windows.Forms.InputLanguage.CurrentInputLanguage = lang[1];
          //  LoadDB();
        }

      /*  private void LoadDB()
        {
            lstCanlilar.Items.Clear();
            var kullanicilar = msc.Insan.AsQueryable<InsanClass>();
            foreach (var kul in kullanicilar)
            {
                ListBoxItem litem = new ListBoxItem();
                litem.Tag = kul;
                litem.Content = kul.Adi;
                lstCanlilar.Items.Add(litem);

            }

        }*/



     /*   private void lstCanlilar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListBoxItem item = lstCanlilar.SelectedItem as ListBoxItem;
            InsanClass ins = item.Tag as InsanClass;
            txAdi.Text = ins.Adi;
            txSoy.Text = ins.Soyadi;
            txTel.Text = Convert.ToString(ins.Tel);
            txAdres.Text = ins.Adres;
            txTC.Text = ins.TCNo;
            txMaas.Text = Convert.ToString(ins.Maas);
        }*/


        

        private void Listeyedon_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        string browsefilename;
        public InsanClass eleman { get; set; }
        private void kayitetme()
        {
            try
            {
                if (txTC.Text.Length == 11)
                {
                    var fileName = browsefilename;
                    if (fileName != null)
                    {
                        byte[] imageArray = File.ReadAllBytes(browsefilename);
                        eleman.Resim = imageArray;
                    }
                    
                    eleman.Adi = txAdi.Text;
                    eleman.Soyadi = txSoy.Text;
                    eleman.Cinsiyet = cboxCinsiyet.Text;
                    eleman.Tel = txTel.Text;
                    eleman.Adres = txAdres.Text;
                    eleman.TCNo = txTC.Text;
                    eleman.Maas = Convert.ToDouble(txMaas.Text);
                    msc.Insancol.Update(Query.EQ("_id", eleman._idkisi), Update.Replace(eleman), UpdateFlags.Upsert);
                    txAdi.Text = "";
                    txSoy.Text = "";
                    txTel.Text = "";
                    txAdres.Text = "";
                    txTC.Text = "";
                    txMaas.Text = "";
                    MessageBox.Show("Personel bilgisi düzenlendi !!! ");
                    // LoadDB();
                }
                else
                {
                    MessageBox.Show("TC Numarası 11 haneli olmalıdır!");
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı giriş yapıldı!!!");

            }
        }
        private void Kaydet_Click(object sender,RoutedEventArgs e)
        {
       //     InsanClass.Sil(Convert.ToString(bc._idkisi));
            kayitetme();
        }
        private void Temizle_Click(object sender, RoutedEventArgs e)
        {
            txAdi.Text = "";
            txSoy.Text = "";
            txTel.Text = "";
            txAdres.Text = "";
            cboxCinsiyet.Text = "";
            txTC.Text = "";
            txMaas.Text = "";
        }

        private void OnlyNumbers(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 ||
                key >= 74 && key <= 83 || key == 2);
        }

        private void iptal_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void resimekle_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    browsefilename = dlg.FileName;
                    BitmapImage bmp = new BitmapImage(new Uri(browsefilename, UriKind.Absolute));
                    profilresim.Source = bmp;
                }
                catch (Exception)
                {

                    MessageBox.Show("Geçersiz resim dosyası!!", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
        }

        private void iptal_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void profilresim_MouseDown(object sender, MouseButtonEventArgs e)
        {
            resimekle_Click(null, null);
        }
    }
    }
