   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TodoApp.ViewTodoApp.View  5      5clr-namespace:TodoApp.ConverterTodoApp.Converter  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          TodoApp.View.TaskList   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      &localclr-namespace:TodoApp.View  5      ,local2clr-namespace:TodoApp.Converter  5      0sys&clr-namespace:System;assembly=mscorlib  5	        N� 
FontFamily$  Lexend)�5       � 	Resources 5      &   TodoApp.Converter.ColorConverter   ColorConverter)  #TodoApp.Converter.DeadlineConverter  DeadlineConverter�� 5   
   %:   &	        &	        5      6$     5      6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��540 �6   �� 5      $��* �6   .+�5   
   ��   TaskListBorderMain#���  6   $��0��6>   ._�5      �  � RowDefinitions 5      �� 5      $	��13* �6$   �� 5      $
��137* �6$   .+�5"      �� $��0��6   
������  �� Orientation$ 
Horizontal=�6C   .+�5#      �� $��Tasks for Today��6    $��Center=�67   $��30 5 0 0q�6R   $��18(�6d   $
��Bold"�6r   �� 5$      $��Center=�6   
������ ���#A084CF$��0q�6�   $��	250 5 0 0q�6�   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Refresh=�   Size 28��6W   �� *ResetFilterCommand+6�   �� 5%        RoundButtonStyle#��[ 6K   $��Center=�6u   $��10 5 0 0q�6�   ��6     $
 plus=���6�   �� *CreateTaskWinCommand+5&      �� 5(      $��1��6   $
��Auto=�6,   $��10q�6O   $��Hidden=�6[   .��5)      ]� 
������ $��Center=�69   .+�5*      �� ��6'   �� *	TasksDT+��5+      �� 5,   "   .R�5-   &   �� ��5.   *   �� 5/   .    �� 
TargetType" ��64   .�50   2   ��  �� Property � ��	 �� Value$	 1q�6T   �� 51   2    �@��CornerRadius$	 16��6Q   �� 52   2    � ��	 �#E3E3E36P   �� 53   2    � ��$	 0 0 0 8q�6K   �� 54   2    � ��	 55   6   `� 57   :   
 `� 	Converter#
 [ 6G   .1�58   >   ��  �� Path$ Deadline�6F   �� 59   >   $ IsDone�6F   �� 5:   >    �� Today �� Source# Z 6F   5<   ;   5>   3   5?   /   ._�5A   *   � $��54��6/   $	��450��6;    5B   .   �� 5C   2   $	��43* �6C   �� 5D   2   $	��20* �6C   �� 5E   2   $
��393* �6C   �� 5F   2   $	��30* �6C   .+�5I   .   ��   TaskItemCheckBoxStyle#���  6a    d� 	IsChecked 67   �� *IsDone+ �� Mode$ TwoWay=���6�   �� *!DataContext.ChangeIsDoneCommand+ �� RelativeSource ��  �� AncestorType" N���6  �� *Id+A� 5J   .     TaskItemEllipseStyle#���  6}   ��66   �� *
CategoryId+ �� 	Converter# [  6}   �� 5K   .   $ Vertical=�69   $��2��6P   $��Center=�6`   $��20,0,0,0q�6{   $��38��6�   .+�5L   2   �� $��18(�6S   ��6<   �� *Title+6S   �� 5M   2   $��12(�6q   ���#6D6F70��6<   �� *
Deadline+ �� StringFormat$ 
dd.MM.yyyy��6   5N   /   �� 5O   .   -   5          TaskItemButtonStyle#���  5O   5   ��6d     $ DotsVertical=� 306�   5P   +   5Q   '   5R   #   5T      5U      5V      5W      5X      �� 5Z   
   #���  6   $��1��6>   ._�5[      �  5\      �� 5]      $	��13* �6$   �� 5^      $
��137* �6$   .+�5a      �� $��0��6   
������ $ 
Horizontal=�6C   .+�5b      �� $��
Categories��6    $��Center=�62   $��40 5 0 0q�6M   $��18(�6_   $
��Bold"�6m   �� 5c      #��[ 6K   $��Center=�6�   $��	210 5 0 0q�6�   ��6     $
 plus=���6u   �� *CreateCategoryWinCommand+6�   5d      �� 5f      $��1��6   $
��Auto=�6,   $��10q�6O   $��Hidden=�6[   .��5g      ]� $	��340��6    .+�5h      �� ��6'   �� *CategoriesDT+��5i      �� 5j   "   .R�5k   &   ��  �� CornerRadius$ 16��6-   $��0q�6?   $��0 0 0 8q�6S   ��6d   �� *Color+._�5l   *   � $	��140��6/    5m   2   �� 5n   6   $	��40* �6D   �� 5o   6   $	��37* �6D   .+�5r   2   � $��0��67   $��10q�6D    5s   6   �� 5t   :   $��* �6K   �� 5u   :   $��* �6K   .+�5x   6   �� $��Center=�6W   $��18(�6r   $��10 0 0 0q�6�   
�������$��0��6�   ��6@   �� *Title+6�   �� 5y   6   $��1��6A   $ 
Horizontal=�6Q   $��Right=�6j   $��0 0 10 0q�6�   .+�5z   >   �� $��Right=�6  $��Center=�69  
�������$��0q�6g  
������ ��6E     $ FilterVariant=� 30��6�   �� * DataContext.FilterTasksCommand+ �� " N���6�   �� *
CategoryId+6{  �� 5{   >   $��Right=�6!  $��Center=�6=  
�������$��0q�6k  
������ $��5 0 0 0q�6�  ��6E     $ TrashCanOutline=� 30��6�   �� *#!DataContext.DeleteCategoryCommand+ �� " N���6�   �� *
CategoryId+6�  5|   7   5}   2   �� 5~   1   $��1��6<   $��0 10 0 0q�6I   .+�5   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��Done: ��6D   $��16(�6R   
�������$��20 0 0 0q�6s   �� 5�   :   $��16(�6a   
���������6D   �� *CountOfDone+6o   �� 5�   :   $��Tasks: ��6D   $��16(�6S   
�������$��30 0 0 0q�6u   �� 5�   :   $��16(�6b   
���������6D   �� *CountOfTasks+6p   5�   7   � 5�   6   $��12��6�   $
��20 6q�6�     CustomProgressBarStyle#��[ 6�    � Value 6B   �� *CountOfDone+ � Maximum 6`   �� *CountOfTasks+6�   5�   0   5�   ,   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      