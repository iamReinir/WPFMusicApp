   M S B A M L   `   `   `  ����   MusicApp'    !MusicApp.UserControls.PopularSong   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $��popularSong��.���� -     ��Name$  border�� �� CornerRadius$ 30�� �� Padding$ 10q�$	��0 7q�����  �� 
TargetType" ��.���  �� Property � �� �� Value �#ecf4f0 �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#03bf69�� 	 �� Binding	 �� 
 �� ElementName$
 popularSong�� �� Path$ IsActive� �� Value True.a���  � �� �#03bf69 J� InputBindings d�  d� MouseAction$ LeftDoubleClicke� �� Command$  ��._��  � ColumnDefinitions �� $
��auto ��� $	��180 ��� $��* �.+�A� $��40��$��40��$��0 0 20 0q�����  �� ImageSource �� $
 popularSong��$ Image��� $��16(�$��SemiBold"�$��1��$��Center=�$��0 0 0 2q����� $
 popularSong��$ Title����� " ��.���  � �� �#787c7a �� 	 �� $
 border��$ IsMouseOver� True�� 	 �� $
 popularSong��$ IsActive� True�� $��14(�$��SemiBold"�$��2��$��Center=�$��0 0 20 2q�$��Right=����� $
 popularSong��$
 Time�