   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TodoApp.ViewTodoApp.View  5      5clr-namespace:TodoApp.ConverterTodoApp.Converter  5          TodoApp.View.NotifyWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:TodoApp.View     5      2local2clr-namespace:TodoApp.Converter     5      
������ $��0q�5	   P     � 	Resources  5
      &   TodoApp.Converter.ColorConverter   ColorConverter�� 5   
   %   &	          5      6$   5      .��5      �� ���#fff$��3q�6   ���#A084CF._�5   
   �  � RowDefinitions 5      �� 5      $	��37* �6    �� 5      $
��157* �6    .+�5      �� $*��$The deadline for these tasks is over��6   $
��Bold"�6D   $��16(�6V   $��Lexend)�6d   $��10,0,0,0q�6x   $��Center=�6�   $��20��6�   �� 5      $��1��6   $
��Auto=�6(   $��10,10,10,10q�6K   $��Hidden=�6`   .��5      ]� 
������ $��Center=�65   .+�5      �� ��6#   �� *	TasksDT+��5      �� 5      .R�5   "   ��   TaskItemBorderStyle#���  6)   ._�5   &   ��  �� Orientation$ 
Horizontal=�61   $	��260��6J   .+�5    *   A�   TaskItemEllipseStyle#���  6y   $��0��6�   $��30 0 0 0q�6�   ��62   �� *
CategoryId+ �� 	Converter# [  6�   �� 5!   *   $ Vertical=�65   $��1��6L   $��Center=�6\   $��
20,10,0,10q�6w   $��38��6�   .+�5"   .   �� $��18(�6O   ��68   �� *Title+6O   �� 5#   .   $��12(�6m   ���#6D6F70��68   �� *
Deadline+ �� StringFormat$ 
dd.MM.yyyy��6{   5$   +   5%   '   5&   #   5'      5)      5*      5+      5,      5-      5.      