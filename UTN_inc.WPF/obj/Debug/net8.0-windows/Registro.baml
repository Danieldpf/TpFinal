   M S B A M L   `   `   `  ����F  BUTN_inc.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:UTN_inc.WPFUTN_inc.WPF  5   	       UTN_inc.WPF.Registro   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:UTN_inc.WPF     5   	     � Icon$  Assets/pepito.ico��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Registro��5
   	   $	��450��6   $
��1000��6'   .��5      � 
����ح� � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $��* �6   6)   �� 5      $��20 �6   6*   .+�5   
   �� -   5         ��Name$ listViewVentas��5      $��0��6+   $��1��6;    �� View 5      �� 5       .P�5!      �� $��ID��6%    �� Width$ 50��6Z    �� DisplayMemberBinding 61   �� *	VentaId+6Z   �� 5"      $��Fecha��6%   $	 150��6[    64   �� *Fecha+6[   �� 5#      $��Producto��6%   $	 100��6c    67   �� *
ProductoId+6c   �� 5$      $��Cantidad��6%   $	 100��6a    67   �� *
Cantidad+6a   �� 5%      $��Usuario��6%   $	 100��6a    66   �� *	UsuarioId+6a   5&      5(      �� 5+   
   -   5        $ listViewCompras��5+      $��1��6,   $��1��6<    5,      �� 5-      .P�5.      �� $��ID��6%   $ 50��6[    61   �� *
compraId+6[   �� 5/      $��Fecha��6%   $	 150��6[    64   �� *fecha+6[   �� 50      $��Producto��6%   $	 100��6c    67   �� *
productoId+6c   �� 51      $��Cantidad��6%   $	 100��6a    67   �� *
cantidad+6a   �� 52      $��Usuario��6%   $	 100��6a    66   �� *	usuarioId+6a   53      55      �� 57   
   $��0��6   $��0��6!   $��Center=�61   Ventas6V   �� 58   
   $��0��6   $��1��6!   $��Center=�61   	Compras6W   �� 5:   
   $��2��6   $��0��6!   $��
Venta ID: ��61   $
��Left=�6C   $��Center=�6^   $��	100,0,0,0q�6y   6�   �� 5;   
   $��2��6   $��1��6!   $��Compra ID: ��61   $
��Left=�6D   $��Center=�6_   $��	100,0,0,0q�6z   6�   �� 5=   
   -   5        	 ��Name$	 textVentaId��5=      $��2��6'   $��0��64   $	��120��6D   $��Center=�6P   $��Center=�6m   $��0,0,40,0q�6�   6�   �� 5>   
   -   5        $	 textCompraId��5>      $��2��6(   $��1��65   $	��120��6E   $��Center=�6Q   $��Center=�6n   $��0,0,40,0q�6�   6�   �� 5@   
   -   5        $��0��5@      $��2��6!   $	��200��6.   
�������$��Right=�6k   $��Center=�6�   .��6�   Eliminar Venta6�   �� 5A   
   -   5        $��1��5A      $��2��6!   $	��200��6.   
�������$��Right=�6l   $��Center=�6�   .��6�   Eliminar Compra6�   �� 5C   
   -   5        $��0��5C      $��1��6   
�������$��Atras��6A   $��Right=�6Q   $	��100��6m   $	��Top=�6y   6�   5E      5G      