using System;

namespace BoundfoxStudios.RayTracing.Core
{
  public struct Vector3
  {
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }

    public Vector3(double x, double y, double z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public double Length => Math.Sqrt(LengthSquared);
    public double LengthSquared => Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2);
    public Vector3 UnitVector => this / Length;

    public static Vector3 operator +(Vector3 left, Vector3 right) => new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    public static Vector3 operator *(Vector3 left, double t) => new Vector3(left.X * t, left.Y * t, left.Z * t);
    public static Vector3 operator /(Vector3 left, double t) => left * (1 / t);
    public static Vector3 operator -(Vector3 vector) => new Vector3(-vector.X, -vector.Y, -vector.Z);

    public static double Dot(Vector3 left, Vector3 right) => left.X * right.X + left.Y * right.Y + left.Z * right.Z;

    public static Vector3 Cross(Vector3 left, Vector3 right) => new Vector3(
      left.Y * right.Z - left.Z * right.Y,
      left.Z * right.X - left.X * right.Z,
      left.X * right.Y - left.Y * right.X
    );
  }
}
