using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonelKayitveRapor.Model;
using PersonelKayitveRapor.Common;
using System.Windows.Input;

namespace PersonelKayitveRapor.ViewModel
{
    public class OrgTreeViewModel : ViewModelBase
    {
        private static OrgTreeViewModel self;

        private List<OrgElementViewModel> root;

        //the root of the visual tree
        public List<OrgElementViewModel> Root
        {
            get 
            {
                if (root == null)
                {
                    root = new List<OrgElementViewModel>();
                    OrgElementViewModel vmRoot = new OrgElementViewModel(OrgChartManager.Instance().GetRoot());
                    vmRoot.IsRoot = true;
                    root.Add(vmRoot);
                }
                return root;            
            }
        }

        private OrgTreeViewModel(){}

        public static OrgTreeViewModel Instance()
        {
            self = new OrgTreeViewModel();
            return self;
        }

    }
}
