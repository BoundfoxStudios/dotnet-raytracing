using System.Collections.Generic;
using BoundfoxStudios.RayTracing.Core.Models;

namespace BoundfoxStudios.RayTracing.Core
{
  public class HittableList : IHittable
  {
    private readonly IList<IHittable> _objects = new List<IHittable>();
    
    public bool Hit(Ray ray, double tMin, double tMax, out HitRecord hit)
    {
      hit = default;
      
      var hitAnything = false;
      var closestSoFar = tMax;

      foreach (var @object in _objects)
      {
        if (@object.Hit(ray, tMin, closestSoFar, out hit))
        {
          hitAnything = true;
          closestSoFar = hit.T;
        }
      }

      return hitAnything;
    }

    public void Clear()
    {
      _objects.Clear();
    }
    
    public void Add(IHittable @object)
    {
      _objects.Add(@object);
    }
  }
}
