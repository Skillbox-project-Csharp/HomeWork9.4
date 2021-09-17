using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramSupport
{
    class VoiceTypeTelegram : BaseTypeTelegram
    {
        #region Поля
        string _file_id;
        string _file_unique_id;
        int _duration;
        string _mime_type;
        int? file_size;
        #endregion

        #region Свойства
        public string FileId { get => _file_id; set => _file_id = value; }
        public string FileUniqueId { get => _file_unique_id; set => _file_unique_id = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string MimeType { get => _mime_type; set => _mime_type = value; }
        public int? FileSize { get => file_size; set => file_size = value; }
        #endregion

        public VoiceTypeTelegram()
        {
            FileId = string.Empty;
            FileUniqueId = string.Empty;
            Duration = 0;
            MimeType = string.Empty;
            FileSize = null;
        }

        public VoiceTypeTelegram(JToken voice)
        {
            FileId = voice["file_id"].ToObject<string>();
            FileUniqueId = voice["file_unique_id"].ToObject<string>();
            Duration = voice["duration"].ToObject<int>();
            MimeType = voice["mime_type"] != null ? voice["mime_type"].ToObject<string>() : null;
            FileSize = voice["file_size"] != null ? voice["file_size"].ToObject<int?>() : null;
        }

        public override void PrintAll()
        {
            base.PrintAll();
            string patern = 
                "FileId: {0}\n" +
                "FileUniqueId: {1}\n" +
                "Duration: {2}\n" +
                "MimeType: {3}\n" +
                "FileSize: {4}\n";
            Console.WriteLine(patern,
                FileId,
                FileUniqueId,
                Duration,
                MimeType,
                FileSize);
        }
    }
}
