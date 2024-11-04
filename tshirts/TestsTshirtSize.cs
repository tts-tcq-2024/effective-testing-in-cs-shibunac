
using System;
using System.Diagnostics;
namespace TshirtSpace

{
    class TestsTshirtSize
    {
        Tshirt tshirt = new Tshirt();

        static void Main(string[] args)
        {
            Debug.Assert(tshirt.Size(37) == "S");
            Debug.Assert(tshirt.Size(40) == "M");
            Debug.Assert(tshirt.Size(43) == "L");
            Debug.Assert(tshirt.Size(38) == "M"); // Medium (new test)
            Debug.Assert(tshirt.Size(42) == "L"); // Medium (edge case)
            Console.WriteLine("Test failure indicates bug in the implementation!");
        }
    }
}
