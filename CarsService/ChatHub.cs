using CarsCore;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsPresentationLayer
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            if (message.StartsWith(Constants.CommandStartSign))
            {
                message = message[1..];
                var splitted = message.Split(Constants.CommandElementSeparator);
                bool result = false;
                switch (splitted[0].ToLower())
                {
                    case Constants.Commands.PrivateMessage:
                        if (splitted.Length > 2)
                        {
                            var id = splitted[1];
                            var personalMessage = string.Join(Constants.CommandElementSeparator, splitted[2..]);
                            await Clients.Client(id).SendAsync("ReceiveMessage", Context.ConnectionId, personalMessage);
                            result = true;
                        }
                        break;
                    case Constants.Commands.Help:

                        break;
                }
            }
            else
            {
                await Clients.Others.SendAsync("ReceiveMessage", user, message);
            }
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Others.SendAsync("ReceiveMessage", Constants.ServerMessageSenderName, $"User {Context.ConnectionId} connected!");
            await Clients.Caller.SendAsync("ReceiveMessage", Constants.ServerMessageSenderName, $"Greetings newcomer!");
        }
    }
}
