   M S B A M L   `   `   `  ����  MusicApp'    !MusicApp.UserControls.PopularSong   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5        $��popularSong��5      .��5      �� -   5          ��Name$  border��5       �� CornerRadius$ 30��6    �� Padding$ 10q�6/   $	��0 7q�6<   ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#ecf4f06/    �� Triggers 5
      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��65   . �5      ��  � �� �#03bf6967   5      �� 5      	 �� Binding	 6"   �� 
 �� ElementName$
 popularSong�� �� Path$ IsActive� �� Value True6\   .a�5      ��  � �� �#03bf6967   5      5       J� InputBindings 5   
   d� 5       d� MouseAction$ LeftDoubleClicke�6    �� Command$  ��69   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $	��180 �6#   �� 5      $��* �6#   .+�5!      A� $��40��6   $��40��6!   $��0 0 20 0q�6-   ��5"      �� 5#       �� ImageSource 6!   �� $
 popularSong��$ Image�5%      �� 5'      $��16(�6L   $��SemiBold"�6Z   $��1��6p   $��Center=�6�   $��0 0 0 2q�6�   ��6   �� $
 popularSong��$ Title���5(      �� 5)      " ��6   .�5*      ��  � �� �#787c7a67    5,      �� 5-      	 6*   �� $
 border��$ IsMouseOver� True6c   5/      �� 51      	 6*   �� $
 popularSong��$ IsActive� True6e   53      55      57      �� 59      $��14(�6K   $��SemiBold"�6Y   $��2��6o   $��Center=�6   $��0 0 20 2q�6�   $��Right=�6�   ��6   �� $
 popularSong��$
 Time�5;      5<      5B      5C      