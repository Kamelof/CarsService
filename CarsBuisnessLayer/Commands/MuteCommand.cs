using CarsCore;
using CarsCore.Models.ChatModels;
using System.Collections.Generic;

namespace CarsBuisnessLayer.Commands
{
    public class MuteCommand : Command
    {
        protected override int? MinArgsCount => 1;

        public MuteCommand(string[] args) : base(args)
        { }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            CommandOutput result = null;
            var id = _args[0];
            var userWithId = userSettings.GetSettingsByClientId(id);
            var currentUserSettings = userSettings.GetSettingsByClientId(callerId);

            if (userWithId != null &&
                !currentUserSettings.MuteList.Contains(id))
            {
                currentUserSettings.MuteList.Add(id);

                result = new CommandOutput
                {
                    ClientMethod = Constants.ClientMethods.ReceiveMessage,
                    Message = CreateSystemMessage(Constants.ServerMessages.UserMuted(id))
                };
            }

            return result;
        }
    }
}
