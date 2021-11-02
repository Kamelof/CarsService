using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCore.Models.ChatModels
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public string MessageColor { get; set }
    }
}
