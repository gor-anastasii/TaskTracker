   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TodoAppTodoApp  5   	   "    TodoApp.ViewModel.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:TodoApp  5   	     � Title$  
MainWindow��5	      $	��670��6#   $
��1150��60    � WindowStyle$
 None=�6=    � WindowStartupLocation$ CenterScreen=�6P    � 
ResizeMode$ NoResize=�6u   $��Lexend)�6�   $��20(�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��630* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $	��93* �6#   �� 5      $
��482* �6#   .+�5      �� $��0��6      	MenuPanel#���   6)   .+�5      �� -   5         ��Name$ DashbordPage��5        MenuBtn#���  6/   .��5      ��  �� Orientation$ 
Horizontal=�6!   $��25 0 0 0q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
HomeCircle=�63     MenuIcon#���  6E   �� 5      $��	DashBoard��6$   $��20(�65   $��Center=�6C   5      5      �� 5      -   5        $ 	TasksPage��5      #���  6,   .��5      �� $ 
Horizontal=�6!   $��25 0 0 0q�6:   .+�5        $ ViewGridAdd=�63   #���  6F   �� 5      $��Tasks��6$   $��20(�61   $��Center=�6?   5       5!      �� 5"      -   5        $ AnalyticPage��5"      #���  60   .��5#      �� $ 
Horizontal=�6!   $��25 0 0 0q�6:   .+�5$        $ GoogleAnalytics=�63   #���  6J   �� 5%      $��Analytic��6$   $��20(�64   $��Center=�6B   5&      5'      5(       � 5*      -   5        	  �Name$	 MainPage��5*      $��1��6&     
FrameStyle#���  66   
  � NavigationUIVisibility$
 Hidden=�6[   5+      �� 5-   
   $ 
Horizontal=�6     MainStackPanel#���  6.   .+�5.      �� $��TaskTracker��6   ���#A084CF$��24(�6@   $
��Bold"�6N   $��25 5 0 0q�6`   � 50      -   5        $��	900 0 0 0q�50       51      �� 52      $��2* �6$   �� 53      $��3* �6$    55      �� 56      $	��17* �6'   �� 57      $	��13* �6'   .+�59        -   5          Name$ Notify��59   *   $ BellOutline=�6:     Icon#���  6M   $��40��6m   $��30��6y   $��0��6�   $��0��6�   $��2��6�   $��2��6�   A� 5:      -   5         A�Name$ 	NotifyEll��5:      
������ $��1��6@   $��0��6P   $��0 3 5 0q�6]   5;        5=      -   5        $ About��5=   &   $ About=�65   #���  6n   $��0 0 0 0q�6�   $��40��6�   $��30��6�     5>      -	   5        $
 Exit��5>   &   $ 	ExitToApp=�64   #���  6n   $��40��6�   $��30��6�   5?      5B      5C      