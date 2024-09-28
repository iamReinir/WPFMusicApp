using YoutubeRec;
using WMPLib;

MusicFileManager manager = new("AIzaSyCd8NHz1byXfa2c58XVYXpY9ZJzqokgAyw");
Console.WriteLine("Search youtube:");
await manager.StartSearch(Console.ReadLine() ?? "inabakumori relayouter",5);
await manager.StartDownload();
WindowsMediaPlayer player = new WindowsMediaPlayer();
player.URL = manager.FileList.First(item => item.isAvailable()).Path;
player.controls.play();
Console.WriteLine("Playing... enter (s) to stop:");
while (Console.ReadLine() != "s") ;