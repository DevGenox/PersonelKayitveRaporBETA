using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using System.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Data;

namespace PersonelKayitveRapor
{


    public class msc
    {
        //string liste içinde liste örnegi var olgular = msc.Olgu.AsQueryable<OlguClass>().ToArray().Where(p => p.IfaList.Any(x => alintilart.Contains(x.ToString())));
        public static string connectionString = AyarYukle();
        public static MongoClient client = new MongoClient(connectionString);
        public static MongoServer server = client.GetServer();
        public static MongoDatabase db = server.GetDatabase("SiyerPro");
        // public static MongoDatabase db = (Debugger.IsAttached) ? server.GetDatabase("SiyerPro_debug") : server.GetDatabase("SiyerPro"); 
        public static MongoCollection Insancol = db.GetCollection<InsanClass>(typeof(InsanClass).Name);
        public static MongoCollection Paracol = db.GetCollection<VerilenPara>(typeof(VerilenPara).Name);

        public static void RepairDatabase()
        {
            db.RunCommand(new CommandDocument("repairDatabase", 1));
            // db.RunCommand("repairDatabase");
        }


        public static void DropTables()
        {

            msc.Insancol.Drop();


        }
        public static void DropMoney()
        {

           msc.Paracol.Drop();


        }
        public static void CreateIndexes()
        {
            //   options = IndexOptions.SetUnique(true);
            var options = IndexOptions.SetBackground(true);


            Insancol.CreateIndex(new IndexKeysBuilder().Ascending("Sira"), options);
            Paracol.CreateIndex(new IndexKeysBuilder().Ascending("ParaSira"), options);

        
        }
        public static string AyarYukle()
        {
            string connectionString = "";
            try
            {
                using (var reader = new StreamReader("Ayarlar.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var str = line.Split('|');
                        connectionString = str[0].ToString();
                   
                    }
                }
            }
            catch (Exception)
            {

                connectionString = "mongodb://localhost";
            }
            return connectionString;
        }
    }
    public class MongoGridFs
    {
        private readonly MongoDatabase _db;
        private MongoGridFS _gridFs;
        public MongoGridFs(MongoDatabase db)
        {
            _db = db;
            _gridFs = msc.db.GridFS;
        }

        public ObjectId AddFile(Stream fileStream, string fileName)
        {
            var fileInfo = _gridFs.Upload(fileStream, fileName);
            return (ObjectId)fileInfo.Id;
        }

        public Stream GetFile(ObjectId id)
        {
            var file = _gridFs.FindOneById(id);
            return file.OpenRead();
        }
    }
    public class InsanClass
    {
        [BsonId]
        public ObjectId _idkisi;
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Tel { get; set; }
        public string Adres { get; set; }
        public string TCNo { get; set; }
        public string Cinsiyet { get; set; }
        public double Maas { get; set; }
        public double para { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime KayitTarihi { get; set; }
        public byte[] Resim { get; set; }
        public string pozisyon { get; set; }
        public int ParentId { get; set; }
        public int treeId { get; set;}
        public ImageSource imageSource
        {
            get
            {
                if (Resim != null)
                {
                    var Img = new BitmapImage();
                    Img.BeginInit();
                    Img.StreamSource = new System.IO.MemoryStream((byte[])Resim);
                    Img.EndInit();
                    return Img;
                }
                return null;
            }
        }
        public static void Sil (string Id)
        {
            msc.Insancol.Remove(Query.EQ("_id", new ObjectId(Id)));
        }
      
    }
    public class VerilenPara
    {
        [BsonId]
        public ObjectId _idpara;
        public string verilenAdiSoyadi { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? verilenTarih { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime verilenZaman { get; set; }
        public int para { get; set; }
        public static void ParaSil(string Id)
        {
            msc.Paracol.Remove(Query.EQ("_id", new ObjectId(Id)));
        }
    }

    public static class YardimciAraclar
    {

      
        public static DataTable DataGridtoDataTable(DataGrid dg)
        {


            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            string[] Lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToUpper(), typeof(string));
            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0) - 1; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols; f++)
                {
                    Row[f] = Fields[f];
                }
                dt.Rows.Add(Row);
            }
            return dt;

        }
      
        public static bool IsNumber(string s, bool floatpoint)
        {
            int i;
            double d;
            string withoutWhiteSpace = s.Replace(" ", "");
            if (floatpoint)
                return double.TryParse(withoutWhiteSpace, NumberStyles.Any,
                    Thread.CurrentThread.CurrentUICulture, out d);
            else
                return int.TryParse(withoutWhiteSpace, out i);
        }
        public static string HarekesizMetin(string harekeliMetin)
        {
            if (harekeliMetin == "" || harekeliMetin == null) return "";
            string sontext = "";
            var ch = harekeliMetin.Take(harekeliMetin.Length);
            foreach (var c in ch)
            {
                if (c != 'آ' && c != 'ً' && c != 'ٌ' && c != 'ٍ' && c != 'َ' && c != 'ُ' && c != 'ِ' && c != 'ّ' && c != 'ْ')
                {
                    sontext += c;
                }

            }

            return sontext;
        }
      
        public static byte[] LoadImageData(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] imageBytes = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return imageBytes;
        }
     
        public static BitmapImage fileNameBitMap(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.DecodePixelWidth = 200;
                    bitmap.UriSource = new Uri(filePath);
                    bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;

                    bitmap.EndInit();
                    return bitmap;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        public static Stream ToStream(System.Drawing.Image image, ImageFormat formaw)
        {
            var stream = new MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }
        public static byte[] ImageToByte(BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }

            return buffer;
        }
        public static BitmapImage LoadImage(byte[] rawImageBytes)
        {
            BitmapImage imageSource = null;
            if (rawImageBytes == null || rawImageBytes.Length == 0) return null;
            var stream = new MemoryStream(rawImageBytes);
            {
                stream.Seek(0, SeekOrigin.Begin);
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.StreamSource = stream;
                b.EndInit();
                b.Freeze();
                imageSource = b;
            }

            return imageSource;
        }


    


        private static readonly PropertyInfo IsSelectionChangeActiveProperty = typeof(TreeView).GetProperty//tree multiselection
     ("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);
        public static void AllowMultiSelection(this TreeView treeView)
        {

            if (IsSelectionChangeActiveProperty == null) return;



            var selectedItems = new List<TreeViewItem>();
            treeView.SelectedItemChanged += (a, b) =>
            {
                var treeViewItem = treeView.SelectedItem as TreeViewItem;
                if (treeViewItem == null) return;

                // allow multiple selection
                // when control key is pressed
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    // suppress selection change notification
                    // select all selected items
                    // then restore selection change notifications
                    var isSelectionChangeActive =
                      IsSelectionChangeActiveProperty.GetValue(treeView, null);

                    IsSelectionChangeActiveProperty.SetValue(treeView, true, null);
                    selectedItems.ForEach(item => item.IsSelected = true);

                    IsSelectionChangeActiveProperty.SetValue
                    (
                      treeView,
                      isSelectionChangeActive,
                      null
                    );
                }
                else
                {
                    // deselect all selected items except the current one
                    selectedItems.ForEach(item => item.IsSelected = (item == treeViewItem));
                    selectedItems.Clear();
                }

                if (!selectedItems.Contains(treeViewItem))
                {
                    selectedItems.Add(treeViewItem);

                }
                else
                {
                    // deselect if already selected
                    treeViewItem.IsSelected = false;
                    selectedItems.Remove(treeViewItem);
                }
            };

        }

    
  
        public static MemoryStream StreamToMemory(FileStream fileStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.SetLength(fileStream.Length);
            fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
            memoryStream.Flush();
            fileStream.Close();
            memoryStream.Close();
            return memoryStream;


        }



        public static byte[] StreamToByteArray(Stream stream)
        {
            if (stream is MemoryStream)
            {
                return ((MemoryStream)stream).ToArray();
            }
            else
            {
                // Jon Skeet's accepted answer 
                return ReadFully(stream);
            }
        }
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
      



    }
}
