using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PersonelKayitveRapor.Model;
using PersonelKayitveRapor.ViewModel;
using MongoDB.Driver.Linq;

namespace PersonelKayitveRapor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Agac : Window
    {
        public Agac()
        {
            InitializeComponent();
            this.DataContext = OrgTreeViewModel.Instance();
          //  TreeOlustur();
        }
/*        public void TreeOlustur()
        {
            
            var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
            foreach (var kul in kullanicilar)
            {
                switch(kul.ParentId)
                {
                    case 1:
                        Mudur.Items.Add(new TreeViewItem() { Header = kul.Adi + " " + kul.Soyadi });

                        break;
                    case 2:
                        CEO.Items.Add(new TreeViewItem() { Header = kul.Adi + " " + kul.Soyadi });

                        break;
                    case 3:
                        MudurYardimcisi.Items.Add(new TreeViewItem() { Header = kul.Adi + " " + kul.Soyadi });

                        break;
                    case 4:
                        SatisMuduru.Items.Add(new TreeViewItem() { Header = kul.Adi + " " + kul.Soyadi });

                        break;
                    case 5:
                        Eleman.Items.Add(new TreeViewItem() { Header = kul.Adi + " " + kul.Soyadi });

                        break;

                }
              //  AltNodeEkle(treeItem, 0);
            }

            
        }*/
        public void AltNodeEkle(TreeViewItem ustnode, int derinlik)
        {
            TreeViewItem altitem = new TreeViewItem();
            ustnode.Items.Add(altitem);
        }
    }
}
