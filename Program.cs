
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HomeWork9._4
{
    
    static class Program
    {
        

        static TelegramBotClient Bot;
        static string BOT_TOKEN = System.IO.File.ReadAllText("token.txt");

        static async Task Main()
        {
            var cts = new CancellationTokenSource();

            try
            {
                Bot = new TelegramBotClient(BOT_TOKEN);

                var me = await Bot.GetMeAsync();
                Console.WriteLine($"Start listening for @{me.Username}");

                await Bot.ReceiveAsync(new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync), cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                cts.Cancel();
            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {
            /*var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };*/

            Console.WriteLine(exception.Message);

            return Task.CompletedTask;
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
                return;

            try
            {
                await BotOnMessageReceived(update.Message);
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(bot, exception, cancellationToken);
            }
        }

        static async Task BotOnMessageReceived(Message message)
        {
            Console.WriteLine($"Receive message type: {message.Type}");
            if (message.Type == MessageType.Audio)
            {
                DownLoad(message.Audio.FileId, $"audio_{message.Audio.FileName}");
            }
            if (message.Type != MessageType.Text)
                return;

            await Bot.SendTextMessageAsync(message.Chat.Id, $"Received {message.Text}");
        }

        static async void DownLoad(string fileId, string path)
        {
            var file = await Bot.GetFileAsync(fileId);
            FileStream fs = new FileStream(path, FileMode.Create);
            await Bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();
            fs.Dispose();
        }
    }
}
