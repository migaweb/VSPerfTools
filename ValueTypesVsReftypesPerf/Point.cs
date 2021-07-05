using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypesVsReftypesPerf
{
  public class Point_Class
  {
    public int X { get; set; }
    public int Y { get; set; }
  }

  /// <summary>
  /// A value type without proper equals methods
  /// </summary>
  public struct Point_Struct_NoOverload
  {
    public int x;
    public int y;
  }

  /// <summary>
  ///  A value type that properly implements the equals method to avoid boxing and
  /// </summary>
  public struct Point_Struct_ProperImplementation : IEquatable<Point_Struct_ProperImplementation>
  {
    public int x;
    public int y;

    public override bool Equals(object obj)
    {
      return obj is Point_Struct_ProperImplementation point && Equals(point);
    }

    public bool Equals(Point_Struct_ProperImplementation other)
    {
      return x == other.x &&
             y == other.y;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(x, y);
    }

    public static bool operator ==(Point_Struct_ProperImplementation left, Point_Struct_ProperImplementation right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(Point_Struct_ProperImplementation left, Point_Struct_ProperImplementation right)
    {
      return !(left == right);
    }
  }
}
