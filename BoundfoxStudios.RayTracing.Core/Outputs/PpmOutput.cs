using System;
using System.IO;
using System.Threading.Tasks;

namespace BoundfoxStudios.RayTracing.Core.Outputs
{
  public class PpmOutput : BaseOutput
  {
    private StreamWriter _writer;

    public PpmOutput(int width, int height) : base(width, height) { }

    public override async Task WriteHeaderAsync()
    {
      var memoryStream = new MemoryStream();
      _writer = new StreamWriter(memoryStream);
      
      await _writer.WriteLineAsync("P3");
      await _writer.WriteLineAsync($"{Width} {Height}");
      await _writer.WriteLineAsync("255");
    }

    public override async Task WriteColorAsync(Vector3 color)
    {
      if (_writer == null)
      {
        throw new Exception("Header has not been written yet.");
      }
      
      var r = (int) (255.999 * color.X);
      var g = (int) (255.999 * color.Y);
      var b = (int) (255.999 * color.Z);

      await _writer.WriteLineAsync($"{r} {g} {b}");
    }

    public override async Task<Stream> FinalizeAsync()
    {
      await _writer.FlushAsync();

      _writer.BaseStream.Seek(0, SeekOrigin.Begin);

      return _writer.BaseStream;
    }

    public override ValueTask DisposeAsync()
    {
      return _writer.DisposeAsync();
    }
  }
}
