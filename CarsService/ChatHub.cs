using CarsBuisnessLayer;
using CarsBuisnessLayer.Commands;
using CarsCore;
using CarsCore.Models.ChatModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsPresentationLayer
{
    public class ChatHub : Hub
    {
        private static IList<ChatUserSettings> UserSettings;
        private readonly ILogger<ChatHub> _logger;

        static ChatHub()
        {
            UserSettings = new List<ChatUserSettings>();
        }

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public async Task SendMessage(string message)
        {
            Command command = CommandHelper.CreateCommand(message);

            await command.Execute(this, UserSettings);
        }

        public override async Task OnConnectedAsync()
        {
            UserSettings.Add(
                new ChatUserSettings
                {
                    ClientId = Context.ConnectionId
                });

            _logger.LogDebug(UserSettings.Count.ToString());

            await Clients.Others.SendAsync(Constants.ClientMethods.ReceiveMessage,
                CreateSystemMessage($"User {Context.ConnectionId} connected!"));
            await Clients.Caller.SendAsync(Constants.ClientMethods.ReceiveMessage,
               CreateSystemMessage($"Greetings newcomer!"));
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserSettings.Remove(
                new ChatUserSettings
                {
                    ClientId = Context.ConnectionId
                });
            _logger.LogDebug(UserSettings.Count.ToString());

            return base.OnDisconnectedAsync(exception);
        }

        private ChatMessage CreateSystemMessage(string message)
            => new()
            {
                Sender = Constants.ServerMessageSenderName,
                MessageColor = ConsoleColor.Blue,
                Text = message
            };
    }
}