using System;
using System.IO;
using System.Threading.Tasks;
using BoundfoxStudios.RayTracing.Core;
using BoundfoxStudios.RayTracing.Core.Models;
using BoundfoxStudios.RayTracing.Core.Outputs;

namespace BoundfoxStudios.RayTracing.Application
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var rayTracer = new RayTracer(1024, 768);
      rayTracer.Progress += remaining => Console.WriteLine("Remaining scan lines: {0}", remaining);
      
      var world = new HittableList();
      world.Add(new Sphere(new Vector3(0, 0, -1), 0.5d));
      world.Add(new Sphere(new Vector3(0, -50.5d, -1), 50));

      var filePath = Path.Combine(Directory.GetCurrentDirectory(), "result.ppm");

      using (var fileStream = new FileStream(filePath, FileMode.Create))
      {
        using (var result = await rayTracer.Go<PpmOutput>(world))
        {
          await result.CopyToAsync(fileStream);
        }
      }
    }
  }
}
