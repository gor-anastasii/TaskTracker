   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TodoApp.ViewTodoApp.View  5   	       TodoApp.View.CreateTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:TodoApp.View  5   	     � Title$  
CreateTask��5	   	   $	��380��6   $	��530��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�6   $��Lexend)�62    � AllowsTransparency$
 True��6F   
������ .��5      ��  �� CornerRadius$ 20��6   ���#A084CF._�5   
   � $��20q�6    � RowDefinitions 5      �� 5      $	��12* �6    �� 5      $	��73* �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $��Create New Task��6   $��Center=�63   $��16(�6N   $��Medium"�6\   ���#fff$��20 0 0 0q�6�   �� 5      -   5           RoundButtonStyleCreateTask#���   5   H   $��	310 0 0 0q�6}   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�6�   5      � 5      $��1��6   $��	20,0,20,0q�6    	 � ColumnDefinitions	 5      �� 5      �� 5      .+�5      �� $ Vertical=�6   $��0��64   $��0 0 10 0q�6D   .+�5      �� 
�������$��16(�63   $��Title *��6A   �� 5      $	��0 6q�65   
������ 
�������$��0 0 0 2q�6o   
���������6   �� *Title+6�   �� 5!      
�������$��16(�63   $��Description��6A   $��0 4 0 0q�6T   �� 5"      $
��Auto=�6#   .��5#      �� $	��0 6q�6?   
������ 
�������$��0 0 0 2q�6y   
���������6"   �� *Description+6�   5$      �� 5&      
�������$��16(�63   $��Deadline��6A   $��0 6 0 0q�6Q   (  "System.Windows.Controls.DatePicker  5'      $��0 2 0 0q�6K   
   SelectedDate
 6!   �� *SelectedDeadline+6K   �� 5)      
�������$��16(�63   $��Category��6A   $��0 10 0 4q�6Q   �� 5*      $��20��6    �� SelectedValue 6+   �� *SelectedCategory+��6V   �� *
Categories+�� 5-      $ 
Horizontal=�6!   $��0 50 0 0q�6:   .+�5.      �� $
��Save��6!   $	��110��6T   $��5q�6`   ���#fff$��26��6~   ���#A084CF  CustomAnalyticButtonStyle2#��[ 6�   ��60   �� *SaveTaskCommand+6�   5/      50      �� 53      $��1��6   $��15 0 0 0q�6-   .+�54      �� $ 
Horizontal=�6!   $��0 0 0 0q�6:   .+�55      �� 
�������$��16(�67   $��Period Task��6E   $
��Bold"�6X   56      �� 58      $ Vertical=�6!   $��0 10 0 0q�68   .+�59      �� 
�������$��16(�67   $��End of period��6E     5:      $	��210��6M   $��0 3 0 0q�6Y   $
��Left=�6j   
 6%   �� *SelectedPeriod+5;      5<      �� 5>      $��	Frequency��6    
�������$��16(�6D   $��0 10 0 4q�6R   �� 5?      $ 
Horizontal=�6!   .+�5@      	� -   5         	�Name$ RadioButton1��5@   &   $��
0 10 10 10q�6<   $��daily��6v   ��6P   �� *UpdateFreqCommand+��5A      �� 5B   "   $��Daily��6,   $��Center=�69   $��Center=�6V   $��0 2 0 0q�6q   ���#fff6�   5D      	� 5F      -   5        $ RadioButton2��5F   &   $��10q�6<   $��weekly��6n   ��6H   �� *UpdateFreqCommand+��5G      �� 5H   "   $��Weekly��6,   $��Center=�6:   $��Center=�6W   $��0 2 0 0q�6r   ���#fff6�   5J      	� 5L      -   5        $ RadioButton3��5L   &   $��10q�6<   $��monthly��6o   ��6I   �� *UpdateFreqCommand+��5M      �� 5N   "   $��Monthly��6,   $��Center=�6;   $��Center=�6X   $��0 2 0 0q�6s   ���#fff6�   5P      5Q      �� 5S      .+�5T      �� $K��EC:\AllMine\course_project\TodoApp\TodoApp\Resources\Images\glazy1.png��6    $	��110��6o   $��Center=�6{   $��0 6 0 0q�6�   5U      5V      5W      5X      5Y      5Z      