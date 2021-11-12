using HomeWork9._4.TelegramTypeSupport.KeyboardType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramTypeSupport
{
    public class ReplyKeyboardMarkup
    {
        KeyboardButton[][] _keyboard;
        bool? _resize_keyboard;
        bool? _one_time_keyboard;
        string input_field_placeholder;
        bool? selective;

        public bool? Resize_keyboard { get => _resize_keyboard; set => _resize_keyboard = value; }
        public bool? One_time_keyboard { get => _one_time_keyboard; set => _one_time_keyboard = value; }
        public string Input_field_placeholder { get => input_field_placeholder; set => input_field_placeholder = value; }
        public bool? Selective { get => selective; set => selective = value; }
        public KeyboardButton[][] Keyboard { get => _keyboard; set => _keyboard = value; }

        public ReplyKeyboardMarkup()
        {
            Resize_keyboard = null;
            One_time_keyboard = null;
            Input_field_placeholder = string.Empty;
            Selective = null;
            Keyboard = null;
        }

        public ReplyKeyboardMarkup(bool? resize_keyboard, bool? one_time_keyboard, string input_field_placeholder, bool? selective, KeyboardButton[][] keyboard)
        {
            Resize_keyboard = resize_keyboard;
            One_time_keyboard = one_time_keyboard;
            Input_field_placeholder = input_field_placeholder;
            Selective = selective;
            Keyboard = keyboard;
        }

        public ReplyKeyboardMarkup(KeyboardButton[][] keyboard)
        {
            Keyboard = keyboard;
        }
    }
}
