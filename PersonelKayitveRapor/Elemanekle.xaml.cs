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
using MongoDB.Driver.GridFS;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

namespace PersonelKayitveRapor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Elemanekle : Window
    {
        public Elemanekle()
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
            cboxGorev.Items.Add("CEO");
            cboxGorev.Items.Add("Müdür");
            cboxGorev.Items.Add("Müdür Yardımcısı");
            cboxGorev.Items.Add("Satış Müdürü");
            cboxGorev.Items.Add("Eleman");
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


        private System.Windows.Controls.Image ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
        {


            System.Windows.Controls.Image img = new System.Windows.Controls.Image();

            //convert System.Drawing.Image to WPF image
            Bitmap bmpsecond = new Bitmap(gdiImg);
            IntPtr hBitmap = bmpsecond.GetHbitmap();
            ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            InitializeComponent();

            img.Source = WpfBitmap;
            img.Width = 85;
            img.Height = 85;
            img.Margin = new Thickness(158, 10, 0, 0);
            img.Stretch = Stretch.Fill;
            return img;
        }

        private void Listeyedon_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        string browsefilename;


        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public BitmapImage ImageFromBuffer(Byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        private void Temizle_Click(object sender, RoutedEventArgs e)
        {
            txAdi.Text = "";
            txSoy.Text = "";
            txTel.Text = "";
            txAdres.Text = "";
            txTC.Text = "";
            txMaas.Text = "";
        }

        private void OnlyNumbers(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 ||
                key >= 74 && key <= 83 || key == 2);
        }
        private void button_Click(object sender, RoutedEventArgs e)
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
                    BitmapImage NewBitmap = new BitmapImage(new Uri(browsefilename, UriKind.Absolute));
                    profilresim.Source = NewBitmap;
                }
                catch (Exception)
                {

                    MessageBox.Show("Geçersiz resim dosyası!!", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
        }
        int listesira = 0;
        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            InsanClass ins = new InsanClass();
            var fileName = browsefilename;
            if (fileName != null)
            {
                byte[] imageArray = File.ReadAllBytes(browsefilename);
                ins.Resim = imageArray;
            }
            try
            {
                if (txTC.Text.Length == 11)
                {

                    ins._idkisi = ObjectId.GenerateNewId();
                    ins.Adi = txAdi.Text;
                    ins.Soyadi = txSoy.Text;
                    ins.Cinsiyet = cboxCinsiyet.Text;
                    ins.Tel = txTel.Text;
                    ins.Adres = txAdres.Text;
                    ins.TCNo = txTC.Text;
                    ins.pozisyon = cboxGorev.Text;
                    switch (cboxGorev.Text)
                    {
                        case "Müdür":
                            ins.ParentId = 1;
                            if (cboxUstKademe != null)
                            {
                                var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                                foreach (var kul in kullanicilar)
                                {
                                    listesira = listesira + 1;
                                    kul.treeId = listesira;
                                    if (kul.Adi + " " + kul.Soyadi == cboxUstKademe.Text)
                                    {
                                        ins.ParentId = kul.treeId;
                                        break;
                                    }
                                }
                            }
                            break;
                        case "CEO":
                            ins.ParentId = 1;
                            break;
                        case "Müdür Yardımcısı":
                            ins.ParentId = 1;
                            if (cboxUstKademe != null)
                            {
                                var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                                foreach (var kul in kullanicilar)
                                {
                                    listesira = listesira + 1;
                                    kul.treeId = listesira;
                                    if (kul.Adi + " " + kul.Soyadi == cboxUstKademe.Text)
                                    {
                                        ins.ParentId = kul.treeId;
                                        break;
                                    }
                                }
                            }
                            break;
                        case "Satış Müdürü":
                            ins.ParentId = 2;
                            if (cboxUstKademe != null)
                            {
                                var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                                foreach (var kul in kullanicilar)
                                {
                                    listesira = listesira + 1;
                                    kul.treeId = listesira;
                                    if (kul.Adi + " " + kul.Soyadi == cboxUstKademe.Text)
                                    {
                                        ins.ParentId = kul.treeId;
                                        break;
                                    }
                                }
                            }
                            break;                            
                        case "Eleman":
                            ins.ParentId = 3;
                            if (cboxUstKademe != null)
                            {
                                var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                                foreach (var kul in kullanicilar)
                                {
                                    listesira = listesira + 1;
                                    kul.treeId = listesira;
                                    if (kul.Adi + " " + kul.Soyadi == cboxUstKademe.Text)
                                    {
                                        ins.ParentId = kul.treeId;
                                        break;
                                    }
                                }
                            }                            
                            break;
                    }

                    ins.Maas = Convert.ToDouble(txMaas.Text);
                    ins.KayitTarihi = DateTime.Now;
                    msc.Insancol.Insert(ins);
                    txAdi.Text = "";
                    txSoy.Text = "";
                    txTel.Text = "";
                    cboxCinsiyet.Text = "";
                    txAdres.Text = "";
                    txTC.Text = "";
                    txMaas.Text = "";
                    MessageBox.Show("Personel kayıtı başarlı oldu.Hadi Hayırlısı! ");
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

        private void Kayit_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void profilresim_MouseDown(object sender, MouseButtonEventArgs e)
        {
            button_Click(null, null);
        }

        private void cboxGorev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             if (cboxGorev.SelectedItem.ToString() == "Eleman")
                {
                    var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                    foreach (var kul in kullanicilar)
                      {
                        if (kul.ParentId == 2)
                        {
                            ComboBoxItem personel = new ComboBoxItem();
                            personel.Content = kul.Adi + " " + kul.Soyadi;
                            cboxUstKademe.Items.Add(personel);
                        }

                 }
                }
            if (cboxGorev.SelectedItem.ToString() == "Satış Müdürü")
            {
                var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                foreach (var kul in kullanicilar)
                {
                    if (kul.ParentId == 1)
                    {
                        ComboBoxItem personel = new ComboBoxItem();
                        personel.Content = kul.Adi + " " + kul.Soyadi;
                        cboxUstKademe.Items.Add(personel);
                    }

                }
            }
            if (cboxGorev.SelectedItem.ToString() == "Müdür")
            {
                var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                foreach (var kul in kullanicilar)
                {
                    if (kul.ParentId == 1)
                    {
                        ComboBoxItem personel = new ComboBoxItem();
                        personel.Content = kul.Adi + " " + kul.Soyadi;
                        cboxUstKademe.Items.Add(personel);
                    }

                }
            }
            if (cboxGorev.SelectedItem.ToString() == "Müdür Yardımcısı")
            {
                var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
                foreach (var kul in kullanicilar)
                {
                    if (kul.ParentId == 1)
                    {
                        ComboBoxItem personel = new ComboBoxItem();
                        personel.Content = kul.Adi + " " + kul.Soyadi;
                        cboxUstKademe.Items.Add(personel);
                    }

                }
            }

        }
    }
}
