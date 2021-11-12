using HomeWork9._4.TelegramTypeSupport;
using HomeWork9._4.TelegramTypeSupport.KeyboardType;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace HomeWork9._4
{
    class TelegramRequests
    {
        public static string GetUpdates(TelegramCloudStorage botInfo, int offset)
        {
            string url = $@"{botInfo.BaseAddressQuery}getUpdates?offset={offset}";
            var updateMsg = botInfo.BotWebClient.DownloadString(url);
            return updateMsg;
        }
        public static string GetUpdates(TelegramCloudStorage botInfo, int offset, params string[] allowedUpdates)
        {
            string url = $@"{botInfo.BaseAddressQuery}getUpdates?offset={offset}&allowed_updates={JsonConvert.SerializeObject(allowedUpdates)}";
            var updateMsg = botInfo.BotWebClient.DownloadString(url);
            return updateMsg;
        }

        /// <summary>
        /// Переслать сообщение
        /// </summary>
        /// <param name="botInfo"></param>
        /// <param name="chat_id"></param>
        /// <param name="from_chat_id"></param>
        /// <param name="message_id"></param>
        /// <returns></returns>
        public static string ForwardMessage(TelegramCloudStorage botInfo, string chat_id, string from_chat_id, string message_id)
        {
            string url = $@"{botInfo.BaseAddressQuery}forwardMessage?chat_id={chat_id}&from_chat_id={from_chat_id}&message_id={message_id}";
            var message = botInfo.BotWebClient.DownloadString(url);
            return message;
        }
        /// <summary>
        /// Вернуть ссылку загрузки на файл
        /// </summary>
        /// <param name="botInfo"></param>
        /// <param name="file_id"></param>
        /// <returns></returns>
        public static string GetLinkFileDownload(TelegramCloudStorage botInfo, string file_id)
        {
            string url = $@"{botInfo.BaseAddressQuery}getFile?file_id={file_id}";
            var message = botInfo.BotWebClient.DownloadString(url);
            return message;
        }

        /// <summary>
        /// Удалить сообщение 
        /// </summary>
        /// <param name="botInfo"></param>
        /// <param name="chat_id"></param>
        /// <param name="message_id"></param>
        /// <returns></returns>
        public static bool DeleteMessage(TelegramCloudStorage botInfo, string chat_id, int message_id)
        {
            string url = $@"{botInfo.BaseAddressQuery}deleteMessage?chat_id={chat_id}&message_id={message_id}";
            var message = botInfo.BotWebClient.DownloadString(url);
            bool result;
            bool.TryParse(message, out result);
            return result;
        }
        /// <summary>
        /// Установить команды
        /// </summary>
        /// <param name="botInfo"></param>
        /// <param name="botCommands"></param>
        /// <returns></returns>
        public static bool SetMyCommands(TelegramCloudStorage botInfo, params BotCommandTelegram[] botCommands)
        {
            string url = $@"{botInfo.BaseAddressQuery}setMyCommands?commands={JsonConvert.SerializeObject(botCommands)}";
            var message = botInfo.BotWebClient.DownloadString(url);
            bool result;
            bool.TryParse(message, out result);
            return result;
        }

        public static string SendMessage(TelegramCloudStorage botInfo, string chat_id, string text, InlineKeyboardMarkup reply_markup)
        {

            string serRM = JsonConvert.SerializeObject(reply_markup, Formatting.Indented);
            string url = $@"{botInfo.BaseAddressQuery}sendMessage?chat_id={chat_id}&text={text}&reply_markup={serRM}";
            var message = botInfo.BotWebClient.DownloadString(url);
            return message;
        }
        public static string SendMessage(TelegramCloudStorage botInfo, string chat_id, string text)
        {

            string url = $@"{botInfo.BaseAddressQuery}sendMessage?chat_id={chat_id}&text={text}";
            var message = botInfo.BotWebClient.DownloadString(url);
            return message;
        }

        public static async Task SendPhotoAsync(TelegramCloudStorage botInfo, string chatId, string filePath)
        {
            
            string url = $@"{botInfo.BaseAddressQuery}sendPhoto";
            var fileName = filePath.Split('\\').Last();
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId, Encoding.UTF8), "chat_id");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "photo", fileName);

                    using (var client = new HttpClient())
                    {
                        await client.PostAsync(url, form);
                    }
                }
            }
        }

        public static async Task SendAudioAsync(TelegramCloudStorage botInfo, string chatId, string filePath)
        {

            string url = $@"{botInfo.BaseAddressQuery}sendAudio";
            var fileName = filePath.Split('\\').Last();
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId, Encoding.UTF8), "chat_id");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "audio", fileName);

                    using (var client = new HttpClient())
                    {
                        await client.PostAsync(url, form);
                    }
                }
            }
        }

        public static async Task SendDocumentAsync(TelegramCloudStorage botInfo, string chatId, string filePath)
        {

            string url = $@"{botInfo.BaseAddressQuery}sendDocument";
            var fileName = filePath.Split('\\').Last();
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId, Encoding.UTF8), "chat_id");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "document", fileName);

                    using (var client = new HttpClient())
                    {
                        await client.PostAsync(url, form);
                    }
                }
            }
        }

        public static async Task SendVideoAsync(TelegramCloudStorage botInfo, string chatId, string filePath)
        {

            string url = $@"{botInfo.BaseAddressQuery}sendVideo";
            var fileName = filePath.Split('\\').Last();
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId, Encoding.UTF8), "chat_id");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "video", fileName);

                    using (var client = new HttpClient())
                    {
                        await client.PostAsync(url, form);
                    }
                }
            }
        }

        public static async Task SendVoiceAsync(TelegramCloudStorage botInfo, string chatId, string filePath)
        {

            string url = $@"{botInfo.BaseAddressQuery}sendVoice";
            var fileName = filePath.Split('\\').Last();
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId, Encoding.UTF8), "chat_id");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "voice", fileName);

                    using (var client = new HttpClient())
                    {
                        await client.PostAsync(url, form);
                    }
                }
            }
        }

    }
}
