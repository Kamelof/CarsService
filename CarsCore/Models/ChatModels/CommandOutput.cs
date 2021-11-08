using System.Collections.Generic;

namespace CarsCore.Models.ChatModels
{
    public class CommandOutput
    {
        public string ClientMethod { get; set; } = Constants.ClientMethods.ReceiveMessage;
        public object Message { get; set; }
        public IEnumerable<string> IgnoreList { get; set; } = new List<string>();
        public string TargetId { get; set; }
    }
}
