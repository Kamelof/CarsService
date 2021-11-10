using CarsCore.Models.ChatModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsBuisnessLayer.Commands
{
    public class OnlineUsersCommand : Command
    {
        protected override int? MinArgsCount => null;

        public OnlineUsersCommand(string[] args) : base(args) { }

        protected override CommandOutput CreateCommandOutput(string callerId, IList<ChatUserSettings> userSettings)
        {
            List<string> igonoreList = userSettings
                  .Where(x => x.MuteList
                      .Contains(callerId))
                  .Select(x => x.ClientId).ToList();
            igonoreList.Add(callerId);

            List<string> usersList = userSettings
                .Where(x => x.Nickname != null && !igonoreList.Contains(x.ClientId))
                .Select(x => x.Nickname).ToList();
            usersList.AddRange(userSettings
                .Where(x => x.Nickname == null && !igonoreList.Contains(x.ClientId))
                .Select(x => x.ClientId).ToList());

            return new CommandOutput
            {
                Message = CreateSystemMessage(
                    FormOnlineUsersMessage(usersList))
            };
        }

        private string FormOnlineUsersMessage(IList<string> usersList) =>
            string.Join(Environment.NewLine, usersList);
    }
}
