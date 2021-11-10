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
            string clientId) => 
                chatUserSettings.FirstOrDefault(x => x.ClientId == clientId);

        public static ChatUserSettings GetSettingsByClientNickname(
            this IList<ChatUserSettings> chatUserSettings,
            string nickname) => 
                chatUserSettings.FirstOrDefault(x => x.Nickname == nickname);

        public static string NicknameExist(
            this ChatUserSettings UserSettings,
            string callerId) =>
                UserSettings.Nickname ?? callerId;

        public static string GetClientIdByReceiverArg(
            this IList<ChatUserSettings> chatUserSettings,
            string receiver) =>
                chatUserSettings.GetSettingsByClientNickname(receiver) != null
                ? chatUserSettings.GetSettingsByClientNickname(receiver).ClientId
                : receiver;
    }
}
