using CarsCore;
using CarsCore.Models.ChatModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Commands
{
    public abstract class Command
    {
        protected MessageTarget _target;
        protected string[] _args;
        protected abstract int? MinArgsCount { get; }
        protected virtual MessageTarget GetMessageTarget()
            => _target;

        public Command(string[] args)
        {
            _target = MessageTarget.Self;
            _args = args;
        }

        public async Task Execute(
            Hub hub,
            IList<ChatUserSettings> userSettings)
        {
            CommandOutput commandOutput = null;
            if ((MinArgsCount != null && _args.Length >= MinArgsCount)
                || (MinArgsCount == null))
            {
                commandOutput = CreateCommandOutput(
                    hub.Context.ConnectionId,
                    userSettings);
            }
            if (commandOutput == null || (commandOutput.IgnoreList.Contains(commandOutput.TargetId)))
            {
                _target = MessageTarget.Self;
                commandOutput = new CommandOutput
                {
                    ClientMethod = Constants.ClientMethods.ReceiveMessage,
                    Message = CreateSystemMessage("Invalid command!")
                };
            }
            await SendCommandToTarget(hub, commandOutput);
        }

        private async Task SendCommandToTarget(Hub hub, CommandOutput commandOutput)
        {
            switch (GetMessageTarget())
            {
                case MessageTarget.All:
                    await hub.Clients.AllExcept(
                        (IReadOnlyList<string>)commandOutput.IgnoreList)
                        .SendAsync(commandOutput.ClientMethod, commandOutput.Message);
                    break;
                case MessageTarget.Self:
                    await hub.Clients.Caller.SendAsync(
                       commandOutput.ClientMethod, commandOutput.Message);
                    break;
                case MessageTarget.Personal:
                    await hub.Clients.Client(commandOutput.TargetId)
                        .SendAsync(commandOutput.ClientMethod, commandOutput.Message);
                    break;
            }
        }

        protected abstract CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings);

        protected ChatMessage CreateSystemMessage(string message)
            => new()
            {
                Sender = Constants.ServerMessageSenderName,
                MessageColor = ConsoleColor.Blue,
                Text = message
            };
    }
}
