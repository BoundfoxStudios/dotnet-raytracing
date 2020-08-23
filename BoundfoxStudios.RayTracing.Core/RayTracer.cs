using System;
using System.IO;
using System.Threading.Tasks;
using BoundfoxStudios.RayTracing.Core.Outputs;

namespace BoundfoxStudios.RayTracing.Core
{
  public class RayTracer
  {
    private readonly int _width;
    private readonly int _height;

    /// <summary>
    /// Progress is called when ever a new scanline is started.
    /// The parameter is the remaining scan lines.
    /// </summary>
    public event Action<int> Progress;

    public RayTracer(int width, int height)
    {
      _width = width;
      _height = height;
    }

    public async Task<Stream> Go<T>()
      where T : BaseOutput
    {
      var output = (BaseOutput) Activator.CreateInstance(typeof(T), _width, _height);

      if (output == null)
      {
        throw new Exception($"Can not create an Output from {typeof(T)}");
      }

      await output.WriteHeaderAsync();
      
      for (var row = _height - 1; row >= 0; row--)
      {
        Progress?.Invoke(row);
        
        for (var column = 0; column < _width; column++)
        {
          var color = new Vector3((double) column / (_width - 1), (double) row / (_height - 1), 0.25d);

          await output.WriteColorAsync(color);
        }
      }

      return await output.FinalizeAsync();
    }
  }
}
