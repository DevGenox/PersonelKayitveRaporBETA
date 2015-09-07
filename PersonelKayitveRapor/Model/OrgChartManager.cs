using MongoDB.Bson;
using MongoDB.Driver.Linq;
using PersonelKayitveRapor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PersonelKayitveRapor.Model
{
    class OrgChartManager
    {
        private static OrgChartManager self;

        //orgchart stored in dictionary
        private Dictionary<int, InsanClass> list = new Dictionary<int, InsanClass>();

        private OrgChartManager()
        {
            //populate data
            var kullanicilar = msc.Insancol.AsQueryable<InsanClass>();
            int listesira = 0;
            foreach (var kul in kullanicilar)
             {

                listesira = listesira + 1;
                list.Add(listesira, new InsanClass { treeId = listesira, Adi = kul.Adi, Soyadi = kul.Soyadi, ParentId = kul.ParentId, Resim = kul.Resim });
                
            }
        }

        internal static OrgChartManager Instance()
        {
            if (self == null)
                self = new OrgChartManager();
            return self;
        }

        //get the root
        internal InsanClass GetRoot()
        {
            return list[1];  //return the top root node
        }

        //get the children of a node
        internal IEnumerable<InsanClass> GetChildren(int parentId)
        {
            return from a in list
                   where a.Value.ParentId == parentId
                        && a.Value.treeId != parentId   //don't include the root, which has the same Id and ParentId
                   select a.Value;
        }

        
    }
}
