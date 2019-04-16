using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Models;

namespace Server.Hubs
{
    public class PlayerHub : Hub
    {
        public async Task Update(Player player)
        {
            await Clients.All.SendAsync("update", player);
        }
    }
}