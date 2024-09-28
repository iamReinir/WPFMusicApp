using Microsoft.AspNetCore.SignalR;

namespace PRN_Final.Hubs
{
  public class MusicHub : Hub
  {
    public async Task NotifyPlaylistUpdate(string trackId, string trackTitle)
    {
      await Clients.All.SendAsync("ReceivePlaylistUpdate", trackId, trackTitle);
    }
  }
}