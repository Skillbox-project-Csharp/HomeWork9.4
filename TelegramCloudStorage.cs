using HomeWork9._4;
using HomeWork9._4.TelegramSupport;
using HomeWork9._4.TelegramTypeSupport;
using HomeWork9._4.TelegramTypeSupport.KeyboardType;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HomeWork9._4.TelegramTypeHelper;

namespace HomeWork9._4
{
    public class TelegramCloudStorage
    {

        public string BotToken { get; set; }
        public int UpdateId { get; set; } = 0;
        public WebClient BotWebClient { get; set; }
        public string BaseAddressQuery { get; set; }
        public TelegramCloudStorage(string botToken)
        {
            BotToken = botToken;
            try
            {
                BotWebClient = new WebClient() { Encoding = Encoding.UTF8 };
                BaseAddressQuery = $@"https://api.telegram.org/bot{BotToken}/";
            }
            catch (ArgumentException exception)
            {
                BotWebClient = null;
                Console.WriteLine(exception.Message);
            }
        }
        /// <summary>
        /// Запуск бота
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            //Console.WriteLine( TelegramRequests.SetMyCommands(this, TelegramTypeHelper.BotCommands));
            while (true)
            {

                var updateMsg = TelegramRequests.GetUpdates(this, UpdateId, "message", "callback_query");

                var msgs = JObject.Parse(updateMsg)["result"].ToArray();
                foreach (dynamic msg in msgs)
                {
                    UpdateId = Convert.ToInt32(msg.update_id) + 1;

                    Console.WriteLine("message");
                    if (msg["message"] != null)
                    {
                        MessageHandler(msg);
                    }
                    Console.WriteLine("callback_query");
                    if (msg["callback_query"] != null)
                    {
                        CallbackQueryHandlerAsync(msg["callback_query"]);
                    }
                }
                Thread.Sleep(10);
            }

        }

        private void MessageHandler(JToken msg)
        {

            Console.WriteLine(msg);
            string userMassage = msg?["message"]?["text"]?.ToString();

            string chatId = msg["message"]["chat"]["id"].ToString();
            string message_id = msg["message"]["message_id"].ToString();
            Console.WriteLine(" msgId = " + message_id);
            string userId = msg["message"]?["from"]?["id"]?.ToString();
            UserTypeTelegram userData = new UserTypeTelegram(msg["message"]["from"]);
            if (TelegramTypeHelper.CheckCommand(msg))
                DoCommand(userMassage, chatId, userData);
            BaseTypeTelegram fileData = TelegramTypeHelper.CheckFileType(msg);
            if (fileData != null)
            {
                fileData.Save(this, userData);
                TelegramRequests.DeleteMessage(this, chatId, Convert.ToInt32(message_id));
            }

        }
        private async Task CallbackQueryHandlerAsync(JObject callbackQuery)
        {
            Console.WriteLine(callbackQuery);

            string data = callbackQuery["data"].ToString();
            int msgId = int.Parse(callbackQuery["message"]["message_id"].ToString());
            string chatId = callbackQuery["message"]["chat"]["id"].ToString();
            string userId = callbackQuery["from"]["id"].ToString();

            TelegramRequests.DeleteMessage(this, chatId, msgId);

            FileType typeFile = callbackQuery["message"]["text"].ToObject<FileType>();
            switch (typeFile)
            {
                case FileType.audio:
                    await TelegramRequests.SendAudioAsync(this, chatId, $@"{Directory.GetCurrentDirectory()}\users\{userId}\{typeFile}\{data}");
                    break;
                case FileType.photo:
                    await TelegramRequests.SendPhotoAsync(this, chatId, $@"{Directory.GetCurrentDirectory()}\users\{userId}\{typeFile}\{data}");
                    break;
                case FileType.document:
                    await TelegramRequests.SendDocumentAsync(this, chatId, $@"{Directory.GetCurrentDirectory()}\users\{userId}\{typeFile}\{data}");
                    break;
                case FileType.video:
                    await TelegramRequests.SendVideoAsync(this, chatId, $@"{Directory.GetCurrentDirectory()}\users\{userId}\{typeFile}\{data}");
                    break;
                case FileType.voice:
                    await TelegramRequests.SendVoiceAsync(this, chatId, $@"{Directory.GetCurrentDirectory()}\users\{userId}\{typeFile}\{data}");
                    break;
            }
            
        }

        private InlineKeyboardMarkup BildingButton(string[] textButton)
        {
            int lengthButton = textButton.Length;
            InlineKeyboardButton[][] inlineKeyboardButtons = new InlineKeyboardButton[lengthButton][];
            for (int i = 0; i < lengthButton; i++)
            {
                inlineKeyboardButtons[i] = new InlineKeyboardButton[1];
                inlineKeyboardButtons[i][0] = new InlineKeyboardButton(textButton[i], textButton[i]);
            }
            return new InlineKeyboardMarkup(inlineKeyboardButtons);
        }

        private string[] GetSpecificFileList(int userId, TelegramTypeHelper.FileType type)
        {
            string[] fileList = new string[0];
            try
            {
                fileList = Directory.GetFiles($@"{Directory.GetCurrentDirectory()}\users\{userId}\{type}\");
            }
            catch (DirectoryNotFoundException) { }
            catch (ArgumentException) { }
            catch (UnauthorizedAccessException) { }
            catch (PathTooLongException) { };
            for (int i = 0; i < fileList.Length; i++)
                fileList[i] = fileList[i].Split('\\').Last();
            return fileList;
        }

        private void DoCommand(string command, string chatId, UserTypeTelegram user)
        {

            switch (command.Split('/').Last())
            {
                case "getlistaudio":
                    TelegramRequests.SendMessage
                        (
                        this,
                        chatId,
                        FileType.audio.ToString(),
                        BildingButton(GetSpecificFileList(user.Id, FileType.audio))
                        );
                    break;
                case "getlistdocument":
                    TelegramRequests.SendMessage
                        (
                        this,
                        chatId,
                        FileType.document.ToString(),
                        BildingButton(GetSpecificFileList(user.Id, FileType.document))
                        );
                    break;
                case "getlistphoto":
                    TelegramRequests.SendMessage
                        (
                        this,
                        chatId,
                        FileType.photo.ToString(),
                        BildingButton(GetSpecificFileList(user.Id, FileType.photo))
                        );
                    break;
                case "getlistvideo":
                    TelegramRequests.SendMessage
                        (
                        this,
                        chatId,
                        FileType.video.ToString(),
                        BildingButton(GetSpecificFileList(user.Id, FileType.video))
                        );
                    break;
                case "getlistvoice":
                    TelegramRequests.SendMessage
                        (
                        this,
                        chatId,
                        FileType.voice.ToString(),
                        BildingButton(GetSpecificFileList(user.Id, FileType.voice))
                        );
                    break;
                case "start":
                    TelegramRequests.SendMessage(this, chatId, $"Привет {user.FirstName}!");
                    break;
            }
        }




    }

}

