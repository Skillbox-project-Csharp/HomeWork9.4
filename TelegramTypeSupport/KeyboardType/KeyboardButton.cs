using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramTypeSupport.KeyboardType
{
    public class KeyboardButton
    {
        string _text;
        bool? _request_contact;
        bool? _request_location;
        KeyboardButtonPollType _request_poll;

        public string Text { get => _text; set => _text = value; }
        public bool? RequestContact { get => _request_contact; set => _request_contact = value; }
        public bool? RequestLocation { get => _request_location; set => _request_location = value; }
        internal KeyboardButtonPollType RequestPoll { get => _request_poll; set => _request_poll = value; }

        public KeyboardButton()
        {
            Text = string.Empty;
            RequestContact = null;
            RequestLocation = null;
            RequestPoll = null;
        }
        public KeyboardButton(string text)
        {
            Text = text;
            RequestContact = null;
            RequestLocation = null;
            RequestPoll = null;
        }

        public KeyboardButton(string text, bool? requestContact, bool? requestLocation, KeyboardButtonPollType requestPoll)
        {
            Text = text;
            RequestContact = requestContact;
            RequestLocation = requestLocation;
            RequestPoll = requestPoll;
        }
    }
    public class KeyboardButtonPollType
    {
        string _type;

        public string Type { get => _type; set => _type = value; }

        public KeyboardButtonPollType()
        {
            Type = string.Empty;
        }

        public KeyboardButtonPollType(string type)
        {
            Type = type;
        }
    }
}
