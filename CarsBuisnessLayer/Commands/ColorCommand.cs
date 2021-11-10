using CarsCore;
using CarsCore.Models.ChatModels;
using System;
using System.Collections.Generic;

namespace CarsBuisnessLayer.Commands
{
    public class ColorCommand : Command
    {
        protected override int? MinArgsCount => 1;

        public ColorCommand(string[] args) : base(args) { }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            CommandOutput result = null;
            string colorString = _args[0];
            if (Enum.TryParse(typeof(ConsoleColor), char.ToUpper(colorString[0]) + colorString[1..], out var color))
            {
                var newColor = (ConsoleColor)color;
                userSettings.GetSettingsByClientId(callerId).UserConsoleColor = newColor;

                result = new CommandOutput
                {
                    ClientMethod = Constants.ClientMethods.ColorChanged,
                    Message = newColor
                };
            }

            return result;
        }
    }
}
