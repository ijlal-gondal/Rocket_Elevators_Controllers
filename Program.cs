using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    class Program
    {
        static void Main(string[] args)
        {
        var b1 = new Battery(66, 6, 5, 4);
 
        Console.WriteLine("floor {0}", b1.columnList[0].floorList[0]);
        Console.WriteLine("elevator {0}", b1.columnList[0].elevatorList[0].ID);
        // Console.WriteLine("column {0}", b1.columnList[0].ID);


            // Console.WriteLine();
        }
 
    }
}

