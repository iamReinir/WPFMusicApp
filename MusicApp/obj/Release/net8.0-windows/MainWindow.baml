   M S B A M L   `   `   `  ���� C  ?MusicApp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MusicApp.UserControlsMusicApp.UserControls      MusicApp.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   .uc#clr-namespace:MusicApp.UserControls   $	��700��$
��1050��  � 
ResizeMode$  NoResize=� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � WindowStartupLocation$ CenterScreen=�
������  � DataContext ��  �� RelativeSource ��  �� Mode$
 Self=� � 	Resources    NoMouseOverButtonTemplate �� 
TargetType	 �� Triggers
 P� Property P� Value �� Value �� Property��%�   &	        �� " ��.R��� #��z��#��z��#��z��._��� #��z��#��z��$��	-60 0 0 0q�	 P� 
 � {�$ False��. ��� # Z� � ���� # Z
� � ��.���� -   
������� �� CornerRadius$ 40��._��� .+���  �� Orientation$ 
Horizontal=�$��
20 0 20 10q�.+��� $��0��$��
40 60 10 0q�.+�%   MusicApp.UserControls.SearchBox  -     Name$ 	txtSearch���� $
��Home��  	titleText#��[ �� $ 20��$��	0 20 0 0 q����� .���  � Color$ #30ad9a�� � Offset$ 0Q�� $ #18c274��$ 1Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 0Q�   Opacity$	 0.4Q�   Color$ #1fae7e��._�� .+���  J� Opacity$
 0.07Q�$ 20������  �� ImageSource$ /Images/p2.jpg���� $��30q�.+��� $��Search Result��
�������$��26(�$
��Bold"��� -   $��
listResult��$��0q�$	��300��$	��500��$
}�True��$��Hidden=����� .��� $ #30ad9a��$ 0Q�� $ #18c274��$ 1Q����� .R��� -   #��[  ���	#00000000$	��450��$��0q�
 � Tag �� *Id+.��$   MusicApp.UserControls.SongItem     Image �� *Thumb+   Path �� *Path+	   Id �� *Id+   Title �� *Title+   Channel �� *Author+�� $	��400��.+��� $ 
Horizontal=�$��Right=�.+��� -     playerButton#��[ .��.  (MahApps.Metro.IconPacks.PackIconMaterial      Kind$  WindowMinimize=�  playerButtonIcon#��[ ���#03bf69�� -   #��[ .��  $  Close=�#��[ ���#03bf69�� $��2��$ 	40 40 0 0��$��0 22 0 0q�._��� $��	10 5 10 0q�.+��� $��Playlist��#��[ $��0 0 0 10q�$��28(��� -   $��listHistory��$��0q�$	��500��$	��500��$
}�True��$��Hidden=����� *list+���� .R��� $ 
Horizontal=�.+�'   !MusicApp.UserControls.PopularSong  !   Title! �� *Data.Infomation.Title+"   Image" �� *%#Data.Infomation.Thumbnails.High.Url+#   IsActive# �� *Data.IsPlaying+�� -   #��[  �� *	Data.Id+.��  #��[ ���#03bf69  �� *Kind+�� -	   #��[  �� *	Data.Id+.��  $  Delete=�#��[ 
���  ���� $��1��$��1��$��2�����#03bf69$ 20 20 20 20��$��40 0 0 0q�$	��970��._��� $ 
Horizontal=�$
}�True��.+�A� $��60��$��60��$��30 0 0 0q����� -
   imgThumbnail���� $��Center=�$��	20 0 30 0q�$	��600��.+��� -   $ ��Name$$ txtCurrentTitle��$��Music��
�������$��22(�$
��Bold"�$��NoWrap=��� -   $$ txtCurrentArtist��$��Name Artist�����#9ae5c3$��18(�$��SemiBold"��� $ 
Horizontal=�$
��Left=�.+�r� -   $��mediaElement��% r� LoadedBehavior$% Manual=�& r� UnloadedBehavior$
& Stop=�$��0��$��0���� -   #��[ .��  $  SkipPrevious=�#��[ �� -   #��[ .��  -   $��btnPauseIcon��$
  Play=�#��[ �� -   #��[ .��  $  SkipNext=�#��[ �� -   #��[ .��  -   $��btnRepeatIcon��$  Repeat=�#��[ �� -   #��[ .��  -   $��btnShuffleIcon��$  ShuffleDisabled=�#��[ 