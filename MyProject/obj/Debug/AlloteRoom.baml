   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyProject	MyProject  5   	       MyProject.AlloteRoom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MyProject     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5	   
     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ AddHostelPanel��5
   	   $	��550��6    $
��1000��6-   .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $
��0.6* �6   �� 5      $
��0.3* �6   �� 5      $
��1.5* �6   �� 5      $
��0.3* �6    � RowDefinitions 5   
   �� 5      $��0.25* �6   �� 5      $��* �6   �� 5      $��0.25* �6   .+�5   
   ]� ���	#FF12548B.+�5      "  FontAwesome.WPF.ImageAwesome  $��1��6   $��1��6.      Icon$	 bed=�6;      
Foreground
 �����$��Center=�6Y   $��92��6v   $��Center=�6�   $��74��6�   $��0,16,0,3q�6�   5      ]� 5   
   $��2��6   ���	#FF12548B.+�5      �� -   5         ��Name$ 
BackButton��5      $
��Back��6)   
������ 
�������$��20(�6e   
�������$��Bottom=�6�   $��3q�6�   5      ]� 5   
   ���	#FF12548B$��0��6+   $��1��6;   .+�5      �  5      �� 5       $��0* �6'   �� 5!      �� 5"      $
��2.8* �6'    5$      �� 5%      $��70 �6$   �� 5&      $
��0.5* �6$   �� 5'      $
��0.5* �6$   �� 5(      $
��0.5* �6$   �� 5)      $
��0.5* �6$   �� 5*      $
��0.5* �6$   �� 5+      .+�5-        $
 Male=�6"   
 �����$��1��6A   $��3��6Q   $��	10,10,0,3q�6^     5.      $ Female=�6"   
 �����$��1��6C   $��4��6S   $��12,6,0,5q�6`     5/      $	 Eye=�6"   
 �����$��1��6@   $��5��6P   $��	20,11,6,9q�6]     50      $
 Home=�6"   
 �����$��1��6A   $��2��6Q   $��	20,11,6,9q�6^   �� 51      $
��ROOM��6   
�������$��0��6;   $��2��6H   $��30(�6X   $
��Bold"�6f   $��Center=�6x   �� 52      -   5        $ AllocateBoysBtn��52   6   $��2��6   $��3��6)   $��Allocate Boys��6O   
������ 
�������$��14(�6�   
������ 6�   �� 53      -   5        $ AllocateGirlsBtn��53   6   $��3��6   $��4��6)   $��Allocate Girls��6P   
������ 
�������$��14(�6�   
������ 6�   �� 54      -   5        $ 
ViewAllBtn��54   6   $��3��6   $��5��6)   $��View Students��6J   
������ 
�������$��14(�6�   
������ 6�   �� 55      -   5        $ ViewHOstelBtn��55   6   $��3��6   $��2��6)   $��View Hostals��6M   
������ 
�������$��14(�6�   
������ 6�   56      57      ]� 58   
   ���	#FF12548B$��1��6+   $��2��68   .+�59      �  5:      �� 5;      �� 5<      $��0.09* �6$   .+�5>      &   System.Windows.Controls.DataGrid  -   5          Name$ ViewGrid��5>      
�������$	��0.5q�6D   ]� 5?      
�������$��1q�6/   $��2��6:   .+�5@      ]� ���	#FF12548B.+�5A      �� -   5        $ AllocateBtn��5A   !   $��1��66   
������ 
�������$��ALLOCATE��6o   $��16(�6�   $
��Bold"�6�   6�   5B      5C      5D      5E      5F      5G      