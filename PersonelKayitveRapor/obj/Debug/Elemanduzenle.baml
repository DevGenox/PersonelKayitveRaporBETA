   M S B A M L   `   `   `  ����O  KPersonelKayitveRapor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PersonelKayitveRaporPersonelKayitveRapor  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   (    "PersonelKayitveRapor.Elemanduzenle   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:PersonelKayitveRapor     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	      MaterialDesignPaper#���   5	   	     MaterialDesignBody#���  5
   	     � Icon$  ImageResources\logo.ico��5   	    � Title$! Eleman Bilgilerini Düzenle��5   	   $��669.799��6,   $��557.328��6=    � 
ResizeMode$ NoResize=�6M   .��5      � .+�5   
   �� -   5         ��Name$ kaydet��5        Resimlibuton#���  6!   $�� ��6H    � ToolTip$ Elemanı Ekle��6S   $
��Left=�6j   $��46��6�   $��449,585,0,0q�6�   $	��Top=�6�   $��79��6�   $��20(�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 
-0.154,0.5&�6�   ��5      �� 5       �� ImageSource$ ImageResources/edit.png��6    j� Stretch$ Uniform=�6C   5      �� 5   
   -   5         ��Name$
 txTC��5      $
��Left=�6=   $��22��6X   $��150,151,0,0q�6d   	 �� TextWrapping$
	 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��378��6�   
 �� 	MaxLength$
 11��6�   �� 5   
   -   5        $ txAdi��5      $
��Left=�6!   $��24��6<   $��150,211,0,0q�6H   $
	 Wrap=�6]   $	��Top=�6r   $	��378��6�   �� 5   
   -   5        $ txSoy��5      $
��Left=�6!   $��26��6<   $��150,271,0,0q�6H   $
	 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��378��6�   �� 5   
   -   5         ��Name$ cboxCinsiyet��5      $
��Left=�6)   $��150,315,0,0q�6D   $	��Top=�6Y   $	��120��6q   .@�5      �� $��Erkek��6   �� 5      $��Kadın��6   5      7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   $��150,359,0,0q�6   $��24��60   $	��378��6<   $
��Left=�6H   $	��Top=�6c      Child. 5      (  "System.Windows.Forms.MaskedTextBox  -   5        	txTel��   Mask$ (000) 000 00 00��5   .   "  System.Windows.Forms.Control   Height$ 24��6E      Margin+  %System.Windows.Forms.PaddingConverter$ 140,240,0,0 6Q      Width$	 378��6f   5      �� 5   
   -   5        $ txAdres��5      $
��Left=�6#   $��22��6>   $��150,419,0,0q�6J   $
	 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��378��6�   �� 5   
   -   5        $ txMaas��5      $
��Left=�6?   $��23��6Z   $��150,479,0,0q�6f   $
	 Wrap=�6{   $�� ��6�   $	��Top=�6�   $	��378��6�   �� 5   
   -	   5        $ 	cboxGorev��5      $
��Left=�6&   $��110,539,0,0q�6A   $	��Top=�6V   $	��120��6n   �� 5    
   -
   5        $ cboxUstKademe��5       $
��Left=�6*   $��408,539,0,0q�6E   $	��Top=�6Z   $	��120��6r   �� 5!   
   -   5         ��Name$ vatandasliknum��5!      $��TC Kimlik No          :��6(   $
��Left=�6J   $��
20,148,0,0q�6e   $	��Top=�6y   $ -2.481,2.269&�6�   $	��123��6�   $
��Bold"�6�   �� 5"   
   -   5        $	 adi��5"      $%��Adı                          :��6   $
��Left=�6F   $��24��6a   $��
20,208,0,0q�6m   $	��Top=�6�   $	��121��6�   $
��Bold"�6�   �� 5#   
   -   5        $ soyadi��5#      $"��Soyadı                    :��6    $
��Left=�6F   $��
20,268,0,0q�6a   $	��Top=�6u   $
��Bold"�6�   �� 5$   
   -   5        $ cinsiyet��5$      $$��Cinsiyeti                    :��6"   $
��Left=�6K   $��
20,311,0,0q�6f   $	��Top=�6z   $
��Bold"�6�   �� 5%   
   -   5        $ telefon��5%      $!��Telefon                   :��6!   $
��Left=�6G   $��
20,356,0,0q�6b   $	��Top=�6v   $
��Bold"�6�   �� 5&   
   -   5        $ adres��5&      $"��Adresi                     :��6   $
��Left=�6F   $��
20,416,0,0q�6a   $	��Top=�6u   $
��Bold"�6�   �� 5'   
   -   5        $
 maas��5'      $&�� Maaşı                      :  ��6   $
��Left=�6G   $��
20,476,0,0q�6b   $	��Top=�6v   $
��Bold"�6�   $	��123��6�   �� 5(   
   -   5        $ gorevi��5(      $��Görevi           :  ��6!   $
��Left=�6@   $��
20,536,0,0q�6[   $	��Top=�6o   $
��Bold"�6�   $��88��6�   �� 5)   
   -   5        $
 alti��5)      $*��$(İsteğe Bağlı) Üst Kademesi :  ��6   $
��Left=�6I   $��235,536,0,0q�6d   $	��Top=�6y   $
��Bold"�6�   $	��170��6�   �� 5*   
   -   5        $ 	resimekle��5*      $��Resim Ekle...��6$   $
��Left=�6<   $��
20,585,0,0q�6W   $	��Top=�6k   $	��105��6�   $��31��6�   6�   �� 5+   
   $	��125��6   $	��124��6   $��10,10,417,506q�6*   .+�5,      �� -   5         ��Name$ profilresim��5,      $	��105��6)   $	��104��66    K� ZIndex$ 1��6B    �� Left$ 10��6T   
 �� Top$ 10��6e    � Cursor$
 Hand��6�   �� 5-      
���   �$��5��6'   ���#FFC200$	��125��5.      $	��124��6)   5/      �� 50   
   -   5        $ iptal��50      #���  6    $�� ��6G   $
��Left=�6R   $��353,585,0,0q�6m   $	��Top=�6�   $��79��6�   $��46��6�   ��51      �� 52      $ ImageResources/cancel.png��6   $ Uniform=�6E   54      58      5;      