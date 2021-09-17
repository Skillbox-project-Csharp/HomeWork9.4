
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork9._4
{

    static class Program
    {


        
        static string BOT_TOKEN = System.IO.File.ReadAllText("token.txt");

        static async Task Main()
        {
            
            TelegramCloudStorage botTelegram = new TelegramCloudStorage(BOT_TOKEN);
            botTelegram.Start();

           
        }

    }
}
