   M S B A M L   `   `   `  ����O  KPersonelKayitveRapor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PersonelKayitveRaporPersonelKayitveRapor  5   	   ;"clr-namespace:PersonelKayitveRaporPersonelKayitveRapor  5
   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5   	   (    "PersonelKayitveRapor.Elemanlistesi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:PersonelKayitveRapor     5   	   CPersonelKayitveRapor"clr-namespace:PersonelKayitveRapor     5
   	   XwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf     5   	      MaterialDesignPaper#���   5   	     MaterialDesignBody#���  5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5	   	     � WindowStartupLocation$  CenterScreen=�5   	    � Icon$ ImageResources\logo.ico��5   	    � Title$ Personel Kayıt ve Rapor��5   	   $	��403��6)   $
��1329��66    � 
ResizeMode$ NoResize=�6C   .��5      � .+�5   
   �� $��Disabled=�6   $��Disabled=�6A   $��
0,60,10,38q�6h   .��5      �� $	��296��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      "   VerticalScrollBarVisibility$ Disabled=�6-   $   HorizontalScrollBarVisibility$ Disabled=�6T   $
��Left=�6}   $��0,0,0,0q�6�      AutoGenerateColumns .  $	��Top=�6�   $	��284��6�   $
��1300��6�   $��13.333(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 TC NO��6-   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 200 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *TCNo+6V     5      $	 AD��6-   $	
 192 6R    69   �� *Adi+6R     5      $	 SOYAD��6-   $	
 200 6X    6<   �� *Soyadi+6X     5      $	 ADRES��6-   $	
 270 6W    6<   �� *Adres+6W     5      $	 TELEFON��6-   $	
 150 6W    6>   �� *Tel+6W     5      $
	 MAAS��6-   $	
 100 6U    6;   �� *Maas+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	  ��61      
IsReadOnly . $
 80 6M      CellTemplate 5      �� 5   "   .R�5   &   �� $��
sil_button��6<   -   5        $	��Sil��5   .   6N   5   #   5!        5"      $	  ��61    . $	
 110 6M    5#      �� 5$   "   .R�5%   &   �� $��duzenle_button��6@   -   5        $��Düzenle��5%   .   6V   5&   #   5(         RowDetailsTemplate 5*      �� 5+      .R�5,      ]� 
�������.+�5-   "   �� $��85��6(   ��64   �� *imageSource+� 5.   "   $
��0,10q�6'    � ColumnDefinitions 5/   &   �� 50   *   $
��Auto �6;   �� 51   *   $��* �6;    � RowDefinitions 53   &   �� 54   *   $
��Auto �68   �� 55   *   $
��Auto �68   �� 56   *   $
��Auto �68   .+�58   &   �� $��Adı : ��60   $
��Bold"�6>   �� 59   &   $��1��6E   $
��Bold"�6U   ��60   �� *Adi+6U   �� 5:   &   $��
Soyadı : ��60   $��1��6A   $
��Bold"�6N   �� 5;   &   $��1��6H   $��1��6X   $
��Bold"�6e   ��60   �� *Soyadi+6e   �� 5<   &   $��Kayıt Tarihi : ��60   $��2��6G   $
��Bold"�6T   �� 5=   &   $
��Bold"�6l   $��1��6~   $��2��6�   ��60   �� *KayitTarihi+ �� StringFormat$ {0:dd/MM/yyyy}��6�   5?   #   5@      5A      5D      5E      5F      �� 5I   
   -   5         ��Name$ label��5I      $'��!Toplam Verilen Maaş            :��6   $
��Left=�6J   $��
10,339,0,0q�6e   $	��Top=�6y   �� 5J   
   -   5        $ gider��5J      $�� ��6   $
��Left=�6*   $��182,341,0,0q�6E   $	��Top=�6Z   $
��Bold"�6r   �� 5K   
   -   5         ��Name$ Verileriyoket��5K      $��Eleman Verilerini Temizle��6(   $
��Left=�6L   $��
1055,9,0,0q�6g   $	��Top=�6{   $	��225��6�   $
��Bold"�6�   $��14.667(�6�   $��46��6�   �� 5L   
   -   5        $ yukle��5L        Resimlibuton#���  6    $�� ��6G   $
��Left=�6S   $��	70,10,0,0q�6n   $	��Top=�6�   ��5M      �� 5N       �� ImageSource$  ImageResources/Reflesh.png��6   5P      �� 5Q   
   -   5        $ 
yenieleman��5Q      #���  6%   $�� ��6L   $
��Left=�6W   $��	10,10,0,0q�6r   $	��Top=�6�   ��5R      �� 5S      $" ImageResources/Personnel.png��6   5U      �� 5V   
   -	   5        $ 	parapanel��5V      #���  6$   $�� ��6K    � ToolTip$ Verilen Paralar��6V   $
��Left=�6p   $��
190,10,0,0q�6�   $	��Top=�6�   ��5W      �� 5X      $$ ImageResources/paralistesi.png��6   5Z      �� 5[   
   -
   5        $ 	paraodeme��5[      #���  6$   $�� ��6K   $ Para Ödeme��6V   $
��Left=�6k   $��
130,10,0,0q�6�   $	��Top=�6�   ��5\      �� 5]      $  ImageResources/paraver.png��6   5_      �� 5`   
   -   5        $ organization��5`      #���  6'   $�� ��6N   $ Şirket Organizasyonu��6Y   $
��Left=�6x   $��
250,10,0,0q�6�   $	��Top=�6�   $��51��6�   ��5a      �� 5b      $% ImageResources/organization.png��6    j� Stretch$ Uniform=�6K   5d      5f      5g      