using Microsoft.AspNetCore.SignalR;
using sockets.DataService;
using sockets.Models;

namespace sockets.Hubs
{
    public class ChatHub: Hub
    {
        private readonly SharedDb _shared;
        public ChatHub(SharedDb shared) => _shared = shared;

        //public async Task JoinChat(UserConnection connection)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", "Admin", $"{connection.Username} has joined.");
        //}

        //public async Task JoinSpecificChatRoom(UserConnection connection)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatRoom);
        //    _shared.connections[Context.ConnectionId] = connection;
        //    await Clients.Group(connection.ChatRoom).SendAsync("JoinSpecificChatRoom", "Admin", $"{connection.Username} has joined chat room {connection.ChatRoom}.");
        //}

        //public async Task SendMessagesWithFunctionName(string message)
        //{
        //    if(_shared.connections.TryGetValue(Context.ConnectionId, out UserConnection connection))
        //    {
        //        await Clients.Groups(connection.ChatRoom)
        //                      .SendAsync("ReceiveSpecificMessage", connection.Username, message);
        //    }
        //}
    }
}
