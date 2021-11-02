using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCore.Models.ChatModels
{
    public class ChatUserSettings
    {
        public string ClientId { get; set; }
        public string NickName { get; set; }
        public ConsoleColor UserConsoleColor { get; set; }
        public IEnumerable<string> MuteList { get; set; }
    }
}
