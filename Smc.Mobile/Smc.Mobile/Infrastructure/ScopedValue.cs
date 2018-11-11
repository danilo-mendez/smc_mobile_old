using System;
using System.Collections.Generic;
using System.Text;

namespace SMC.Mobile.Infrastructure
{
    public class ScopedValue<T>
    {
        public ScopedValue(T value = default(T))
        {
            this.Value = value;
        }

        public IDisposable BeginScope(T newValue)
        {
            var oldValue = this.Value;
            this.Value = newValue;
            this.ValueStarted?.Invoke(oldValue, newValue);
            return new SimpleDisposable(() =>
            {
                this.Value = oldValue;
                this.ValueEnded?.Invoke(newValue, oldValue);
            });
        }

        public T Value { get; private set; }

        public event ScopedValueChanged<T> ValueStarted;
        public event ScopedValueChanged<T> ValueEnded;
    }

    public delegate void ScopedValueChanged<T>(T oldValue, T newValue);
}
