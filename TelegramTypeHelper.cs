﻿using HomeWork9._4.TelegramSupport;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4
{
    class TelegramTypeHelper
    {
        public  enum FileType { audio, document, photo, video, voice }
        public static HashSet<FileType> FileTypes { get; set; } = new HashSet<FileType>
        {
            FileType.audio,
            FileType.document,
            FileType.photo,
            FileType.video,
            FileType.voice,
        };

        public static BaseTypeTelegram CheckFileType(JToken msg)
        {
            foreach (var typeFile in TelegramTypeHelper.FileTypes)
            {
                string strTypeFyle = typeFile.ToString();
                if (msg["message"][strTypeFyle] != null)
                {

                    switch (typeFile)
                    {
                        case FileType.audio:
                            return new AudioTypeTelegram(msg["message"][strTypeFyle]);
                        case FileType.document:
                            return new DocumentTypeTelegram(msg["message"][strTypeFyle]);
                        case FileType.photo:
                            return new PhotoTypeTelegram(msg["message"][strTypeFyle]);
                        case FileType.video:
                            return new VideoTypeTelegram(msg["message"][strTypeFyle]);
                        case FileType.voice:
                            return new VoiceTypeTelegram(msg["message"][strTypeFyle]);
                    }

                }
            }
            return null;

        }

        public static string CheckMimeType(string mimeType)
        {
            if (mimeType != null)
            {
                var mime_type = mimeType.Split('/');
                if (mime_type.Length != 1)
                    return mime_type[1];
            }
            return null;

        }
    }
}
