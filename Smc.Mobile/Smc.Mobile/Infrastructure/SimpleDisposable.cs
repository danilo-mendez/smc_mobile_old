using System;
using System.Collections.Generic;
using System.Text;

namespace SMC.Mobile.Infrastructure
{
    internal class SimpleDisposable : IDisposable
    {
        private Action onDispose;

        public SimpleDisposable(Action onDispose)
        {
            this.onDispose = onDispose;
        }

        public void Dispose()
        {
            this.onDispose();
        }
    }
}
