using FluentAssertions;
using Xunit;

namespace BoundfoxStudios.RayTracing.Core.Tests
{
  public class Vector3Tests
  {
    [Fact]
    public void CanBeCreated()
    {
      var sut = new Vector3(1, 2, 3);

      sut.X.Should().Be(1);
      sut.Y.Should().Be(2);
      sut.Z.Should().Be(3);
    }

    [Fact]
    public void CanBeNegated()
    {
      var vector3 = new Vector3(1, 2, 3);

      var sut = -vector3;

      sut.X.Should().Be(-1);
      sut.Y.Should().Be(-2);
      sut.Z.Should().Be(-3);
    }

    [Fact]
    public void CanBeMultipliedWithAFactor()
    {
      var vector3 = new Vector3(1, 2, 3);

      var sut = vector3 * 2;

      sut.X.Should().Be(2);
      sut.Y.Should().Be(4);
      sut.Z.Should().Be(6);
    }

    [Fact]
    public void CanBeDividedByAFactor()
    {
      var vector3 = new Vector3(2, 4, 6);

      var sut = vector3 / 2;

      sut.X.Should().Be(1);
      sut.Y.Should().Be(2);
      sut.Z.Should().Be(3);
    }

    [Fact]
    public void TwoVectorsCanBeAdded()
    {
      var vectorA = new Vector3(1, 2, 3);
      var vectorB = new Vector3(4, 5, 6);

      var sut = vectorA + vectorB;

      sut.X.Should().Be(5);
      sut.Y.Should().Be(7);
      sut.Z.Should().Be(9);
    }

    [Fact]
    public void CanCalculateLengthSquared()
    {
      var sut = new Vector3(1, 2, 3);

      sut.LengthSquared.Should().Be(14);
    }

    [Fact]
    public void CanCalculateLength()
    {
      var sut = new Vector3(0, 10, 0);

      sut.Length.Should().Be(10);
    }

    [Fact]
    public void CanCalculateCross()
    {
      var vectorA = new Vector3(1, 2, 1);
      var vectorB = new Vector3(2, 4, 1);

      var sut = Vector3.Cross(vectorA, vectorB);

      sut.X.Should().Be(-2);
      sut.Y.Should().Be(1);
      sut.Z.Should().Be(0);
    }

    [Fact]
    public void CanCalculateDot()
    {
      var vectorA = new Vector3(1, 2, 3);
      var vectorB = new Vector3(4, 5, 6);

      var sut = Vector3.Dot(vectorA, vectorB);

      sut.Should().Be(32);
    }
  }
}
