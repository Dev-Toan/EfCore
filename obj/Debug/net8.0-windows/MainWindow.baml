   M S B A M L   `   `   `  ����A  =EFCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EFCoreEFCore  5   	       EFCore.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:EFCore     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��2��6"   .+�5      �� $��Quan ly san pham��6   $��Center=�5      $��Center=�5      $��20(�5       $
��Bold"�5!      5"      �� 5$   
   $��1��6   $��0��6"   $
��Left=�62   $��Center=�6M   .+�5%      �� $��Ma san pham��6   5&      �� 5'   
   $��1��6   $��1��6"   $	��300��62   $
��Left=�6>   $��Center=�6Y   .+�5(      �� -   5         ��Name$ txtMaSP��5(      5)      �� 5+   
   $��2��6   $��0��6"   $
��Left=�62   $��Center=�6M   .+�5,      �� $��Ten san pham��6   5-      �� 5.   
   $��2��6   $��1��6"   $	��300��62   $
��Left=�6>   $��Center=�6Y   .+�5/      �� -   5        $ txtTenSP��5/      50      �� 52   
   $��3��6   $��0��6"   $
��Left=�62   $��Center=�6M   .+�53      �� $��So Luong��6   54      �� 55   
   $��3��6   $��1��6"   $	��300��62   $
��Left=�6>   $��Center=�6Y   .+�56      �� -   5        $ 
txtSoLuong��56      57      �� 59   
   $��4��6   $��0��6"   $
��Left=�62   $��Center=�6M   .+�5:      �� $��DonGia��6   5;      �� 5<   
   $��4��6   $��1��6"   $	��300��62   $
��Left=�6>   $��Center=�6Y   .+�5=      �� -   5        $ 	txtDonGia��5=      5>      �� 5@   
   $��5��6   $��0��6"   $
��Left=�62   $��Center=�6M   .+�5A      �� $��Ma loai��6   5B      �� 5C   
   $��5��6   $��1��6"   $	��300��62   $
��Left=�6>   $��Center=�6Y   .+�5D      �� -   5        $ 	txtMaLoai��5D      5E      �� 5G   
   $��6��6   $��2��6"   $��10,30,10,10q�66   .+�5H      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgQuanLySP��5H   �   $��Center=�6   $��Center=�64   $
��Left=�6O   $
��Bold"�6q   $	��200��6�      AutoGenerateColumns$ False��6�    � 	Resources 5I      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%{   '        �� 5J      "  6   .�5K      ��  � ��$		 120��62   �� 5L       � ��$	 Center=�6G   5M      5N      
   Columns
 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ Ma SP��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *MaSp+  5R      $ Ten SP��6)    69   �� *TenSp+  5S      $ Ten loai SP��6)    6>   �� *	TenLoai+  5T      $ Don Gia��6)    6:   �� *DonGia+  5U      $ So Luong��6)    6;   �� *	SoLuong+  5V      $ 
Thanh Tien��6)      
Foreground
 �  �� 6=   �� *	ThanhTien+ �� StringFormat$ N0��6l   5X      5Y      �� 5[   
   $��7��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��Center=�6l   .+�5\      �� -   5        $
��Them��5\   )   $��
0,10,30,10q�68   $��70��6L   �� 5]      -	   5        $	��Sua��5]   (   $��
0,10,30,10q�66   $��70��6J   �� 5^      -
   5        $	��Xoa��5^   (   $��
0,10,30,10q�66   $��70��6J   �� 5_      -   5        $	��tim��5_   (   $��	0,10,0,10q�66   $��70��6I   5`      5a      5b      