using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections;
using System.Windows.Controls.Primitives;

namespace PersonelKayitveRapor
{
    /// <summary>
    /// Interaction logic for maaspanel.xaml
    /// </summary>
    public partial class Paralistesi : Window
    {

        public Paralistesi()
        {
            InitializeComponent();
            var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
            foreach (var kul in kullanicilar)
            {
                ComboBoxItem personel = new ComboBoxItem();
                personel.Content = kul.Adi + " " + kul.Soyadi;
                comboBox.Items.Add(personel);
            }
            loadnormal();
        }
        private void loadnormal()
        {
            double toplam = 0;
            var Paralar = msc.Paracol.AsQueryable<VerilenPara>();
            List<VerilenPara> paralistesi = new List<VerilenPara>();
            foreach (var par in Paralar)
            {
                paralistesi.Add(new VerilenPara { _idpara = par._idpara, verilenAdiSoyadi = par.verilenAdiSoyadi, para = par.para, verilenTarih = par.verilenTarih, verilenZaman = par.verilenZaman });
                toplam += par.para;
            }
            ParaGrid.ItemsSource = paralistesi;
            toplamverilenpara.Content = Convert.ToString(toplam);
        }
      
        private void loadfiltre()
        {
            double toplam = 0;
            var Paralar = msc.Paracol.AsQueryable<VerilenPara>();
            List<VerilenPara> paralistesi = new List<VerilenPara>();
            ICollectionView filtrelist;
            foreach (var par in Paralar)
            {
                paralistesi.Add(new VerilenPara { _idpara = par._idpara, verilenAdiSoyadi = par.verilenAdiSoyadi, para = par.para, verilenTarih = par.verilenTarih, verilenZaman = par.verilenZaman });
               
            }
            
            filtrelist = CollectionViewSource.GetDefaultView(paralistesi);
            if (filtrelist != null)
            {
                filtrelist.Filter = TextFilter;
                ParaGrid.ItemsSource = filtrelist;
                DataTable myTable = YardimciAraclar.DataGridtoDataTable(ParaGrid);
                foreach(DataRow dr in myTable.Rows)
                 {
                      if (dr["Para"] == "")
                             {
                            break;
                             }
                    toplam += Convert.ToInt32(dr["Para"]);


                 }
                toplamverilenpara.Content = toplam;

                   }
               }
               DateTime? baslangic;
               DateTime? son;
               int tarihsiz = 0;
               public bool TextFilter(object o)
               {
                   VerilenPara p = (o as VerilenPara);
                   if (p == null)
                       return false;
                   switch (tarihsiz)
                   {
                       case 1:
                           if (p.verilenAdiSoyadi.Contains(comboBox.Text))
                               return true;
                           else
                               return false;
                       case 2:
                           if (p.verilenAdiSoyadi.Contains(comboBox.Text) && p.verilenTarih >= baslangic && p.verilenTarih <= son)
                               return true;
                           else
                               return false;
                       case 3:
                           if (p.verilenTarih >= baslangic && p.verilenTarih <= son)
                               return true;
                           else
                               return false;

                   }
                   return false;

                   /*         if(comboBox.Text == "" && ilktarih.Text != "" && sontarih.Text != "")
                            {
                                if (p.verilenzaman >= baslangic && p.verilenzaman <= son)
                                    return true;
                                else
                                    return false;
                            }*/
            }

        private void ParaVerileriniSil_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Databasede bulunan tüm para kayıtları silinecek.\nİşleme devam etmek istediğinize emin misiniz?", "Uyar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                return;
            }

            msc.Paracol.Drop();
            loadnormal();
        }
        private void filtrele_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.Text != "")
            {
                tarihsiz = 1;
            }
            if (ilktarih.Text != "" && sontarih.Text != "" )
            {
                tarihsiz = 2;
                baslangic = ilktarih.SelectedDate;
                son = sontarih.SelectedDate;
            }
            if(comboBox.Text == "")
            {
                tarihsiz = 3;
            }
            if (comboBox.Text == "" && baslangic.HasValue==false && son.HasValue == false)
            {
                loadnormal();
            }

            loadfiltre();
        }
  
        private void sifirla_Click(object sender, RoutedEventArgs e)
        {
            loadnormal();

        }
        private void Eleman_sil(object sender, RoutedEventArgs e)
        {
            VerilenPara pa = (VerilenPara)ParaGrid.SelectedItem;
            VerilenPara.ParaSil(Convert.ToString(pa._idpara));
            if (tarihsiz != 0)
                loadfiltre();
            else
                loadnormal();
        }
    }
}
