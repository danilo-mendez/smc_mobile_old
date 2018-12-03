using System;
using System.Collections.Generic;
using System.Text;

namespace Smc.Mobile.Controls
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
