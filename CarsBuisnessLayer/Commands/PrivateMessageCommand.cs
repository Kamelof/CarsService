using CarsCore;
using CarsCore.Models.ChatModels;
using System.Collections.Generic;
using System.Linq;

namespace CarsBuisnessLayer.Commands
{
    public class PrivateMessageCommand : Command
    {
        protected override int? MinArgsCount => 2;

        protected override MessageTarget GetMessageTarget()
        {
            return _target;
        }

        public PrivateMessageCommand(string[] args) : base(args)
        {
            _target = MessageTarget.Personal;
        }

        protected override CommandOutput CreateCommandOutput(
            string callerId,
            IList<ChatUserSettings> userSettings)
        {
            CommandOutput result = null;
            var id = _args[0];
            if (userSettings.GetSettingsByClientId(id) != null)
            {
                var igonoreList = userSettings
                  .Where(x => x.MuteList
                      .Contains(callerId))
                  .Select(x => x.ClientId).ToList();
                igonoreList.Add(callerId);

                var personalMessage = string.Join(
                    Constants.CommandElementSeparator,
                    _args[1..]);

                result = new CommandOutput
                {
                    Message = new ChatMessage
                    {
                        Sender = callerId,
                        MessageColor = userSettings.GetSettingsByClientId(callerId)
                            .UserConsoleColor,
                        Text = personalMessage,
                    },
                    IgnoreList = igonoreList,
                    TargetId = id
                };
            }
            else
            {
                _target = MessageTarget.Self;
            }

            return result;
        }
    }
}
