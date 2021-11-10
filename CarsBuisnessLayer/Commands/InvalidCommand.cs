using CarsCore;
using CarsCore.Models.ChatModels;
using System.Collections.Generic;

namespace CarsBuisnessLayer.Commands
{
    public class InvalidCommand : Command
    {
        protected override int? MinArgsCount => null;

        public InvalidCommand(string[] args) : base(args) { }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            return new CommandOutput
            {
                Message = CreateSystemMessage(Constants.InvalidCommandMessage)
            };
        }
    }
}
