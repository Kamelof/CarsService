using CarsCore;
using CarsCore.Models.ChatModels;
using System.Collections.Generic;

namespace CarsBuisnessLayer.Commands
{
    public class NicknameCommand : Command
    {
        protected override int? MinArgsCount => 2;
        public NicknameCommand(string[] args) : base(args) { }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            string nickname = _args[0];
            userSettings.GetSettingsByClientId(callerId).Nickname = nickname;

            return new CommandOutput
            {
                ClientMethod = Constants.ClientMethods.ReceiveMessage,
                Message = CreateSystemMessage(Constants.ServerMessages.NicknameChanged(nickname))
            };
        }
    }
}
