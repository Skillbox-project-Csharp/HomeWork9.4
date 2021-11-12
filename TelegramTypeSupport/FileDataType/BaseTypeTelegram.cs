using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9._4.TelegramSupport
{
    public abstract class BaseTypeTelegram
    {
        virtual public void Save(TelegramCloudStorage botInfo, UserTypeTelegram user) { }
        virtual public void PrintAll() { }
    }
}
