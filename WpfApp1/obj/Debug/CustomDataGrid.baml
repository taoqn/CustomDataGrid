   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.CustomDataGrid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          %� IsVirtualizing  .   � 	Resources 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow   TemplateDataGridRow J� SnapsToDevicePixels?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions:  4System.Windows.Controls.Primitives.DataGridRowHeader$   SelectiveScrollingOrientation?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility  HeaderTemplate	 d�Name
 � Cursor �� 
TargetType �� Property �� Value'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty �� KeyTime �� Value g� Duration R� KeyTime R� Value	  System.Windows.Visibility ��Name F�Name �� Stretch��%�  &	        &	 �    �� 5   
   "  6   .R�5      �� #��z��6   #��z��5      #��z��5	       . ._�5         5      �� 5      $
��Auto �6+   �� 5      $��* �6+    5      �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5        $��0��6(   $��0��6J   $ Vertical=�5   (     5      $��1��6-   $��0��6O   #��z 5   -   # z 5   -     5      -   5        $��1��5   /   $��1��6Q   #y�z 5   /   5      5      5      �� 5   
   .R�5       d� $	 RowHeaderToggleButton��6   -   5        $

 Hand��5    ^   $��15��6l   $��15��6w   ��5!      �� 5"      " d�6   .�5#      ��  � ��$ 3q�64   �� 5$       � �� 5%      �� 5&   "   " d�62   .R�5'   &   �  5(   *     5)   .   CommonStates��. 5*   2     
Normal��6>     5+   2   	MouseOver��. 5,   6   �� .��5-   :   �� $ DefaultPath��6W   $) #(Path.Fill).(SolidColorBrush.Color)�6{   .g�5.   >   �� $ 0:0:0.2��6R   $ #AA0000��6d   5/   ;   50   7   51   3     52   2   Pressed��6>     53   2   Disabled��6>   54   /     55   .   CheckStates��. 56   2     Checked��. 57   6   �� .��58   :   T� $ 0D�6X   $ DefaultPath��6e   $ 
Visibility�6�   ..�59   >   i� $ 0��6U    5:   B   	 5;   F   	Collapsed=�6\   5=   ?   5>   ;   T� 5?   :   $ 0D�6X   $ CheckedPath��6e   $ 
Visibility�6�   ..�5@   >   i� $ 0��6U    5A   B   	 5B   F   Visible=�6Z   5D   ?   5E   ;   �� 5F   :   $ CheckedPath��6W   $) #(Path.Fill).(SolidColorBrush.Color)�6{   .g�5G   >   �� $ 0:0:0.2��6R   $ 	#CCAA0000��6d   5H   ;   5I   7   5J   3     5K   2   	Unchecked��6>   5L   /   .+�5N   *   �� $ contentPresenter��6;   #��z��6U   #��z��6x   #��z��6�   #��z��6�   #��z��6  F� 5O   *   $ DefaultPath��6/   $	��Top=�6D   "����        р�� ��j �    ��� 	
�������$
 Fill=�6�   F� 5P   *   $ CheckedPath��6/   $	��Top=�6D   "����        р��     ���j ��� 	
�������$
 Fill=�6�   $y�	Collapsed=�6�   5Q   '   5R   #   5T      5U      5W      5X      5Y      5Z      