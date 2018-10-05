using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veloxorede
{
  public class PauseToken
  {
    private readonly PauseTokenSource source_;

    internal PauseToken(PauseTokenSource src)
    {
      source_ = src;
    }

    public bool IsPaused
    {
      get => source_?.IsPaused ?? false;
    }

    public Task WaitWhilePausedAsync()
    {
      return (IsPaused ? source_.Wait() : PauseTokenSource.CompletedTask);
    }
  }
}
