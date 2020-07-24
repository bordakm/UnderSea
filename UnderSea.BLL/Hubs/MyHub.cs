using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace UnderSea.BLL.Hubs
{
    public class MyHub : Hub
    {
        //public Task SendMessage(string user, string message)
        //{
        //    return Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
}
