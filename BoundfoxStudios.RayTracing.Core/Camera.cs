namespace BoundfoxStudios.RayTracing.Core
{
  public struct Camera
  {
    public double ViewportHeight { get; set; }
    public double ViewportWidth { get; set; }
    public double FocalLength { get; set; }
    
    public Vector3 Position { get; set; }
  }
}
