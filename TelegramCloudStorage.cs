using HomeWork9._4;
using HomeWork9._4.TelegramSupport;
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
            while (true)
            {
                
                string url = $@"{BaseAddressQuery}getUpdates?offset={UpdateId}";
                var updateMsg = BotWebClient.DownloadString(url);


                var msgs = JObject.Parse(updateMsg)["result"].ToArray();

                foreach (dynamic msg in msgs)
                {
                    UpdateId = Convert.ToInt32(msg.update_id) + 1;
                    string userMassage = msg.message.text;
                    string userId = msg.message.from.id;
                    string userFirstName = msg.message.from.first_name;

                    string chatId = msg.message.chat.id;
                    string fromChatId = userId;
                    string message_id = msg.message.message_id;

                    Console.WriteLine($"{msg.update_id}.\n\t{userId}: {userFirstName} \n\tMessage: {userMassage}");
                    Console.WriteLine("\n" + msg + "\n");
                    UserTypeTelegram userData = new UserTypeTelegram(msg.message.from);
                    
                    
                    BaseTypeTelegram fileData = TelegramTypeHelper.CheckFileType(msg);
                    if (fileData != null)
                    {
                        fileData.Save(this, userData);
                    }


                }
                Thread.Sleep(100);
            }

        }



       



       
    }

}

