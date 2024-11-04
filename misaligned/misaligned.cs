using System;
using System.Diagnostics;

namespace MisalignedSpace
{
  class Misaligned
  {
    static int printColorMap()
    {
      string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
      string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };
      int majorIndex = 0, mainorIndex = 0;
      for (majorIndex = 0; majorIndex < 5; majorIndex++)
      {
        for (mainorIndex = 0; mainorIndex < 5; mainorIndex++)
        {
          Console.WriteLine("{0} | {1} | {2}", majorIndex * 5 + mainorIndex, majorColors[majorIndex], minorColors[majorIndex]);
        }
      }
      return majorIndex * mainorIndex;
    }
    static virtual void Main(string[] args)
    {
      ColorMappingValidator.ValidateColorMapOutput();
       Console.WriteLine("Tests failed due to a potential bug!");
    }
  }
}
