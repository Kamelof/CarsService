using CarsCore.Models.ChatModels;
using System.Collections.Generic;
using System.Linq;

namespace CarsCore
{
    public static class StringExtentions
    {
        public static string GetCommandTitle(this string commandName)
            => commandName.Substring(0, commandName.IndexOf("Command"));

        public static ChatUserSettings GetSettingsByClientId(
            this IList<ChatUserSettings> chatUserSettings,
            string clientId)
        {
            return chatUserSettings.FirstOrDefault(x => x.ClientId == clientId);
        }
    }
}
