using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4
{
    class TelegramRequests
    {
        public static string ForwardMessage(TelegramCloudStorage botInfo, string chat_id, string from_chat_id, string message_id)
        {
            string url = $@"{botInfo.BaseAddressQuery}forwardMessage?chat_id={chat_id}&from_chat_id={from_chat_id}&message_id={message_id}";
            var message = botInfo.BotWebClient.DownloadString(url);
            return message;
        }

        public static string GetLinkFileDownload(TelegramCloudStorage botInfo, string file_id)
        {
            string url = $@"{botInfo.BaseAddressQuery}getFile?file_id={file_id}";
            var message = botInfo.BotWebClient.DownloadString(url);
            return message;
        }
    }
}
