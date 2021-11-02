using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCore
{
    public static class Constants
    {
        public const string ServerMessageSenderName = "System";
        public const char CommandStartSign = '/';
        public const char CommandElementSeparator = ' ';
        public static class Commands
        {
            public const string PrivateMessage = "msg";
            public const string Help = "help";
            public const string Color = "color";
        }
    }
}
