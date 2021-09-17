using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HomeWork9._4.TelegramSupport
{
    public class UserTypeTelegram
    {
        #region Поля
        int _id;
        bool? _is_bot;
        string _first_name;
        string _last_name;
        string _username;
        string _language_code;
        bool? _can_join_groups;
        bool? _can_read_all_group_messages;
        bool? _supports_inline_queries;
        #endregion 

        #region Свойства
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool? IsBot
        {
            get { return _is_bot; }
            set { _is_bot = value; }
        }
        public string FirstName
        {
            get { return _first_name; }
            set { _first_name = value; }
        }
        public string LastName
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string LanguageCode
        {
            get { return _language_code; }
            set { _language_code = value; }
        }
        public bool? CanJoinGroups
        {
            get { return _can_join_groups; }
            set { _can_join_groups = value; }
        }
        public bool? CanReadAllGroupMessages
        {
            get { return _can_read_all_group_messages; }
            set { _can_read_all_group_messages = value; }
        }
        public bool? SupportsInlineQueries
        {
            get { return _supports_inline_queries; }
            set { _supports_inline_queries = value; }
        }
        #endregion

        public UserTypeTelegram()
        {
             Id = 0;
             IsBot = false;
             FirstName = String.Empty;
             LastName = String.Empty;
             Username = String.Empty;
             LanguageCode = String.Empty;
             CanJoinGroups = false;
             CanReadAllGroupMessages = false;
             SupportsInlineQueries = false;
        }

        public UserTypeTelegram(int id, bool is_bot, string first_name, string last_name, string username, string language_code, bool can_join_groups, bool can_read_all_group_messages, bool supports_inline_queries)
        {
            Id = id;
            IsBot = is_bot;
            FirstName = first_name;
            LastName = last_name;
            Username = username;
            LanguageCode = language_code;
            CanJoinGroups = can_join_groups;
            CanReadAllGroupMessages = can_read_all_group_messages;
            SupportsInlineQueries = supports_inline_queries;
        }

        public UserTypeTelegram(JToken from)
        {
            Id = from["id"].ToObject<int>();
            IsBot = from["is_bot"].ToObject<bool>(); ;
            FirstName = from["first_name"].ToObject<string>();
            LastName = from["last_name"].ToObject<string>();
            Username = from["username"].ToObject<string>();
            LanguageCode = from["language_code"].ToObject<string>();
            CanJoinGroups = from["can_join_groups"]!= null ? from["can_join_groups"].ToObject<bool?>() : null;
            CanReadAllGroupMessages = from["can_read_all_group_messages"] != null ? from["can_read_all_group_messages"].ToObject<bool?>() : null;
            SupportsInlineQueries = from["supports_inline_queries"] != null ? from["supports_inline_queries"].ToObject<bool?>() : null;
        }

    }
}
