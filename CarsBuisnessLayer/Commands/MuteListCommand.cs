using CarsCore;
using CarsCore.Models.ChatModels;
using System;
using System.Collections.Generic;

namespace CarsBuisnessLayer.Commands
{
    public class MuteListCommand : Command
    {
        protected override int? MinArgsCount => null;

        public MuteListCommand(string[] args) : base(args) { }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            return new CommandOutput
            {
                Message = CreateSystemMessage(
                    FormIgnoreListMessage(
                        userSettings.GetSettingsByClientId(callerId).MuteList))
            };
        }

        private string FormIgnoreListMessage(HashSet<string> ignoreIds) => 
            string.Join(Environment.NewLine, ignoreIds);
    }
}
