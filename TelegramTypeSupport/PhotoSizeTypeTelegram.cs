using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramSupport
{
    class PhotoSizeTypeTelegram : BaseTypeTelegram
    {
        #region Поля
        string _file_id;
        string _file_unique_id;
        int _width;
        int _height;
        int? _file_size;
        #endregion

        #region Свойства
        public string FileId { get => _file_id; set => _file_id = value; }
        public string FileUniqueId { get => _file_unique_id; set => _file_unique_id = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int? FileSize { get => _file_size; set => _file_size = value; }
        #endregion

        public PhotoSizeTypeTelegram()
        {
            FileId = String.Empty;
            FileUniqueId = String.Empty;
            Width = 0;
            Height = 0;
            FileSize = 0;
        }

        public PhotoSizeTypeTelegram(JToken thumb)
        {
            FileId = thumb["file_id"].ToObject<string>();
            FileUniqueId = thumb["file_unique_id"].ToObject<string>();
            Width = thumb["width"].ToObject<int>();
            Height = thumb["height"].ToObject<int>();
            FileSize = thumb["file_size"] != null ? thumb["file_size"].ToObject<int?>() : null;
        }

        public override void PrintAll()
        {
            base.PrintAll();
            string patern =
              "FileId: {0}\n" +
              "FileUniqueId: {1}\n" +
              "Width: {2}\n" +
              "Height: {3}\n" +
              "FileSize: {4}\n";
            Console.WriteLine(patern,
                FileId,
                FileUniqueId,
                Width,
                Height,
                FileSize);
        }
    }
}
