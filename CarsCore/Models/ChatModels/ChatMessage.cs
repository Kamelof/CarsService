using System;

namespace CarsCore.Models.ChatModels
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public ConsoleColor MessageColor { get; set; }
    }
}
