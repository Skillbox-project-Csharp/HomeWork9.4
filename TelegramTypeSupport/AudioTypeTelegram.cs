using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeWork9._4.TelegramTypeHelper;

namespace HomeWork9._4.TelegramSupport
{
    class AudioTypeTelegram : BaseTypeTelegram
    {
        #region Поля
        public const  FileType TypeTelegram = FileType.audio;
        string _file_id;
        string _file_unique_id;
        int _duration;
        string _performer;
        string _title;
        string _file_name;
        string _mime_type;
        int? _file_size;
        PhotoSizeTypeTelegram _thumb;
        #endregion

        #region Свойства
        public string FileId { get => _file_id; set => _file_id = value; }
        public string FileUniqueId { get => _file_unique_id; set => _file_unique_id = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string Performer { get => _performer; set => _performer = value; }
        public string Title { get => _title; set => _title = value; }
        public string FileName { get => _file_name; set => _file_name = value; }
        public string MimeType { get => _mime_type; set => _mime_type = value; }
        public int? FileSize { get => _file_size; set => _file_size = value; }
        internal PhotoSizeTypeTelegram Thumb { get => _thumb; set => _thumb = value; }
        #endregion

        public AudioTypeTelegram()
        {
            FileId = String.Empty;
            FileUniqueId = String.Empty;
            Duration = 0;
            Performer = String.Empty;
            Title = String.Empty;
            FileName = String.Empty;
            MimeType = String.Empty;
            FileSize = null;
            Thumb = null;
        }

        public AudioTypeTelegram(JToken audio)
        {
            FileId = audio["file_id"].ToObject<string>();
            FileUniqueId = audio["file_unique_id"].ToObject<string>();
            Duration = audio["duration"].ToObject<int>();
            Performer = audio["performer"] != null ? audio["performer"].ToObject<string>() : null;
            Title = audio["title"] != null ? audio["title"].ToObject<string>() : null;
            FileName = audio["file_name"] != null ? audio["file_name"].ToObject<string>() : null;
            MimeType = audio["mime_type"] !=null ? audio["mime_type"].ToObject<string>() : null;
            FileSize = audio["file_size"] != null ? audio["file_size"].ToObject<int?>() : null;
            Thumb = audio["thumb"] != null ? new PhotoSizeTypeTelegram((JToken)audio["thumb"]) : null;
        }

        public override void PrintAll()
        {
            base.PrintAll();
            string patern = 
                "FileId: {0}\n" +
                "FileUniqueId: {1}\n" +
                "Duration: {2}\n" +
                "Performer: {3}\n" +
                "Title: {4}\n" +
                "FileName: {5}\n" +
                "MimeType: {6}\n" +
                "FileSize: {7}\n" +
                "Thumb: {8}\n";
            Console.WriteLine(patern,
                FileId,
                FileUniqueId,
                Duration,
                Performer,
                Title,
                FileName,
                MimeType,
                FileSize,
                Thumb);
        }

        public override void Save(TelegramCloudStorage botInfo, UserTypeTelegram user)
        {

            var linkResult = JObject.Parse(TelegramRequests.GetLinkFileDownload(botInfo, FileId))["result"];
            var download_url = $@"https://api.telegram.org/file/bot{botInfo.BotToken}/{linkResult["file_path"]}";

            var savePath = $@"{Directory.GetCurrentDirectory()}\users\{user.Id}\{TypeTelegram}\";
            Directory.CreateDirectory(savePath);

            var mime_type = TelegramTypeHelper.CheckMimeType(MimeType);
            savePath += FileName != null ? FileName : FileId;
            savePath += mime_type != null ? $".{mime_type}" : null;
            botInfo.BotWebClient.DownloadFile(download_url, savePath);
        }
    }
}
