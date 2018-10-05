using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Veloxorede
{
  public class PauseTokenSource
  {
    private volatile TaskCompletionSource<bool> paused_;
    internal static readonly Task CompletedTask = Task.FromResult(true);

    public bool IsPaused
    {
      get => paused_ != null;
      set
      {
        if (value)
        {
          Interlocked.CompareExchange(ref paused_, 
            new TaskCompletionSource<bool>(), null);
        }
        else
        {
          for (;;)
          {
            var tcs = paused_;
            if (tcs == null)
            {
              return;
            }

            if (Interlocked.CompareExchange(ref paused_, null, tcs) == tcs)
            {
              tcs.SetResult(true);
              break;
            }
          }
        }
      }
    }

    public PauseToken Token
    {
      get => new PauseToken(this);
    }

    internal Task Wait()
    {
      return (paused_?.Task ?? CompletedTask);
    }
  }
}
