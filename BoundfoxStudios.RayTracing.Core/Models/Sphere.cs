using System;

namespace BoundfoxStudios.RayTracing.Core.Models
{
  public struct Sphere : IHittable
  {
    public Vector3 Center { get; }
    public double Radius { get; }

    public Sphere(Vector3 center, double radius)
    {
      Center = center;
      Radius = radius;
    }
    
    public bool Hit(Ray ray, double tMin, double tMax, out HitRecord hit)
    {
      var oc = ray.Origin - Center;
      var a = ray.Direction.LengthSquared;
      var halfB = Vector3.Dot(oc, ray.Direction);
      var c = oc.LengthSquared - Radius * Radius;
      var discriminant = halfB * halfB - a * c;

      hit = default;

      if (discriminant > 0)
      {
        var root = Math.Sqrt(discriminant);

        var temp = (-halfB - root) / a;

        if (temp < tMax && temp > tMin)
        {
          hit.T = temp;
          hit.Point = ray.At(hit.T);
          
          var outwardNormal = (hit.Point - Center) / Radius;
          hit.SetFaceNormal(ray, outwardNormal);
          return true;
        }

        temp = (-halfB + root) / a;
        
        if (temp < tMax && temp > tMin)
        {
          hit.T = temp;
          hit.Point = ray.At(hit.T);
          
          var outwardNormal = (hit.Point - Center) / Radius;
          hit.SetFaceNormal(ray, outwardNormal);
          return true;
        }
      }

      return false;
    }
  }
}
