using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramSupport
{
    class PhotoTypeTelegram : BaseTypeTelegram
    {
        List<PhotoSizeTypeTelegram> _photo_array;

        public List<PhotoSizeTypeTelegram> PhotoArray { get => _photo_array; set => _photo_array = value; }

        public PhotoTypeTelegram()
        {
            PhotoArray = new List<PhotoSizeTypeTelegram>();
        }

        public PhotoTypeTelegram(JToken photo)
        {
            PhotoArray = new List<PhotoSizeTypeTelegram>();

            foreach(var photoSize in photo.ToObject<JArray>())
            {
                PhotoArray.Add(new PhotoSizeTypeTelegram(photoSize));
            }
        }

        public override void PrintAll()
        {
            base.PrintAll();

            foreach (var photo in PhotoArray)
                photo.PrintAll();
        }

        public override void Save(TelegramCloudStorage botInfo, UserTypeTelegram user)
        {

            foreach (var photo in PhotoArray)
                photo.Save(botInfo, user);
        }
    }
}
