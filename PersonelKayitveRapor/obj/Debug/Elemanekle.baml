   M S B A M L   `   `   `  ����O  KPersonelKayitveRapor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PersonelKayitveRaporPersonelKayitveRapor  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   %    PersonelKayitveRapor.Elemanekle   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:PersonelKayitveRapor     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	      MaterialDesignPaper#���   5   	     MaterialDesignBody#���  5	   	     � Icon$  ImageResources\logo.ico��5   	    � Title$ Personel Kayıt��5   	   $��675.165��6    $��557.328��61    � 
ResizeMode$ NoResize=�6A   .��5      � .+�5   
   �� -   5         ��Name$ 
listeyedon��5        Resimlibuton#���  6%   $�� ��6L   $
��Left=�6W    � ToolTip$ Eleman Listesi��6r   $��	66,10,0,0q�6�   $	��Top=�6�   $��87��6�   $��42��6�   $
��Bold"�6�   ��5      �� 5       �� ImageSource$ ImageResources/list.png��6    j� Stretch$ Uniform=�6C   5      �� 5   
   -   5        $ Temizle��5      #���  6"   $�� ��6I   $ Yenile��6T   $
��Left=�6e   $	��Top=�6�   $��51��6�   $��42��6�   $
��Bold"�6�   $��16(�6�   $��	10,10,0,0q�6�    J� RenderTransformOrigin$ 0.455,0.523&�6�   ��5      �� 5      $  ImageResources/Reflesh.png��6   5      �� 5   
   -   5        $ kaydet��5      #���  6!   $�� ��6H   $ Elemanı Ekle��6S   $
��Left=�6j   $��46��6�   $��438,590,0,0q�6�   $	��Top=�6�   $��79��6�   $��20(�6�   $
��Bold"�6�   $ 
-0.154,0.5&�6�   ��5      �� 5      $ ImageResources/add.png��6   $ Uniform=�6B   5      �� 5   
   -   5         ��Name$
 txTC��5      $
��Left=�6=   $��22��6X   $��139,144,0,0q�6d   	 �� TextWrapping$
	 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��378��6�   
 �� 	MaxLength$
 11��6�   �� 5   
   -   5        $ txAdi��5      $
��Left=�6!   $��24��6<   $��139,204,0,0q�6H   $
	 Wrap=�6]   $	��Top=�6r   $	��378��6�    �� CharacterCasing$ Upper=�6�   �� 5   
   -   5        $ txSoy��5      $
��Left=�6!   $��26��6<   $��139,264,0,0q�6H   $
	 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��378��6�   $ Upper=�6�   �� 5    
   -   5         ��Name$ cboxCinsiyet��5       $
��Left=�6)   $��139,308,0,0q�6D   $	��Top=�6Y   $	��120��6q   .@�5!      �� $��Erkek��6   �� 5"      $��Kadın��6   5#      7  1System.Windows.Forms.Integration.WindowsFormsHost  5$   
   $��139,352,0,0q�6   $��24��60   $	��378��6<   $
��Left=�6H   $	��Top=�6c      Child. 5%      (  "System.Windows.Forms.MaskedTextBox  -   5        	txTel��   Mask$ (000) 000 00 00��5%   .   "  System.Windows.Forms.Control   Height$ 24��6E      Margin+  %System.Windows.Forms.PaddingConverter$ 140,240,0,0 6Q      Width$	 378��6f   5&      �� 5'   
   -	   5        $ txAdres��5'      $
��Left=�6#   $��22��6>   $��139,412,0,0q�6J   $
	 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��378��6�   �� 5(   
   -
   5        $ txMaas��5(      $
��Left=�6?   $��23��6Z   $��139,472,0,0q�6f   $
	 Wrap=�6{   $�� ��6�   $	��Top=�6�   $	��378��6�   �� 5)   
   -   5        $ 	cboxGorev��5)      $
��Left=�6&   $��100,532,0,0q�6A   $	��Top=�6V   $	��120��6n   6z   �� 5*   
   -   5        $ cboxUstKademe��5*      $
��Left=�6*   $��398,532,0,0q�6E   $	��Top=�6Z   $	��119��6r   �� 5+   
   -   5         ��Name$ vatandasliknum��5+      $��TC Kimlik No         :��6(   $
��Left=�6I   $��	9,141,0,0q�6d   $	��Top=�6w   $ -2.481,2.269&�6�   $	��123��6�   $
��Bold"�6�   �� 5,   
   -   5        $	 adi��5,      $%��Adı                          :��6   $
��Left=�6F   $��24��6a   $��	9,201,0,0q�6m   $	��Top=�6�   $	��121��6�   $
��Bold"�6�   �� 5-   
   -   5        $ soyadi��5-      $"��Soyadı                    :��6    $
��Left=�6F   $��	9,261,0,0q�6a   $	��Top=�6t   $
��Bold"�6�   �� 5.   
   -   5        $ cinsiyet��5.      $!��Cinsiyeti                 :��6"   $
��Left=�6H   $��	9,304,0,0q�6c   $	��Top=�6v   $
��Bold"�6�   �� 5/   
   -   5        $ telefon��5/      $!��Telefon                   :��6!   $
��Left=�6G   $��	9,349,0,0q�6b   $	��Top=�6u   $
��Bold"�6�   �� 50   
   -   5        $ adres��50      $"��Adresi                     :��6   $
��Left=�6F   $��	9,409,0,0q�6a   $	��Top=�6t   $
��Bold"�6�   �� 51   
   -   5        $
 maas��51      $&�� Maaşı                      :  ��6   $
��Left=�6G   $��	9,469,0,0q�6b   $	��Top=�6u   $
��Bold"�6�   $	��123��6�   �� 52   
   -   5        $ gorevi��52      $��Görevi           :  ��6!   $
��Left=�6@   $��	9,529,0,0q�6[   $	��Top=�6n   $
��Bold"�6�   $��86��6�   �� 53   
   -   5        $
 alti��53      $*��$(İsteğe Bağlı) Üst Kademesi :  ��6   $
��Left=�6I   $��225,529,0,0q�6d   $	��Top=�6y   $
��Bold"�6�   $	��170��6�   �� 54   
   -   5        $ button��54      $��Resim Ekle...��6!   $
��Left=�69   $��
33,590,0,0q�6T   $	��Top=�6h   $��97��6�   6�   �� 55   
   -   5        $	��125��55      $	��124��6   $��393,10,34,511q�6*    � Cursor$
 Hand��6A   .+�56      �� -   5         ��Name$ profilresim��56      $	��105��6)   $	��104��66    K� ZIndex$ 1��6C    �� Left$ 10��6U   
 �� Top$ 10��6f   �� 57      
���   �$��5��6'   ���#FFC200$	��125��58      $	��124��6)   59      5>      5@      