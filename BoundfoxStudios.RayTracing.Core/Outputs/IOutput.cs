using System;
using System.IO;
using System.Threading.Tasks;

namespace BoundfoxStudios.RayTracing.Core.Outputs
{
  public interface IOutput : IAsyncDisposable
  {
    Task WriteHeaderAsync();
    Task WriteColorAsync(Vector3 color);
    Task<Stream> FinalizeAsync();
  }
}
