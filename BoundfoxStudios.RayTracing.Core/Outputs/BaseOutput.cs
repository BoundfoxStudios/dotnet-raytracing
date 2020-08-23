using System.IO;
using System.Threading.Tasks;

namespace BoundfoxStudios.RayTracing.Core.Outputs
{
  public abstract class BaseOutput : IOutput
  {
    protected readonly int Width;
    protected readonly int Height;

    public BaseOutput(int width, int height)
    {
      Width = width;
      Height = height;
    }

    public abstract Task WriteHeaderAsync();
    public abstract Task WriteColorAsync(Vector3 color);
    public abstract Task<Stream> FinalizeAsync();
    public abstract ValueTask DisposeAsync();
  }
}
