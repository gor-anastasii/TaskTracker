   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TodoApp.ViewTodoApp.View  5   	       TodoApp.View.EditTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:TodoApp.View  5   	     � Title$  EditTask��5	   	   $	��340��6   $	��450��6'    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�6   $��Lexend)�62    � AllowsTransparency$
 True��6F   
������ .��5      �� ���#A084CF �� CornerRadius$ 20��6"   ._�5   
   � $��20q�6    � RowDefinitions 5      �� 5      $	��27* �6    �� 5      $
��248* �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $��Task Details��6   $��Center=�60   $��16(�6K   $��Medium"�6Y   ���#fff$��20 0 0 0q�6   �� 5      -   5           RoundButtonStyleCreateTask#���   5   H   $��	270 0 0 0q�6}   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�6�   5      �� 5      $��1��6   $
��20 0q�6&   .+�5      �� 
�������$��16(�6/   $��Title *��6=   �� 5      -   5        	 ��Name$	 TitleBox��5   B   $	��0 6q�6U   
������ 
�������$��0 0 0 2q�6�   
���������6   �� *	TaskTitle+
 �� Mode$
 TwoWay=�6�   �� 5      
�������$��16(�6/   $��Description��6=   $��0 4 0 0q�6P   �� 5      $
��Auto=�6   .��5      �� -   5        $	 DescriptionBox��5   E   $	��0 6q�6]   
������ 
�������$��0 0 0 2q�6�   
���������6   �� *
TaskDesc+$
 TwoWay=�6�   5      �� 5       
�������$��16(�6/   $��Deadline��6=   $��0 4 0 0q�6M   �� 5!      $ 
Horizontal=�6   .+�5"      (  "System.Windows.Controls.DatePicker  -   5          Name$ DeadlineBox��5"   T   $	��220��6i   $��0 4 0 0q�6u      SelectedDate 6!   �� *TaskDeadline+$
 TwoWay=�5#      5$      �� 5&      
�������$��16(�6/   $��Category��6=   $��0 10 0 4q�6M   �� 5'      -   5         ��Name$ CategoryBox��5'   `   $��20��6    �� SelectedValue 6(   �� *SelectedCategory+$
 TwoWay=���6u   �� *
Categories+�� 5)      $ 
Horizontal=�6   $��	0 30 0 20q�66   .+�5*      �� $��Save Changes��6   $	��120��6X   $��5q�6d   $��0 0 10 0q�6p   ���#fff$��30��6�   ���#A084CF  CustomAnalyticButtonStyle2#��[ 6�   ��64   �� *SaveEditCommand+6�   �� 5+      $��Delete Task��6   $	��120��6Y   $��5q�6e   ���#fff$��30��6�   ���#A084CF#��[ 6�   ��63   �� *DeleteTaskCommand+6�   5,      5-      5.      5/      50      