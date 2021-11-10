using CarsCore;
using CarsCore.Models.ChatModels;
using System.Collections.Generic;

namespace CarsBuisnessLayer.Commands
{
    public class UnmuteCommand : Command
    {
        protected override int? MinArgsCount => null;

        public UnmuteCommand(string[] args) : base(args) { }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            CommandOutput result = null;
            string mutedUser = _args[0];
            string mutedId = userSettings.GetClientIdByReceiverArg(mutedUser);
            ChatUserSettings currentUserSettings = userSettings.GetSettingsByClientId(callerId);

            if (userSettings.GetSettingsByClientId(mutedId) != null
                && currentUserSettings.MuteList.Contains(mutedId))
            {
                currentUserSettings.MuteList.Remove(mutedId);

                result = new CommandOutput
                {
                    ClientMethod = Constants.ClientMethods.ReceiveMessage,
                    Message = CreateSystemMessage(Constants.ServerMessages.UserUnmuted(mutedUser))
                };
            }

            return result;
        }
    }
}
