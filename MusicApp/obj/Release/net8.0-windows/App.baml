   M S B A M L   `   `   `  ����   MusicApp    MusicApp.App   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks     �� 	Resources     	menuTitle �� 
TargetType �� Property �� Value  
menuButton �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value  menuButtonIcon.  (MahApps.Metro.IconPacks.PackIconMaterial	 �� Path
 �� RelativeSource �� AncestorType  	titleText  playerButton  playerButtonIcon  RepeatButtonTransparent ! SliderThumb.Static.Background �� Color  SliderThumb.Static.Border !	 SliderThumb.Static.Foreground $
  SliderThumb.MouseOver.Background   SliderThumb.MouseOver.Border " SliderThumb.Pressed.Background  SliderThumb.Pressed.Border # SliderThumb.Disabled.Background  SliderThumb.Disabled.Border   SliderThumb.Track.Background  SliderThumb.Track.Border   SliderThumbHorizontalDefault � UseLayoutRounding A�Name �� Opacity  SliderThumbHorizontalTop F�Name J� SnapsToDevicePixels �� Stretch �� Triggers �� 
TargetName  SliderThumbHorizontalBottom  SliderHorizontal ��Name � RowDefinitions m�Name m� Fill m� 	Placement ]�Name ]� DecreaseRepeatButton �� DecreaseLarge ]� IncreaseRepeatButton �� IncreaseLarge ]� Thumb  n�Name! � OverridesDefaultStyle  SliderStyle1��%�  &	        &	 u     &	 F    &	     &	 c    &	     &	 V    &	     &	 (    &		 =    &	
 R    &	 g    &	 |    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    7  7  7 
 7  7  7  7  7  &	 �	    7  7  7 
 7  7  7  7  7  &	 �    7  7  7  7  7  &	 �    7 	 7  �� " ��.���  � �� �#97e6c1��  � ��$ 22(���  � ��$
 Bold"���  � ��$ 
63 30 0 15q��� " ��.���  � ��
 ���� ��  � �� �#cfcfcf��  � ��$ 50����  � ��$ 30 3 0 3q���  � ��$ 18(���  � ��$
 Bold"���  �@�FocusVisualStyle Z� ��  �@�Tag$ 	Collapsed����  � �� �� " ��.R��� #��z��$ 25��._��� $��Stretch=�$��Center=�$��35 0 0 0q� P�  �@J�IsMouseOver$
 True��. ���  � �� �#02be68��  � �� �#ffffff��  �@�Tag$ #Visible���� "  .���  � ��$ Center=���  � ��$ 0 0 23 0q���  �@ Kind$ ChevronDoubleRight=���  � ��$ Right=���  � y� �� $		 Tag�
 �� *FindAncestor+" ���� " ��.���  � �� �#393939��  � ��$ 36(���  � ��$
 Bold"��� " ��.���  � ��
 ���� ��  � �� �#ffffff��  � ��$ 40����  � ��$ 40����  � ��$	 3 0q���  � ��$ 18(���  �@�FocusVisualStyle Z� ��  �@�Tag$ 	Collapsed����  � �� �� " ��.R��� #��z��$ 50��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#00a85b��  � �� �#f0f0f0��  �@�Tag$ #Visible���� "  .���  � ��$ 17����  � ��$ 17���� " ��.���  �@�OverridesDefaultStyle$
 true����  � ��
 ���� ��  � |�$ false����  � ��$ false����  � �� �� " ��.R��� #��z��#��z��#��z���� $ 	#FFF0F0F0���� $ 	#FFACACAC���� $ 	#FFE5E5E5���� $ 	#FFDCECFC���� $ 	#FF7Eb4EA���� $ 	#FFDAECFC���� $ 	#FF569DE5���� $ 	#FFF0F0F0���� $ 	#FFD9D9D9���� $ 	#FFE7EAEA���� $ 	#FFD6D6D6���� " n�.R�� $��Center=�$
 True��$��Center=�.+�A� $
 grip��$��30��$��30��$��10�����#ffffff���� $ #97e4c1��$	 0.5Q��� " n�.R�� $��Center=�$
 True��$��Center=�.+�F� $
 grip�������    ��[ �    ��[ `�S `�S �`�S     �ا ��[ �ا ��[ ��ا ��[ �ا ���ا ����ا �������    ����[ ��[ 	8��  8�� $
 True��$
 Fill=�$��1��$
 True��$��Center=� P�  �@J�IsMouseOver$
 true��. ��� $
 grip��8   � ���� $
 grip��8   � ��P�  �@n�
IsDragging$
 true��. ��� $
 grip��8   � ���� $
 grip��8   � ��P�  � {�$ false��. ��� $
 grip��8   � ���� $
 grip��8   � ���� " n�.R�� $��Center=�$
 True��$��Center=�.+�F� $
 grip�������     � �     � `�S ��`�S ���`�S ���ا  � �ا  � ��ا  � �ا �ا ��ا     �         �  � 	8��  8�� $
 True��$
 Fill=�$��1��$
 True��$��Center=� P�  �@J�IsMouseOver$
 true��. ��� $
 grip��8   � ���� $
 grip��8   � ��P�  �@n�
IsDragging$
 true��. ��� $
 grip��8   � ���� $
 grip��8   � ��P�  � {�$ false��. ��� $
 grip��8   � ���� $
 grip��8   � ���� " ��.R��� $ border��#��z��#��z��#��z��$
 True��._��  �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick��# z��$��4��$��0,0,0,2q�$	 Top=�$��0��$y�	Collapsed=�m� $ 
BottomTick��# z��$��4��$��0,2,0,0q�$ Bottom=�$��2��$y�	Collapsed=��� $ TrackBackground�����#49d092$��0q�$	 2.5��$��4��$
��15,0q�$��1��$��center=�._��� $ Part_SelectionRange�����#dbf5e9$ 1��$
��Left=�]� $ 
PART_Track��$��1�� �� #��Z 8��   �� #��Z 8��  n� $  Thumb��$|�False��$��30��$
! True��8�� $��Center=�$��30�� P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick�� � y�$ Visible=��� $ Thumb��8   � ���� $ TrackBackground�� � ��$ 5,2,5,0q�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick�� � y�$ Visible=��� $ Thumb��8   � ���� $ TrackBackground�� � ��$ 5,0,5,2q�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick�� � y�$ Visible=��� $ 
BottomTick�� � y�$ Visible=�P�  �@��IsSelectionRangeEnabled$
 true��. ��� $ Part_SelectionRange�� � y�$ Visible=�P�  �@J�IsKeyboardFocused$
 true��. ��� $ Thumb�� � ��
 ��  ��� " ��.���  �@��IsPressAndHoldEnabled$ false����  � ��
 ���� ��  � ��
 ���� ��  � ��8   ��  � ��8  ��  �@�FocusVisualStyle Z� 