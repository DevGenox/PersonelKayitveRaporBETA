using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonelKayitveRapor.Model;
using PersonelKayitveRapor.Common;
using System.Windows.Input;
using System.IO;
using System.Collections.ObjectModel;
using MongoDB.Driver.Linq;
using System.Windows.Media.Imaging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonelKayitveRapor.ViewModel
{
    public class OrgElementViewModel : ViewModelBase
    {
        private int Id;
        private string firstName;
        private string lastName;
        private BitmapImage treeprofile;
        private string gorev;
        private ObservableCollection<OrgElementViewModel> children;
        private bool isRoot = false;  //if the node is the root

        public bool IsRoot
        {
            get { return isRoot; }
            set { isRoot = value; }
        }
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public BitmapImage TreeProfile
        {
            get { return treeprofile; }
            set { treeprofile = value; }
        }
        public string Gorev
        {
            get { return gorev; }
            set { gorev = value; }
        }
        public ObservableCollection<OrgElementViewModel> Children
        {
            get
            {
                if (children == null) //not yet initialized
                    return GetChildren();
                return children;
            }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }


        internal OrgElementViewModel(InsanClass i)
        {
                this.ID = i.treeId;
                this.FirstName = i.Adi;
                this.LastName = i.Soyadi;
                var ImageSource = YardimciAraclar.LoadImage(i.Resim);
                this.TreeProfile = ImageSource;
                this.Gorev = i.pozisyon;
        }

        private ObservableCollection<OrgElementViewModel> GetChildren()
        {
            children = new ObservableCollection<OrgElementViewModel>();
            //get the list of children from Model
            foreach (InsanClass ins in OrgChartManager.Instance().GetChildren(this.ID))
            {
                children.Add(new OrgElementViewModel(ins));
            }
            return children;
        }
      
    }
}
