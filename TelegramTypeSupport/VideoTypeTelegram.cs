using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramSupport
{
    class VideoTypeTelegram : BaseTypeTelegram
    {
        #region Поля
        string _file_id;
        string _file_unique_id;
        int _width;
        int _height;
        int _duration;
        PhotoSizeTypeTelegram _thumb;
        string _file_name;
        string _mime_type;
        int? _file_size;
        #endregion

        #region Свойства
        public string FileId
        {
            get { return _file_id; }
            set { _file_id = value; }
        }
        public string FileUniqueId
        {
            get { return _file_unique_id; }
            set { _file_unique_id = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public PhotoSizeTypeTelegram Thumb
        {
            get { return _thumb; }
            set { _thumb = value; }
        }
        public string FileName
        {
            get { return _file_name; }
            set { _file_name = value; }
        }
        public string MimeType
        {
            get { return _mime_type; }
            set { _mime_type = value; }
        }
        public int? FileSize
        {
            get { return _file_size; }
            set { _file_size = value; }
        }
        #endregion 

        public VideoTypeTelegram()
        {
            FileId = String.Empty;
            FileUniqueId = String.Empty;
            Width = 0;
            Height = 0;
            Duration = 0;
            Thumb = null;
            FileName = String.Empty;
            MimeType = String.Empty;
            FileSize = 0;
        }

        public VideoTypeTelegram(JToken video)
        {
            FileId = video["file_id"].ToObject<string>();
            FileUniqueId = video["file_unique_id"].ToObject<string>();
            Width = video["width"].ToObject<int>();
            Height = video["height"].ToObject<int>();
            Duration = video["duration"].ToObject<int>();
            Thumb = video["thumb"] != null ? new PhotoSizeTypeTelegram(video["thumb"]) : null;
            FileName = video["file_name"] != null ? video["file_name"].ToObject<string>() : null;
            MimeType = video["mime_type"] != null ? video["mime_type"].ToObject<string>() : null;
            FileSize = video["file_size"] != null ? video["file_size"].ToObject<int?>() : null;
        }
        public override void PrintAll()
        {
            base.PrintAll();
            string patern =
               "FileId: {0}\n" +
               "FileUniqueId: {1}\n" +
               "Width: {2}\n" +
               "Height: {3}\n" +
               "Duration: {4}\n" +
               "FileName: {5}\n" +
               "MimeType: {6}\n" +
               "FileSize: {7}\n";
            Console.WriteLine(patern,
                FileId,
                FileUniqueId,
                Width,
                Height,
                Duration,
                FileName,
                MimeType,
                FileSize);
            Thumb?.PrintAll();
        }
    }

}
