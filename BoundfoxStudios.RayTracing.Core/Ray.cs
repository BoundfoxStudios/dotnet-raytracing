using BoundfoxStudios.RayTracing.Core.Models;

namespace BoundfoxStudios.RayTracing.Core
{
  public struct Ray
  {
    public Vector3 Origin { get; }
    public Vector3 Direction { get; }

    public Ray(Vector3 origin, Vector3 direction)
    {
      Origin = origin;
      Direction = direction;
    }

    public Vector3 At(double t) => Origin + Direction * t;

    public Vector3 Color(IHittable world)
    {
      HitRecord rec = default;
      if (world.Hit(this, 0, double.PositiveInfinity, ref rec))
      {
        return 0.5d * (rec.Normal + new Vector3(1, 1, 1));
      }

      var direction = Direction.UnitVector;
      var t = 0.5d * (direction.Y + 1);
      return (1d - t) * new Vector3(1, 1, 1) + t * new Vector3(0.5d, 0.7d, 1);
    }
  }
}
