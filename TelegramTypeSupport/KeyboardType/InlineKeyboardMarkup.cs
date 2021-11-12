using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramTypeSupport.KeyboardType
{
    class InlineKeyboardMarkup
    {
        InlineKeyboardButton[][] _inline_keyboard;

        [JsonProperty("inline_keyboard")]
        public InlineKeyboardButton[][] Inline_keyboard { get => _inline_keyboard; set => _inline_keyboard = value; }

        public InlineKeyboardMarkup()
        {
            Inline_keyboard = null;
        }
        public InlineKeyboardMarkup(InlineKeyboardButton[][] inline_keyboard)
        {
            Inline_keyboard = inline_keyboard;
        }
    }
}
