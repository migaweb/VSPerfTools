using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace ValueTypesVsReftypesPerf
{
  [MemoryDiagnoser]
  public class Program
  {
    static void Main(string[] args)
    {
      var summary = BenchmarkRunner.Run<Program>();
    }

    [Benchmark]
    public void ManyClasses()
    {
      Random rnd = new Random();
      var list = new List<Point_Class>();

      for (int i = 0; i < 1_000_000; i++)
      {
        list.Add(new Point_Class() { X = rnd.Next(), Y = rnd.Next() });
      }

      // Won't be in the list
      list.Contains(new Point_Class() { X = -1, Y = -1 });
    }

    [Benchmark]
    public void ManyStructs_NoOverload()
    {
      Random rnd = new Random();
      var list = new List<Point_Struct_NoOverload>();

      for (int i = 0; i < 1_000_000; i++)
      {
        list.Add(new Point_Struct_NoOverload() { x = rnd.Next(), y = rnd.Next() });
      }

      // Won't be in the list
      list.Contains(new Point_Struct_NoOverload() { x = -1, y = -1 });
    }

    [Benchmark]
    public void ManyStructs_ProperOverload()
    {
      Random rnd = new Random();
      var list = new List<Point_Struct_ProperImplementation>();

      for (int i = 0; i < 1_000_000; i++)
      {
        list.Add(new Point_Struct_ProperImplementation() { x = rnd.Next(), y = rnd.Next() });
      }

      // Won't be in the list
      list.Contains(new Point_Struct_ProperImplementation() { x = -1, y = -1 });
    }
  }
}
