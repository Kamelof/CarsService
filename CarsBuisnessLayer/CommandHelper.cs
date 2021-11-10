using CarsBuisnessLayer.Commands;
using CarsCore;
using System;

namespace CarsBuisnessLayer
{
    public class CommandHelper
    {
        public static Command CreateCommand(string message)
        {
            Command result;
            if (message.StartsWith(Constants.CommandStartSign))
            {
                message = message[1..];
                string[] splitted = message.Split(Constants.CommandElementSeparator, StringSplitOptions.RemoveEmptyEntries);
                string[] args = splitted[1..];
                result = splitted[0] switch
                {
                    Constants.Commands.PrivateMessage => new PrivateMessageCommand(args),
                    Constants.Commands.Help => new HelpCommand(args),
                    Constants.Commands.Color => new ColorCommand(args),
                    Constants.Commands.Mute => new MuteCommand(args),
                    Constants.Commands.Unmute => new UnmuteCommand(args),
                    Constants.Commands.MuteList => new MuteListCommand(args),
                    Constants.Commands.Nickname => new NicknameCommand(args),
                    _ => new InvalidCommand(args),
                };
            }
            else
            {
                result = new MessageToAllCommand(message.Split(Constants.CommandElementSeparator));
            }

            return result;
        }
    }
}
