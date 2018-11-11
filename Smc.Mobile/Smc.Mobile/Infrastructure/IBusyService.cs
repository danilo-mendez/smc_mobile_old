using System;
using System.Collections.Generic;
using System.Text;

namespace SMC.Mobile.Infrastructure
{
    public interface IBusyService
    {
        IDisposable BeginBusy();
        bool IsBusy { get; }
    }
}
