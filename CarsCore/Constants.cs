using System;

namespace CarsCore
{
    public static class Constants
    {
        public const string ServerMessageSenderName = "System";
        public const char CommandStartSign = '/';
        public const char CommandElementSeparator = ' ';
        public const string InvalidCommandMessage = "Invalid command!";
        public static class Commands
        {
            public const string PrivateMessage = "msg";
            public const string Help = "help";
            public const string Color = "color";
            public const string Mute = "mute";
            public const string MuteList = "mutelist";
            public const string Unmute = "unmute";
            public const string Nickname = "nickname";
            public const string OnlineUsers = "onlineusers";
        }
        public static class ClientMethods
        {
            public const string ReceiveMessage = nameof(ReceiveMessage);
            public const string ColorChanged = nameof(ColorChanged);
        }
        public static class ServerMessages
        {
            public static string Help = 
                "/msg <CallerId>||<CallerNickName> Your message text => send private message to client"
                + Environment.NewLine +
                "/help => call this help"
                + Environment.NewLine +
                "/mute <CallerId>||<CallerNickName> => muted message from client"
                + Environment.NewLine +
                "/muteList => show your list whith muted clients"
                + Environment.NewLine +
                "/unmute <CallerId>||<CallerNickName> => remove client from mutelist"
                + Environment.NewLine +
                "/color <colorName> => change your messages color"
                + Environment.NewLine +
                "/nickname <newNickName> => change your nickname"
                + Environment.NewLine +
                "/onlineUsers => show your list whith online clients without muted"
                + Environment.NewLine +
                "Text of your message => send message to all in chat";

            public static string NicknameChanged(string nickname) => $"Nickname changed to {nickname}";

            public static string NicknameAlreadyUse(string nickname) => $"Sorry, but nickname {nickname} is already use";

            public static string UserMuted(string user)
                => string.Format("{0} muted!", user);

            public static string UserUnmuted(string user)
                => string.Format("{0} unmuted!", user);
        }
    }
}
