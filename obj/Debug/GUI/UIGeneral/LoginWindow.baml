   M S B A M L   `   `   `  ����L  HQLPhongKhamTuNhan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:QLPhongKhamTuNhan.GUI.UIGeneralQLPhongKhamTuNhan.GUI.UIGeneral  5   	   1    +QLPhongKhamTuNhan.GUI.UIGeneral.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:QLPhongKhamTuNhan.GUI.UIGeneral     5   	     � Title$  Đăng nhập��5   	   $	��350��6   $	��450��6(    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   �� 5      $��50 �6   �� 5      .+�5   
   �� $��2��6   $ ��ĐĂNG NHẬP HỆ THỐNG��6$   $��Center=�6A   $��Center=�6^   $��16(�6y   $
��Bold"�6�   �� 5   
   -   5        $��lblUserName��5      $��1��6   $��Tài khoản:��60   $��Right=�6E   $��Center=�6a   �� 5   
   -   5        $��lblPassword��5      $��2��6   $��Mật khẩu:��60   $��Right=�6D   $��Center=�6a   �� 5   
   -   5        $��txtUserName��5   /   $��1��6   $��1��6"    �� TextWrapping$
 Wrap=�6B   $��Center=�6V   $
��Left=�6q   $��10q�6�   $��30��6�   $	��300��6�   $��16(�6�   G� 5   
   -   5        $��txtPassword��5   3   $��1��6   $��2��6&   $��Center=�6F   $
��Left=�6a   $��10q�6|   $��30��6�   $	��300��6�   $��16(�6�   �� 5   
   -   5        $��btnLogin��5   .   $��3��6   $��1��6   $��Đăng nhập��6>   $	��Top=�6R   $��Right=�6j   $��	0,20,45,0q�5   (   $	��100��6;   $��30��6G   �� 5   
   -   5        $��lblForgetPassword��5      $��Quên mật khẩu?��6)   $��3��6B   $��2��6O   $
��Left=�6_   $	��Top=�6z   $��10,20,10,10q�6�   5      5      