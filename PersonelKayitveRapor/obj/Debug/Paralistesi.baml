   M S B A M L   `   `   `  ����O  KPersonelKayitveRapor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PersonelKayitveRaporPersonelKayitveRapor  5   	   &     PersonelKayitveRapor.Paralistesi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Y UXceed.Wpf.DataGrid, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5   	   .local"clr-namespace:PersonelKayitveRapor  5   	      MaterialDesignPaper#���   5	   	     MaterialDesignBody#���  5
   	     � Icon$  ImageResources\logo.ico��5   	    � Title$ Verilen Para Listesi��5   	   $��485.1��6&   $	��643��65    � 
ResizeMode$ NoResize=�6A   .��5      � .+�5   
   �� -   5         ��Name$ comboBox��5      $
��Left=�6%   $��	10,16,0,0q�6@   $	��Top=�6S   $	��120��6k   $��22��6w   .@�5      �� $��20��6   5      5      (  "System.Windows.Controls.DatePicker  5   
   -   5        $��ilktarih��5      $
��Left=�6%   $��	10,59,0,0q�6@   $	��Top=�6S   $��24��6k   $	��102��6w     5   
   -   5        $��sontarih��5      $
��Left=�6%   $��
134,59,0,0q�6@   $	��Top=�6T   $��24��6l   $	��102��6x   �� 5   
   -   5         ��Name$ ParaVerileriniSil��5      $��Para Verilerini Sil��6,   $
��Left=�6J   $��
453,10,0,0q�6e   $	��Top=�6y   $	��150��6�   $��35��6�   $
��Bold"�6�   6�   �� 5      -   5        $ filtrele��5      $��Filtrele��6(   $
��Left=�6;   $��
160,10,0,0q�6V   $	��Top=�6j   $	��115��6�   $��35��6�   5      �� 5   
   $��Disabled=�6   $��Disabled=�6@   $��0,101,10,52q�6g   .��5      �� .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ParaGrid��5      "   VerticalScrollBarVisibility$ Disabled=�6)   $   HorizontalScrollBarVisibility$ Disabled=�6P   $
��Left=�6y   $��0,0,0,0q�6�   $	��Top=�6�   $	��286��6�   $	��600��6�      AutoGenerateColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 AD SOYAD��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 224 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *verilenAdiSoyadi+6a     5      $
 TARİH��6)   $	 120 6y    68   �� *verilenTarih+ �� StringFormat$ {0:dd/MM/yyyy}��6y     5      $
 ZAMAN��6)   $ 70 6n    68   �� *verilenZaman+$ HH:mm��6n     5       -   5        PARACOL��$

 PARA��5    :   $	 100 6a    6H   �� *para+6a   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $
  ��6-      
IsReadOnly . $ 80 6I      CellTemplate 5"      �� 5#      .R�5$   "   �� $��
sil_button��67   -   5        $	��Sil��5$   )   6I   5%      5'      5)      5*      5+      �� 5-   
   -	   5        $ sifirla��5-      $��Hepsini Göster��6#   $
��Left=�6<   $��
291,10,0,0q�6W   $	��Top=�6k   $	��112��6�   $��35��6�   �� 5.   
   -
   5         ��Name$ 	labelpara��5.      $!��Toplam Verilen Para       :��6#   $
��Left=�6I   $��
10,404,0,0q�6d   $	��Top=�6x   $��27��6�   $	��141��6�   �� 5/   
   -   5        $ toplamverilenpara��5/      $�� ��6+   $
��Left=�66   $��160,404,0,0q�6Q   $	��Top=�6f   $
��Bold"�6~   50      51      