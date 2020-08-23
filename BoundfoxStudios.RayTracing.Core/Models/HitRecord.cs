namespace BoundfoxStudios.RayTracing.Core.Models
{
  public struct HitRecord
  {
    public Vector3 Point { get; set; }
    public Vector3 Normal { get; private set; }
    public double T { get; set; }
    public bool FrontFace { get; private set; }

    public void SetFaceNormal(Ray ray, Vector3 outwardNormal)
    {
      FrontFace = Vector3.Dot(ray.Direction, outwardNormal) < 0;
      Normal = FrontFace ? outwardNormal : -outwardNormal;
    }
  }
}
