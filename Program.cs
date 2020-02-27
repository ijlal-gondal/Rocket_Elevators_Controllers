using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    class Program
    {
        static void Main(string[] args)
        {
        


        // //Scenario 1
        var b1 = new Battery(66, 6, 5, 4);
    
        b1.columnList[1].elevatorList[0].direction = "DOWN";
        b1.columnList[1].elevatorList[0].floor = 20;
        b1.columnList[1].elevatorList[1].direction = "UP";
        b1.columnList[1].elevatorList[1].floor = 3;
        b1.columnList[1].elevatorList[2].direction = "DOWN";
        b1.columnList[1].elevatorList[2].floor = 13;
        b1.columnList[1].elevatorList[3].direction = "DOWN";
        b1.columnList[1].elevatorList[3].floor = 15;
        b1.columnList[1].elevatorList[4].direction = "DOWN";
        b1.columnList[1].elevatorList[4].floor = 6;
        b1.AssignElevator(20);

        //Scenario 2

        // var b2 = new Battery(66, 6, 5, 4);

        // b2.columnList[2].elevatorList[0].direction = "UP";
        // b2.columnList[2].elevatorList[0].floor = 1;
        // b2.columnList[2].elevatorList[0].floorRequestList.Add(21);
        // b2.columnList[2].elevatorList[1].direction = "UP";
        // b2.columnList[2].elevatorList[1].floor = 23;
        // b2.columnList[2].elevatorList[2].direction = "DOWN";
        // b2.columnList[2].elevatorList[2].floor = 33;
        // b2.columnList[2].elevatorList[3].direction = "DOWN";
        // b2.columnList[2].elevatorList[3].floor = 40;
        // b2.columnList[2].elevatorList[4].direction = "UP";
        // b2.columnList[2].elevatorList[4].floor = 39;
        // b2.AssignElevator(36);

        //Scenario 3

        // var b3 = new Battery(66, 6, 5, 4);

        // b3.columnList[3].elevatorList[0].direction = "DOWN";
        // b3.columnList[3].elevatorList[0].floor = 58;
        // b3.columnList[3].elevatorList[1].direction = "UP";
        // b3.columnList[3].elevatorList[1].floor = 50;
        // b3.columnList[3].elevatorList[2].direction = "UP";
        // b3.columnList[3].elevatorList[2].floor = 46;
        // b3.columnList[3].elevatorList[3].direction = "UP";
        // b3.columnList[3].elevatorList[3].floor = 1;
        // b3.columnList[3].elevatorList[4].direction = "DOWN";
        // b3.columnList[3].elevatorList[4].floor = 60;
        // b3.RequestElevator(54);

        //Scenario 4

        // var b4 = new Battery(66, 6, 5, 4);

        // b4.columnList[0].elevatorList[0].direction = "IDLE";
        // b4.columnList[0].elevatorList[0].floor = -4;
        // b4.columnList[0].elevatorList[1].direction = "IDLE";
        // b4.columnList[0].elevatorList[1].floor = 1;
        // b4.columnList[0].elevatorList[2].direction = "DOWN";
        // b4.columnList[0].elevatorList[2].floor = -3;
        // b4.columnList[0].elevatorList[3].direction = "UP";
        // b4.columnList[0].elevatorList[3].floor = -6;
        // b4.columnList[0].elevatorList[4].direction = "DOWN";
        // b4.columnList[0].elevatorList[4].floor = -1;
        // b4.RequestElevator(-3);




        }
 
    }
}

 
        // Console.WriteLine("floor {0}", b1.columnList[0].floorList[1]);
        // Console.WriteLine("elevator {0}", b1.columnList[0].elevatorList[0].ID);
        // Console.WriteLine("column {0}", b1.columnList[0].ID);

                // b1.RequestElevator();


            // Console.WriteLine();