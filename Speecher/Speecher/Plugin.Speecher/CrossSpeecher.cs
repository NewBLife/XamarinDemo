using Plugin.Speecher.Abstractions;
using System;

namespace Plugin.Speecher
{
  /// <summary>
  /// Cross platform Speecher implemenations
  /// </summary>
  public class CrossSpeecher
  {
    static Lazy<ISpeecher> Implementation = new Lazy<ISpeecher>(() => CreateSpeecher(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static ISpeecher Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static ISpeecher CreateSpeecher()
    {
#if PORTABLE
        return null;
#else
        return new SpeecherImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
