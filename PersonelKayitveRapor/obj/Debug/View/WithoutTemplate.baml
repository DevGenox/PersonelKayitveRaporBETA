   M S B A M L   `   `   `  ����  PersonelKayitveRapor/    )PersonelKayitveRapor.View.WithoutTemplate   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      �� .+�5   
   R� -   5          R�Name$  tvMain��5      $��0q�6@   ��6#   �� *Root+��5      �� 5	       �� ItemsSource 6+   �� *
Children+.R�5
      ��  �� Orientation$ 
Horizontal=�6!   ��5      �� 5       �� Triggers 5   "   �� 5   &    �� Binding 62   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" Q� �� Path$ 
IsSelected� �� Value True5   2   .a�5   *   �� 	 �� Property	 � ��
 �� Value

 ��ح�6R   5   '   5      .+�5      �� $��25��6?   $��25��6N   ��6    �� *TreeProfile+6N   �� 5      $��Center=�6$   ��5      `� 5       �� StringFormat$  {0} {1}��6+   .1�5   "   �� $ 	FirstName�6*   �� 5   "   $ LastName�6*   5      5      5      5       ��5"      �� 5#       �� 
TargetType" Q�6   .�5$      �� 	 �@Q�
IsExpanded
 . 63   5%      5'      5(      5)      