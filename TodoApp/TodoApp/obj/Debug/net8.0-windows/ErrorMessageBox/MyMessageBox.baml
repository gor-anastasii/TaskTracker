   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TodoApp.ErrorMessageBoxTodoApp.ErrorMessageBox  5   	   *    $TodoApp.ErrorMessageBox.MyMessageBox   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:TodoApp.ErrorMessageBox  5   	     � Title$  MyMessageBox��5	   	   $	��180��6    � WindowStartupLocation$ CenterScreen=�6,    � WindowStyle$
 None=�6Q    � 
ResizeMode$ NoResize=�6d   $	��290��6z   ���#B399DE
���   �$��2q�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $��27 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   ���#8E3FB4.+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ErrorOutline=�6&   $��10 0 0 0q�6:   $��25��6L   $��25��6W   $��Center=�6c   $��Medium"�6~   ���	#FFE9F2F36�   5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� -   5        $��MessageContainer��5      $��Center=�60   $��Light"�6K   $��Center=�6^   $
��Wrap=�6{   $��Lexend)�6�   $��18(�6�   $��10q�6�   
�������6�   5      �� 5      -   5        $��ButtonContainer��5      $��2��6-    �� Orientation$ 
Horizontal=�6:   $��Right=�5      $��10q�6-    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value   PrimaryHueLightBrush " PrimaryHueLightForegroundBrush��%2  '��       �� 5      " ��6   .�5      �� 	 � ��

 �����63   �� 5      	 � ��$
 Medium"�63   �� 5      	 � ��#
 �   64   �� 5      	 � ��#
 �  63   �� 5      	 � ��$
 25��6/   �� 5       	 � ��$
 65��61   �� 5!      	 � ��$
 10,0,0,0q�6/   5"      5#      5$      5%      5&      