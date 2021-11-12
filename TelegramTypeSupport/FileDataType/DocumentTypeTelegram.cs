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
    class DocumentTypeTelegram : BaseTypeTelegram
    {
        #region Поля
        private const FileType TypeTelegram = FileType.document;
        string _file_id;
        string _file_unique_id;
        PhotoSizeTypeTelegram _thumb;
        string _file_name;
        string _mime_type;
        int? _file_size;
        #endregion

        #region Свойства
        public string FileId { get => _file_id; set => _file_id = value; }
        public string FileUniqueId { get => _file_unique_id; set => _file_unique_id = value; }
        public string FileName { get => _file_name; set => _file_name = value; }
        public string MimeType { get => _mime_type; set => _mime_type = value; }
        public int? FileSize { get => _file_size; set => _file_size = value; }
        internal PhotoSizeTypeTelegram Thumb { get => _thumb; set => _thumb = value; }
        #endregion

        public DocumentTypeTelegram()
        {
            FileId = string.Empty;
            FileUniqueId = string.Empty;
            FileName = string.Empty;
            MimeType = string.Empty;
            FileSize = null;
            Thumb = null;
        }

        public DocumentTypeTelegram(JToken document)
        {
            FileId = document["file_id"].ToObject<string>();
            FileUniqueId = document["file_unique_id"].ToObject<string>();
            FileName = document["file_name"] != null ? document["file_name"].ToObject<string>() : null;
            MimeType = document["mime_type"] != null ? document["mime_type"].ToObject<string>() : null;
            FileSize = document["file_size"] != null ? document["file_size"].ToObject<int?>() : null ;
            Thumb = document["thumb"] != null ? new PhotoSizeTypeTelegram((JToken)document["thumb"]) : null;
        }

        public override void PrintAll()
        {
            base.PrintAll();
            string patern = 
                "FileId: {0}\n" +
                "FileUniqueId: {1}\n" +
                "FileName: {2}\n" +
                "MimeType: {3}\n" +
                "FileSize: {4}\n";
            Console.WriteLine(patern,
                FileId,
                FileUniqueId,
                FileName,
                MimeType,
                FileSize);
            Thumb?.PrintAll();
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
