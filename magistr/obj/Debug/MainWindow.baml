   M S B A M L   `   `   `  ����B  >magistr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:magistrmagistr  5   	       magistr.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:magistr     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��540��6)   .��5	      � ���#FBECAA � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      �� 5      $	��100 �6   �� 5      .+�5   
   �� $��2��6   .+�5      �� $��/Resource/1.jpg��6   5      �� 5   
   $��1��6   $��1��6"   $��Center=�62   $��Center=�6M   .+�5      �� $��Авторизация��6   $��34(�6*   5      �� 5   
   $��Center=�6   $	��150��62   $��2��6>   $��1��6K   .+�5      �� $��Введите код��6   �� 5      -   5        $��
inputLogin��5      �� 5      $!��Введите пароль��6   G� 5      -   5        $��inputPassword��5      � 5      $
��0,10q�6    5      �� 5       �� 5!      .+�5#      �� $��Center=�6   .+�5$      �� -   5        $��Отмена��5$      6.   5%      �� 5&      $��1��6   $��Center=�6-   .+�5'      �� -   5        $��enter��5'      $��Вход��6*   $��45��69   6D   5(      5)      5*      �� 5+   
   $��2��6   $��1��6"   $��Center=�62   $��Center=�6O   .+�5,      �� -   5        $��
timerCheck��5,      5-      5.      5/      