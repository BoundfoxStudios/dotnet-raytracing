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
    private Camera _camera;
    private Vector3 _horizontal;
    private Vector3 _vertical;
    private Vector3 _lowerLeftCorner;

    public Camera Camera
    {
      get => _camera;
      set
      {
        _camera = value;
        
        _horizontal = new Vector3(_camera.ViewportWidth, 0, 0);
        _vertical = new Vector3(0, _camera.ViewportHeight, 0);
        _lowerLeftCorner = _camera.Position - _horizontal / 2 - _vertical / 2 - new Vector3(0, 0, _camera.FocalLength);
      }
    }

    /// <summary>
    /// Progress is called when ever a new scanline is started.
    /// The parameter is the remaining scan lines.
    /// </summary>
    public event Action<int> Progress;

    public RayTracer(int width, int height)
    {
      _width = width;
      _height = height;
      var aspectRatio = (double) _width / _height;

      Camera = new Camera()
      {
        ViewportHeight = 4,
        ViewportWidth = aspectRatio * 4,
        FocalLength = 1,
        Position = new Vector3(0,0,0)
      };
    }

    public async Task<Stream> Go<T>(HittableList objects)
      where T : BaseOutput
    {
      var output = (IOutput) Activator.CreateInstance(typeof(T), _width, _height);

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
          var u = (double) column / (_width - 1);
          var v = (double) row / (_height - 1);
          
          var ray = new Ray(Camera.Position, _lowerLeftCorner + u * _horizontal + v * _vertical);

          await output.WriteColorAsync(ray.Color(objects));
        }
      }

      return await output.FinalizeAsync();
    }
  }
}
