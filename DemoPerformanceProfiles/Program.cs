using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoPerformanceProfiles
{
  class Program
  {
    public static List<Person> People = new List<Person>();
    static void Main(string[] args)
    {
      for (int i = 0; i < 1000000; i++)
      {
        CreatePerson();
      }
    }

    public static void CreatePerson()
    {
      People.Add(new Person { Name = "Test Person", Age = 34 });
    }
  }

  public class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }

  }
}
