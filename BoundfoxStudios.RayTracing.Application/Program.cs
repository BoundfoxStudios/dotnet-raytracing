using System;
using System.IO;
using System.Threading.Tasks;
using BoundfoxStudios.RayTracing.Core;
using BoundfoxStudios.RayTracing.Core.Outputs;

namespace BoundfoxStudios.RayTracing.Application
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var rayTracer = new RayTracer(1024, 768);
      rayTracer.Progress += remaining => Console.WriteLine("Remaining scan lines: {0}", remaining); 

      var filePath = Path.Combine(Directory.GetCurrentDirectory(), "result.ppm");

      using (var fileStream = new FileStream(filePath, FileMode.Create))
      {
        using (var result = await rayTracer.Go<PpmOutput>())
        {
          await result.CopyToAsync(fileStream);
        }
      }
    }
  }
}
