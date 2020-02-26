using System;
using System.Collections;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    public class Column
    {
        // public string ID;
        public int i, ID, floorTotal, elevatorTotal;
        public List<Elevator> elevatorList = new List<Elevator>();
        public List<int> floorList = new List<int>();

        public Column(int ID, int elevatorTotal, int startFloor, int endFloor)
        {
            // this.ID = ID;
            if (startFloor < 0)
            {
                for (int i = startFloor; i >= endFloor; i--)
                {
                    floorList.Add(i);
                }
                System.Console.WriteLine("Floor List");
                Console.WriteLine(string.Join(" | ", floorList));

                System.Console.WriteLine("Elevator List");
                for (i = 1; i <= elevatorTotal; i++)
                {
                    elevatorList.Add(new Elevator(i, 1));
                    System.Console.Write(elevatorList[i - 1].ID + " | ");

                }
                System.Console.WriteLine("");

            }
            else
            {


                for (int i = startFloor; i < endFloor; i = i + 1)
                {
                    floorList.Add(i);

                }
                System.Console.WriteLine("Floor List");
                Console.WriteLine(string.Join(" | ", floorList));

                System.Console.WriteLine("Elevator List");
                for (i = 1; i <= elevatorTotal; i++)
                {
                    elevatorList.Add(new Elevator(i, 1));
                    System.Console.Write(elevatorList[i - 1].ID + " | ");

                }
                System.Console.WriteLine("");

            }


            // Console.WriteLine(string.Join(" | ", elevatorList));

        }


        // {
        //     return "Happy coding!";
        // }
    }
}


