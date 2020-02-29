using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    class Program
    {
        static void Main(string[] args)
        {
            var b1 = new Battery(66, 6, 5, 4);

            b1.Scenario1();
            // b1.Scenario2();
            // b1.Scenario3();
            // b1.Scenario4();







        }


    }
}


// Console.WriteLine("floor {0}", b1.columnList[0].floorList[1]);
// Console.WriteLine("elevator {0}", b1.columnList[0].elevatorList[0].ID);
// Console.WriteLine("column {0}", b1.columnList[0].ID);

// b1.RequestElevator();


// Console.WriteLine();