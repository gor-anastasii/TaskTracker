   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TodoApp.ViewTodoApp.View  5      5clr-namespace:TodoApp.ConverterTodoApp.Converter  5          TodoApp.View.Analytic   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      &localclr-namespace:TodoApp.View  5      ,local2clr-namespace:TodoApp.Converter  5        N� 
FontFamily$  Lexend)�5
   0    N� Title$ Analytic��5       � 	Resources 5      &   TodoApp.Converter.ColorConverter   ColorConverter�� 5   
   %   &	          5      6$   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��243* �6   �� 5      $
��737* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $	��31* �6    �� 5      $	��33* �6    .+�5      �� $��0��6    �� CornerRadius$ 20��6"   ���#fff$��10q�6F   ._�5       �� $T��NC:\AllMine\course_project\test\TodoApp\TodoApp\Resources\Images\illustrate.png��6   $��16q�6p   5!      �� 5#      $��1��6   $ 20��6"   ���#fff$��10q�6F   ._�5$      �  5%      �� 5&      $	��49* �6(   �� 5'      $
��176* �6(   �� 5(      $	��85* �6(   .+�5+      �� $��Select the Date��6    $��18(�67   $
��Bold"�6E   $��Center=�6W   $��20,0,0,0q�6r   $��22��6�   &   System.Windows.Controls.Calendar  5,      $��1��6      SelectedDate 6,   �� *SelectedDate+ �� Mode$ TwoWay=��� 5-      $��
Show Tasks��6   $��2��62   $��20 10 20 30q�6?   ��6T   �� *ShowTaskOfDateCommand+��5.      �� 5/       �� 
TargetType" ��6$   .�50   "   �� 	 �� Property	 � ��
 �� Value
 �#A084CF6?   �� 51   "   	 � ��

 ���� 6@   �� 52   "   	 � ��$
 0q�6D   �� 53   "   	 � ��

 �����6?   �� 54   "   	 � ��$
 16(�6=   �� 55   "   	 � {�$
 False��6>   �� 56   "   	 � ��
 57   &   �� 58   *    �� 
TargetType" ��6:   .R�59   .   � .+�5:   2   �� #��z��69   #��z��5;      #��z��5<      $ 6��5=      ._�5>   6   �� $��Center=�6G   $��Center=�5?   ,   5@   3   5A   /   5B   +   5D   #    �� Triggers 5E   "   �� 5F   &    �� Binding 62   �� *IsDateSelected+ �� Value True6U   .a�5G   *   �� 	 � {�$

 True��6F   5H   '   5J      5L      5M      5N      5P      � 5R   
   $��1��6    5S      �� 5T      $	��86* �6    �� 5U      $
��227* �6    �� 5V      $
��327* �6    .+�5Y      �� $��0��6   $ 20��6"   ���#fff$��10q�6F   ._�5Z      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5[      �� $(��"Select a period to view statistics��6    $��18(�6J   $
��Bold"�6X   $��20 0 0 0q�6j   $��Center=�6|   �� 5\        CustomAnalyticButtonStyle#��[ 6   $	��Day��6P   $��90��6^   $��30��6i   $��20 0 0 0q�6u   ��6�   �� *DayPeriodCommand+�� 5]      #��[ 6   $
��Week��6P   $��90��6_   $��30��6j   $��20 0 0 0q�6v   ��6�   �� *WeekPeriodCommand+�� 5^      #��[ 6   $��Month��6P   $��90��6`   $��30��6k   $��20 0 0 0q�6w   ��6�   �� *MonthPeriodCommand+5_      5`      �� 5b      $��1��6   $ 20��6"   ���#fff$��10q�6F   ._�5c      �  5d      �� 5e      $	��58* �6(   �� 5f      $
��149* �6(   .+�5i      �� $��20,0,0,0q�6!   $��Center=�63   $ 
Horizontal=�6N   $��22��6g   .+�5j      �� $)��#Statistics for the selected period ��6$   $��18(�6O   $
��Bold"�6]   $��Center=�6o   �� 5k      $��18(�6E   $
��Bold"�6S   $��Center=�6e   ���#A084CF$��	Underline{�6�   ��6$   �� *PeriodStatistic+6�   5l      � 5n      $��1��6    5o      �� 5p      $��* �6/   �� 5q      $��* �6/   .+�5t      �� $ Vertical=�6%   $��0��6<   $��20q�6L   .+�5u      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5v   "   �� $��	Tasks:   ��6,   $��16(�6=   �� 5w   "   $��16(�6K   $
��Bold"�6Y   ���#A084CF$��	Underline{�6�   ��6,   �� *TaskStatistic+6�   5x      �� 5y      $ 
Horizontal=�6)   $��Center=�6B   $��	0 20 0 10q�6]   .+�5z   "   �� $��Completed Tasks:   ��6,   $��16(�6G   �� 5{   "   $��16(�6O   $
��Bold"�6]   ���#A084CF$��	Underline{�6�   ��6,   �� *DoneTaskStatistic+6�   5|      �� 5}      $ 
Horizontal=�6)   $��Center=�6B   $
��0 10q�6]   .+�5~   "   �� $��Uncompleted Tasks:   ��6,   $��16(�6I   �� 5   "   $��16(�6R   $
��Bold"�6`   ���#A084CF$��	Underline{�6�   ��6,   �� *NotDoneTaskStatistic+6�   5�      5�      �� 5�      $ Vertical=�6%   $��1��6<   $��20q�6L   .+�5�      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� $��Categories:   ��6,   $��16(�6B   �� 5�   "   $��16(�6J   $
��Bold"�6X   ���#A084CF$��	Underline{�6   ��6,   �� *CatStatistic+6   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   $��	0 20 0 10q�6]   .+�5�   "   �� $��Deleted tasks:   ��6,   $��16(�6E   �� 5�   "   $��16(�6I   $
��Bold"�6W   ���#A084CF$��	Underline{�6~   ��6,   �� *TaskDeleted+6~   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   $
��0 10q�6]   .+�5�   "   �� $��Deleted categories:   ��6,   $��16(�6J   �� 5�   "   $��16(�6H   $
��Bold"�6V   ���#A084CF$��	Underline{�6}   ��6,   �� *
CatDeleted+6}   5�      5�      5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $
��499* �6'   �� 5�      $
��238* �6'   .+�5�      �� $��0��6   $ 20��6)   ���#fff$��10q�6M   ._�5�      �  5�      �� 5�      $	��61* �6,   �� 5�      $
��246* �6,   .+�5�      �� $��20,0,0,0q�6%   $��Center=�67   $ 
Horizontal=�6R   $��21��6k   .+�5�      �� $"��Tasks for the selected date ��6(   $��18(�6L   $
��Bold"�6Z   $��Center=�6l   �� 5�      $��18(�6g   $
��Bold"�6u   $��Center=�6�   ���#A084CF$��	Underline{�6�   ��6(   �� *SelectedDateOfTask+ �� StringFormat$ 
dd.MM.yyyy��6�   5�      �� 5�      $��1��6'   $
��Auto=�64   $��10,10,10,10q�6W   $��Hidden=�6l   .��5�      ]� 
������ $��Center=�6A   .+�5�   "   �� ��6/   �� *
TaskOfDate+��5�   &   �� 5�   *   .R�5�   .   ��   TaskItemBorderStyle#���  65   ._�5�   2   �� $ 
Horizontal=�6=   $	��400��6V   .+�5�   6   A�   TaskItemEllipseStyle#���  6�   $��0��6�   $��30 0 0 0q�6�   ��6>   �� *
CategoryId+ �� 	Converter# [  6�   �� 5�   6   $ Vertical=�6A   $��1��6X   $��Center=�6h   $��
20,10,0,10q�6�   $��38��6�   .+�5�   :   �� $��18(�6[   ��6D   �� *Title+6[   �� 5�   :   $��12(�6y   ���#6D6F70��6D   �� *
Deadline+$ 
dd.MM.yyyy��6�   5�   7   5�   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      �� 5�      $��1��6   $ 20��6)   ���#fff$��10q�6M   ._�5�      �  5�      �� 5�      $	��75* �6,   �� 5�      $
��232* �6,   .+�5�      �� $��20,0,0,0q�6%   $��Center=�67   $ Vertical=�6R   $��44��6i   .+�5�      �� $��Data for this date ��6(   $��18(�6C   $
��Bold"�6Q   $��Center=�6c   �� 5�      $��18(�6g   $
��Bold"�6u   $��Center=�6�   ���#A084CF$��	Underline{�6�   ��6(   �� *SelectedDateOfTask+$ 
dd.MM.yyyy��6�   5�      �� 5�      $��1��6%   $ Vertical=�62   $��20,20,20,20q�6I   .+�5�      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� $��	Tasks:   ��6,   $��16(�6=   $
��Bold"�6K   �� 5�   "   $��16(�6F   $
��Bold"�6T   ���#A084CF$��	Underline{�6{   ��6,   �� *
DateTask+6{   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   $��	0 20 0 10q�6]   .+�5�   "   �� $��Completed Tasks:   ��6,   $��16(�6G   $
��Bold"�6U   �� 5�   "   $��16(�6J   $
��Bold"�6X   ���#A084CF$��	Underline{�6   ��6,   �� *DateDoneTask+6   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   $
��0 10q�6]   .+�5�   "   �� $��Uncompleted Tasks:   ��6,   $��16(�6I   $
��Bold"�6W   �� 5�   "   $��16(�6M   $
��Bold"�6[   ���#A084CF$��	Underline{�6�   ��6,   �� *DateNotDoneTask+6�   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   $
��0 10q�6]   .+�5�   "   �� $��Period Tasks:   ��6,   $��16(�6D   $
��Bold"�6R   �� 5�   "   $��16(�6L   $
��Bold"�6Z   ���#A084CF$��	Underline{�6�   ��6,   �� *DatePeriodTask+6�   5�      5�      5�      5�      5�      5�      5�      5�      