namespace BoundfoxStudios.RayTracing.Core.Models
{
  public interface IHittable
  {
    bool Hit(Ray ray, double tMin, double tMax, out HitRecord hit);
  }
}
