using System;
using System.Threading;

namespace MTS.Core.GlobalLibrary.Factories
{
    public static class CancellationTokenSourceFactory
    {
        // Summary:
        //     Initializes a new instance of the System.Threading.CancellationTokenSource class.
        public static CancellationTokenSource Create()
        {
            return new CancellationTokenSource();
        }

        // Summary:
        //     Initializes a new instance of the System.Threading.CancellationTokenSource class
        //     that will be canceled after the specified delay in milliseconds.
        //
        // Parameters:
        //   millisecondsDelay:
        //     The time interval in milliseconds to wait before canceling this System.Threading.CancellationTokenSource.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     millisecondsDelay is less than -1.
        public static CancellationTokenSource Create(int millisecondsDelay)
        {
            return new CancellationTokenSource(millisecondsDelay);
        }

        // Summary:
        //     Initializes a new instance of the System.Threading.CancellationTokenSource class
        //     that will be canceled after the specified time span.
        //
        // Parameters:
        //   delay:
        //     The time interval to wait before canceling this System.Threading.CancellationTokenSource.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     delay.System.TimeSpan.TotalMilliseconds is less than -1 or greater than System.Int32.MaxValue.
        public static CancellationTokenSource Create(TimeSpan delay)
        {
            return new CancellationTokenSource(delay);
        }
    }
}
