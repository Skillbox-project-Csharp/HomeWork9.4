using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace HomeWork9._4.TelegramTypeSupport.KeyboardType
{
    class InlineKeyboardButton
    {
        private string _text;
      //  private string _url;
        private string _callback_data;

        [JsonProperty("text")]
        public string Text { get => _text; set => _text = value; }
/*        [JsonPropertyName("url")]
        public string Url { get => _url; set => _url = value; }*/
        [JsonProperty("callback_data")]
        public string CallbackData { get => _callback_data; set => _callback_data = value; }

        public InlineKeyboardButton()
        {
            Text = string.Empty;
           // Url = string.Empty;
            CallbackData = string.Empty;
        }
      /*  public InlineKeyboardButton(string text, string url, string callbackData)
        {
            Text = text;
            Url = url;
            CallbackData = callbackData;
        }*/

        public InlineKeyboardButton(string text, string callbackData)
        {
            Text = text;
            CallbackData = callbackData;
        }
    }
}
