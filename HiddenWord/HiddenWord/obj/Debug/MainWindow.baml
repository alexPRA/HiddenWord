   M S B A M L   `   `   `  ����C  ?TP_FINAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TP_FINALTP_FINAL  5   	       TP_FINAL.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TP_FINAL     5   	   -   5          � Title$  
Mot caché��5	   	   $	��600��6   $
��1080��6(   $	��590��65   $
��1070��6E    � WindowStartupLocation$ CenterScreen=�6U    � Icon$ img/tic_tac.png��6z   .��5
      � ��5   
   !� 5       !� Visual 5      �� 5      -   5        $��stkMedia��5   !   
�������.+�5      r� -   5        $��
mdeElement��5   B   $
��Left=�6'   $	��Top=�6T    r� Source$ ../../video/giphy.gif?�6l    r� LoadedBehavior$ Manual=�6�    r� Stretch$
 Fill=�6�    r� 
SpeedRatio$ 1Q�6�    r� IsMuted .  6�   5      5      	 � ColumnDefinitions	 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5        $��lblKey��5      $
��test��6   $��0��6-   $��2��6=   $��Center=�6Q   $��Bottom=�6n   $��36(�6�   $��0,0,0,15q�6�   $��DemiBold"�6�   $y�Hidden=�6�   
�������6�   �� 5   
   -   5        $��btnHint��5      $��1��6    $
��Hint��60   $��75��6?   $��50��6J   $��24(�6V   $��Center=�6d   $��Bottom=�6�   $��	0,0,75,15q�6�   6�   �� 5   
   $	��420��6   $	��420��6   
�������$��7q�6>   $��Center=�6R   $��0��6o   ._�5      � -   5        $��grdJeu��5      $	��400��6!   $	��400��6.   $��Center=�6:   $��Center=�6W   $��0��6r   	 5      
 � RowDefinitions
 5      5       5!      �� 5"   
   $��7q�6   
�������$	��420��69   $	��420��6F   $��1��6R   ._�5#      � -   5        $��grdListe��5#      $	��400��6#   $	��400��60   $��Center=�6<   	 5$      
 5&      5)      5*      5+      5,      