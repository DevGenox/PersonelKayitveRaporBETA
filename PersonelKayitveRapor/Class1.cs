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

            //     msc.Sayfa.CreateIndex(new IndexKeysBuilder().Text("BiList.Met"), options);

            //db.Activity.ensureIndex(
            //               {
            //                 Title: "text",
            //                 Description: "text",
            //                 AlsoKnownAs: "text",
            //                 Keywords: "text"
            //               },
            //               {
            //                 name: "ActivityFullTextIndex"
            //               }
            //             )

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
                        //  var connectionString = "mongodb://user1:password1@localhost/test";
                        //   connectionString = "mongodb://ahmet:1234@localhost/SiyerPro";


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

        //public static Run LoadStringTo(RichTextBox rtb, string tx)
        //{

        //    if (tx == "") return null;

        //    TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

        //    MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(tx));

        //    textRange.Load(ms, DataFormats.Rtf);

        //    FlowDocument fd = rtb.Document;

        //    System.Windows.Documents.Paragraph pr = fd.Blocks.First() as  System.Windows.Documents.Paragraph;



        //    return null;
        //}




        //public static ComboBoxItem FindComboItem(ComboBox combo, string text)
        //{
        //    ComboBoxItem cit = new ComboBoxItem();

        //    foreach (var vit in combo.Items)
        //    {
        //       ComboBoxItem c = (ComboBoxItem)vit;
        //        if (vit.ToString() == text)
        //            cit = c;
        //   }

        //    return cit;

        //}
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
        public static bool matchWholeWord(string test, string search)
        {
            var index = test.IndexOf(search);
            if (index == -1)
                return false;
            var after = index + search.Length;
            if (after == test.Length)
                return true; return !char.IsLetterOrDigit(test[after]);
        }
        public static string FindDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]); if (uc == UnicodeCategory.NonSpacingMark)
                { sb.Append(stFormD[ich]); }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public static string TemizleMarifeTakisi(this string s)
        {
            if (s == null) return "";
            return s.Replace("ʾ", "").Replace("ʿ", "").Replace("el-", "").Replace("en-", "").Replace("ez-", "").Replace("eẑ-", "").Replace("eẓ-", "")
           .Replace("es-", "").Replace("eṡ-", "").Replace("eŝ-", "").Replace("et-", "").Replace("eṭ-", "").Replace("ed-", "").Replace("eḍ-", "").Replace("er-", "");
        }

        public static string TemizleTrans(this string s)
        {
            if (s == null) return "";

            return s.Replace("-", "").Replace("'", "").Replace("ı", "i").Replace("ī", "i").Replace("ʿ", "").Replace("ā", "a").Replace("ū", "u")
                            .Replace("ḳ", "k").Replace("ŝ", "s").Replace("ş", "s").Replace("ḥ", "h").Replace("ṡ", "s").Replace("ḍ", "d")
                            .Replace("ç", "c").Replace("ẑ", "z").Replace("ğ", "g").Replace("ö", "o").Replace("ü", "u");


        }
        //public static string RemoveDiacriticsFormC(this string s, bool donotremove)
        //{
        //    if (donotremove == true) return s;
        //    if (s == null) return "";
        //    String normalizedString = s.Normalize(NormalizationForm.FormC);
        //    StringBuilder stringBuilder = new StringBuilder();
        //    for (int i = 0; i < normalizedString.Length; i++)
        //    {
        //        if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]) != System.Globalization.UnicodeCategory.NonSpacingMark)
        //            stringBuilder.Append(normalizedString[i]);
        //    }
        //    return stringBuilder.ToString();



        //}
        public static string RemoveDiacritics(this string s, bool donotremove)
        {
            if (donotremove == true) return s;
            if (s == null) return "";
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(normalizedString[i]);
            }
            return stringBuilder.ToString();



        }

        //public  string RemoveSpaces(this string s)
        //{
        //    return s.Replace(" ", "");
        //}
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
        public static object StringToXamlObje(string st)
        {
            object o = null;
            try
            {
                if (st.Trim().Length == 0) return null;

                using (StringReader str = new StringReader(st))
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(str))
                    {
                        o = XamlReader.Load(xmlReader);

                    }
                }
            }
            catch
            {
                //    MessageBox.Show(st, "StringToXamlObje Hatası");
                Debug.Write("StringToXamlObje Hata");
            }


            return o;

        }
        public static string XamlObjeToString(object st)
        {
            try
            {
                if (st == null) return "";

                return XamlWriter.Save(st);
            }
            catch
            {

                Debug.Write("");
                return "";
            }

        }

      
        public static string RomaRakami(string rakam)
        {
            string romaRakami = "";
            if (rakam == "1") romaRakami = "I";
            else if (rakam == "2") romaRakami = "II";
            else if (rakam == "3") romaRakami = "III";
            else if (rakam == "4") romaRakami = "IV";
            else if (rakam == "5") romaRakami = "V";
            else if (rakam == "6") romaRakami = "VI";
            else if (rakam == "7") romaRakami = "VII";
            else if (rakam == "8") romaRakami = "VIII";
            else if (rakam == "9") romaRakami = "IX";
            else if (rakam == "10") romaRakami = "X";
            else if (rakam == "11") romaRakami = "XI";
            else if (rakam == "12") romaRakami = "XII";
            else if (rakam == "13") romaRakami = "XIII";
            else if (rakam == "14") romaRakami = "XIV";
            else if (rakam == "15") romaRakami = "XV";
            else if (rakam == "16") romaRakami = "XVI";
            else if (rakam == "17") romaRakami = "XVII";
            else if (rakam == "18") romaRakami = "XVIII";
            else if (rakam == "19") romaRakami = "XIX";
            else if (rakam == "20") romaRakami = "XX";
            else if (rakam == "21") romaRakami = "XXI";
            else if (rakam == "22") romaRakami = "XXII";
            else if (rakam == "23") romaRakami = "XXIII";
            else if (rakam == "24") romaRakami = "XXIV";
            else if (rakam == "25") romaRakami = "XXV";
            else if (rakam == "26") romaRakami = "XXVI";
            else if (rakam == "27") romaRakami = "XXVII";
            else if (rakam == "28") romaRakami = "XXVIII";
            else if (rakam == "29") romaRakami = "XXIX";
            else if (rakam == "30") romaRakami = "XXX";
            else if (rakam == "31") romaRakami = "XXXI";
            else if (rakam == "32") romaRakami = "XXXII";
            else if (rakam == "33") romaRakami = "XXXIII";
            else if (rakam == "34") romaRakami = "XXXIV";
            else if (rakam == "35") romaRakami = "XXXV";
            else if (rakam == "36") romaRakami = "XXXVI";
            else if (rakam == "37") romaRakami = "XXXVII";
            else if (rakam == "38") romaRakami = "XXXVIII";
            else if (rakam == "39") romaRakami = "XXXIX";
            else if (rakam == "40") romaRakami = "XL";

            else if (rakam == "41") romaRakami = "XLI";
            else if (rakam == "42") romaRakami = "XLII";
            else if (rakam == "43") romaRakami = "XLIII";
            else if (rakam == "44") romaRakami = "XLIV";
            else if (rakam == "45") romaRakami = "XLV";
            else if (rakam == "46") romaRakami = "XLVI";
            else if (rakam == "47") romaRakami = "XLVII";
            else if (rakam == "48") romaRakami = "XLVIII";
            else if (rakam == "49") romaRakami = "XLIX";
            else if (rakam == "50") romaRakami = "L";
            else if (rakam == "51") romaRakami = "LI";
            else if (rakam == "52") romaRakami = "LII";
            else if (rakam == "53") romaRakami = "LIII";
            else if (rakam == "54") romaRakami = "LIV";
            else if (rakam == "55") romaRakami = "LV";
            else if (rakam == "56") romaRakami = "LVI";
            else if (rakam == "57") romaRakami = "LVII";
            else if (rakam == "58") romaRakami = "LVIII";

            else if (rakam == "59") romaRakami = "LIX";
            else if (rakam == "60") romaRakami = "LX";


            else romaRakami = rakam;
            return romaRakami;

        }
        public static string KucukRomaRakami(string rakam)
        {
            string romaRakami = "";
            if (rakam == "1") romaRakami = "(i)";
            else if (rakam == "2") romaRakami = "(ii)";
            else if (rakam == "3") romaRakami = "(iii)";
            else if (rakam == "4") romaRakami = "(iv)";
            else if (rakam == "5") romaRakami = "(v)";
            else if (rakam == "6") romaRakami = "(vi)";
            else if (rakam == "7") romaRakami = "(vii)";
            else if (rakam == "8") romaRakami = "(viii)";
            else if (rakam == "9") romaRakami = "(ix)";
            else if (rakam == "10") romaRakami = "(x)";
            else if (rakam == "11") romaRakami = "(xi)";
            else if (rakam == "12") romaRakami = "(xii)";
            else if (rakam == "13") romaRakami = "(xiii)";
            else if (rakam == "14") romaRakami = "(xiv)";
            else if (rakam == "15") romaRakami = "(xv)";
            else if (rakam == "16") romaRakami = "(xvi)";

            else romaRakami = rakam;
            return romaRakami;

        }
        public static string BuyukHarfBasligi(string rakam)
        {
            string romaRakami = "";
            if (rakam == "1") romaRakami = "A";
            else if (rakam == "2") romaRakami = "B";
            else if (rakam == "3") romaRakami = "C";
            else if (rakam == "4") romaRakami = "D";
            else if (rakam == "5") romaRakami = "E";
            else if (rakam == "6") romaRakami = "F";
            else if (rakam == "7") romaRakami = "G";
            else if (rakam == "8") romaRakami = "H";
            else if (rakam == "9") romaRakami = "I";
            else if (rakam == "10") romaRakami = "J";
            else if (rakam == "11") romaRakami = "K";
            else if (rakam == "12") romaRakami = "L";
            else if (rakam == "13") romaRakami = "M";
            else if (rakam == "14") romaRakami = "N";
            else if (rakam == "15") romaRakami = "O";
            else if (rakam == "16") romaRakami = "P";

            else romaRakami = rakam;
            return romaRakami;

        }
        public static string KucukHarfBasligi(string rakam)
        {
            string romaRakami = "";
            if (rakam == "1") romaRakami = "a";
            else if (rakam == "2") romaRakami = "b";
            else if (rakam == "3") romaRakami = "c";
            else if (rakam == "4") romaRakami = "d";
            else if (rakam == "5") romaRakami = "e";
            else if (rakam == "6") romaRakami = "f";
            else if (rakam == "7") romaRakami = "g";
            else if (rakam == "8") romaRakami = "h";
            else if (rakam == "9") romaRakami = "i";
            else if (rakam == "10") romaRakami = "j";
            else if (rakam == "11") romaRakami = "k";
            else if (rakam == "12") romaRakami = "l";
            else if (rakam == "13") romaRakami = "m";
            else if (rakam == "14") romaRakami = "n";
            else if (rakam == "15") romaRakami = "o";
            else if (rakam == "16") romaRakami = "p";

            else romaRakami = rakam;
            return romaRakami;

        }
        //public static byte[] GetScreenShot(this UIElement source, double scale, int quality)
        //{
        //    double actualHeight = source.RenderSize.Height;
        //    double actualWidth = source.RenderSize.Width;
        //    double renderHeight = actualHeight * scale;
        //    double renderWidth = actualWidth * scale;

        //    RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth,
        //        (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
        //    VisualBrush sourceBrush = new VisualBrush(source);

        //    DrawingVisual drawingVisual = new DrawingVisual();
        //    DrawingContext drawingContext = drawingVisual.RenderOpen();

        //    using (drawingContext)
        //    {
        //        drawingContext.PushTransform(new ScaleTransform(scale, scale));
        //        drawingContext.DrawRectangle(sourceBrush, null, new Rect(new System.Drawing.Point(0, 0),
        //            new Point(actualWidth, actualHeight)));
        //    }
        //    renderTarget.Render(drawingVisual);

        //    JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
        //    jpgEncoder.QualityLevel = quality;
        //    jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

        //    Byte[] imageArray;

        //    using (MemoryStream outputStream = new MemoryStream())
        //    {
        //        jpgEncoder.Save(outputStream);
        //        imageArray = outputStream.ToArray();
        //    }
        //    return imageArray;
        //}

        //private void WriteFile(string path)
        //{
        //    byte[] data = null;
        //    data = GetJpgImage(gridMain, 1, 100);
        //    FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        //    foreach (byte digit in data)
        //    {
        //        stream.WriteByte(digit);
        //    }
        //    stream.Close();
        //}

     /*   public static byte[] CropBitmap(byte[] im, Rect rect)
        {

            //CroppedBitmap imco = new CroppedBitmap(YardimciAraclar.LoadImage(im), rect);
            //Image rim = new Image();
            //rim.Source = imco;

            System.Windows.Controls.Image rim = new System.Windows.Controls.Image();
            rim.Source = YardimciAraclar.LoadImage(im);
            RectangleGeometry clipGeometry = new RectangleGeometry(rect, rect.Width, rect.Height);
            //   EllipseGeometry clipGeometry = new EllipseGeometry(new Point(rect.X , rect.Y ), rect.Width, rect.Height);

            rim.Clip = clipGeometry;




            rim.RenderTransformOrigin = new Point(1, 1);
            ScaleTransform flipTrans = new ScaleTransform();
            flipTrans.ScaleX = -1;
            //flipTrans.ScaleY = -1;
            rim.RenderTransform = flipTrans;




            rim.Width = rect.Width;
            rim.Height = rect.Height;
            rim.Measure(new Size(rect.Width, rect.Height));
            rim.Arrange(rect);

            rim.RenderSize = new Size(rect.Width, rect.Height);



            return YardimciAraclar.GetJpgImage(rim, 1, 100); ;
        }*/
        public static byte[] LoadImageData(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] imageBytes = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return imageBytes;
        }
        /*     public static BitmapImage CropBitmap(BitmapImage im, Int32Rect rect)
             {
                 BitmapImage bmcropped = new BitmapImage();

                 CroppedBitmap imco = new CroppedBitmap(im, rect);
                 System.Windows.Controls.Image rim = new System.Windows.Controls.Image();
                 rim.Source = imco;


                 rim.Width = imco.Width;
                 rim.Height = imco.Height;
                 rim.Measure(new System.Drawing.Size(imco.Width, imco.Width);
                 rim.Arrange(new Rect(new Size(imco.Width, imco.Width)));
                 rim.RenderSize = new Size(imco.Width, imco.Width);

                 var sonuc = YardimciAraclar.GetJpgImage(rim, 1, 100);

                 bmcropped = YardimciAraclar.LoadImage(sonuc);

                 return bmcropped;
             }
             public static BitmapImage bitmapOfBitmapSource(BitmapSource bitmapSource)
             {
                 JpegBitmapEncoder encoder = new JpegBitmapEncoder();

                 MemoryStream memoryStream = new MemoryStream();

                 BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();

                 encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                 encoder.Save(memoryStream);

                 bImg.BeginInit();

                 bImg.StreamSource = new MemoryStream(memoryStream.ToArray());

                 bImg.EndInit();

                 memoryStream.Close();
                 return bImg;

             }
             */
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


        //public static BitmapImage LoadImagexx(byte[] imageData)
        //{
        //    if (imageData == null || imageData.Length == 0) return null;
        //    var image = new BitmapImage();
        //    using (var mem = new MemoryStream(imageData))
        //    {
        //        mem.Position = 0;
        //        image.BeginInit();
        //        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        //        image.CacheOption = BitmapCacheOption.OnLoad;
        //        image.UriSource = null;
        //        image.StreamSource = mem;
        //        image.EndInit();
        //    }
        //    image.Freeze();
        //    return image;
        //}
        //public static byte[] GetCroppedJpgImage(UIElement source, Rect rect, double scale, int quality)
        //{
        //    Byte[] imageArray;
        //    double actualHeight = source.RenderSize.Height;
        //    double actualWidth = source.RenderSize.Width;
        //    double renderHeight = actualHeight * scale;
        //    double renderWidth = actualWidth * scale;
        //    RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Pbgra32);
        //    VisualBrush sourceBrush = new VisualBrush(source);
        //    DrawingVisual drawingVisual = new DrawingVisual();
        //    DrawingContext drawingContext = drawingVisual.RenderOpen();
        //    using (drawingContext)
        //    {
        //        drawingContext.PushTransform(new ScaleTransform(scale, scale));
        //        //   drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
        //        drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));

        //    }
        //    renderTarget.Render(drawingVisual);
        //    JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
        //    jpgEncoder.QualityLevel = quality;
        //    jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
        //    using (MemoryStream outputStream = new MemoryStream())
        //    {
        //        jpgEncoder.Save(outputStream);
        //        imageArray = outputStream.ToArray();
        //    }
        //    return imageArray;
        //}
    /*    public static byte[] GetJpgImage(UIElement source, double scale, int quality)
        {
            Byte[] imageArray;
            double actualHeight = source.RenderSize.Height;
            double actualWidth = source.RenderSize.Width;
            double renderHeight = actualHeight * scale;
            double renderWidth = actualWidth * scale;



            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            VisualBrush sourceBrush = new VisualBrush(source);
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));

                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new System.Drawing.Point(0, 0), new Point(actualWidth, actualHeight)));
            }


            renderTarget.Render(drawingVisual);

            JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
            jpgEncoder.QualityLevel = quality;
            jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
            using (MemoryStream outputStream = new MemoryStream())
            {
                jpgEncoder.Save(outputStream);
                imageArray = outputStream.ToArray();
            }
            return imageArray;
        }
        */


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

        public static int KlayveSec(System.Windows.Forms.InputLanguage LayoutName)
        {
            int sec = 0;
            var keys = System.Windows.Forms.InputLanguage.InstalledInputLanguages;
            foreach (var key in keys)
            {
                var lang = (System.Windows.Forms.InputLanguage)key;
                if (lang.Culture.Name == LayoutName.Culture.Name)// "Turkish Q - Custom")
                {
                    System.Windows.Forms.InputLanguage.CurrentInputLanguage = lang;
                    if (lang.LayoutName == "Kuramer Q") sec = 1;
                    if (lang.LayoutName == "Kuramer F") sec = 2;
                }

            }
            return sec;
        }


      

        //        filepath--- The Path of the Source PDF File need to Split.

        //dirPath---The Path of the Destination Folder, the splited files need to be saved.

      


        //        byte[] buffer;
        //using (Stream stream = new IO.FileStream("file.pdf"))
        //{
        //   buffer = new byte[stream.Length - 1];
        //   stream.Read(buffer, 0, buffer.Length);
        //}

        //using (Stream stream = new IO.FileStream("newFile.pdf"))
        //{
        //   stream.Write(buffer, 0, buffer.Length);
        //}

        //public static byte[] StreamPDFToByte(string filename)
        //{
        //    // string filename = "C:\\sample.pdf";
        //    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

        //    // Create a byte array of file stream length
        //    byte[] byteData = new byte[fs.Length];

        //    //Read block of bytes from stream into the byte array
        //    fs.Read(byteData, 0, System.Convert.ToInt32(fs.Length));

        //    //Close the File Stream
        //    fs.Close();
        //    return byteData; //return the byte data
        //}

        public static byte[] StreamPDFToByte(string filename)
        {
            // string filename = "C:\\sample.pdf";
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] byteData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(byteData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            // System.IO.Directory.Delete("test", true);
            return byteData; //return the byte data
        }


        public static FileStream StreamByteToPDF(byte[] byteData)
        {
            string filename = "gosterilenSayfa.pdf";
            //  string filename = "C:\\Newsample.pdf";
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

            //Read block of bytes from stream into the byte array
            fs.Write(byteData, 0, byteData.Length);

            //Close the File Stream
            fs.Close();
            //System.IO.Directory.Delete("gosterilenSayfa.pdf", true);
            return fs;
        }
        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
        public static void StreamByteToPDFx(byte[] byteData)
        {
            string filename = "gosterilenSayfa.pdf";
            //  string filename = "C:\\Newsample.pdf";
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

            //Read block of bytes from stream into the byte array
            fs.Write(byteData, 0, byteData.Length);

            //Close the File Stream
            fs.Close();
            //System.IO.Directory.Delete("gosterilenSayfa.pdf", true);
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
        //public static void SplitPDF(string filepath)
        //{

        //    PdfReader reader = null;
        //    int currentPage = 1;
        //    int pageCount = 0;
        //    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        //    reader = new iTextSharp.text.pdf.PdfReader(filepath);
        //    reader.RemoveUnusedObjects();
        //    pageCount = reader.NumberOfPages; string ext = System.IO.Path.GetExtension(filepath); for (int i = 1; i <= pageCount; i++)
        //    {
        //        iTextSharp.text.pdf.PdfReader reader1 = new iTextSharp.text.pdf.PdfReader(filepath);
        //        string outfile = filepath.Replace((System.IO.Path.GetFileName(filepath)),
        //            (System.IO.Path.GetFileName(filepath).Replace(".pdf", "") + "_" + i.ToString()) + ext);
        //        outfile = outfile.Substring(0, dirPath.Length).Insert(dirPath.Length, "\\Images\\PDFSplit") + "\\" + System.IO.Path.GetFileName(filepath).Replace(".pdf", "") + "_" + i.ToString() + ext; reader1.RemoveUnusedObjects();
        //        iTextSharp.text.Document doc = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(currentPage));
        //        iTextSharp.text.pdf.PdfCopy  pdfCpy = new iTextSharp.text.pdf.PdfCopy(doc, new System.IO.FileStream(outfile, System.IO.FileMode.Create));
        //        doc.Open();
        //        for (int j = 1; j <= 1; j++)
        //        {
        //            iTextSharp.text.pdf.PdfImportedPage page = pdfCpy.GetImportedPage(reader1, currentPage);
        //            pdfCpy.SetFullCompression();
        //            pdfCpy.AddPage(page); 
        //            currentPage += 1;
        //        }
        //        doc.Close();
        //        pdfCpy.Close();
        //        reader1.Close();
        //        reader.Close();

        //    }

        //}






    }
}
