using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramTypeSupport
{
    public class BotCommandTelegram
    {
        public string command { set; get; }
        public string description { set; get; }

        public BotCommandTelegram()
        {
            this.command = string.Empty;
            this.description = string.Empty;
        }
        public BotCommandTelegram(string command, string description)
        {
            this.command = command;
            this.description = description;
        }
    }
}
