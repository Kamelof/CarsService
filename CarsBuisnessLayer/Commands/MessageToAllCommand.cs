using CarsCore;
using CarsCore.Models.ChatModels;
using System.Collections.Generic;
using System.Linq;

namespace CarsBuisnessLayer.Commands
{
    public class MessageToAllCommand : Command
    {
        protected override int? MinArgsCount => 1;

        protected override MessageTarget GetMessageTarget()
        {
            return MessageTarget.All;
        }

        public MessageToAllCommand(string[] args) : base(args) { }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            var igonoreList = userSettings
                  .Where(x => x.MuteList
                      .Contains(callerId))
                  .Select(x => x.ClientId).ToList();
            igonoreList.Add(callerId);

            return new CommandOutput
            {
                Message = new ChatMessage
                {
                    Sender = userSettings.GetSettingsByClientId(callerId).NicknameExist(callerId),
                    MessageColor = userSettings.GetSettingsByClientId(callerId).UserConsoleColor,
                    Text = string.Join(Constants.CommandElementSeparator, _args)
                },
                IgnoreList = igonoreList
            };
        }
    }
}