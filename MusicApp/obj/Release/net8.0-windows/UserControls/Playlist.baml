   M S B A M L   `   `   `  ����   MusicApp$    MusicApp.UserControls.Playlist   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $��playlist��.����   �� CornerRadius$  30������  �� 
TargetType" ��.���  �� Property � �� �� Value
 ����  �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 true��. ���  � �� �#f1f1f1��  �� Binding ��  �� ElementName$ playlist��	 �� Path$	 IsActive�
 �� Value
 true.a���  � �� �#f1f1f1._��  � ColumnDefinitions �� $
��auto ��� $��* �.+�A� $��60��$��60������  �� ImageSource �� $ playlist��$	 Image��� $��1��$��Center=�$��	15 0 40 0q�.+��� $��20(�$
��Bold"����#999999���� $ playlist��$	 Title��� $��16(�$��SemiBold"����#bebebe���� $ playlist��$
	 Desc�