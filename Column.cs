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
            this.ID = ID;
            System.Console.WriteLine("Columnn ID: {0} ", ID);
            if (startFloor < 0)
            {
                floorList.Add(1);
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
                System.Console.WriteLine("\n");

            }
            else
            {

                floorList.Add(1);
                for (int i = startFloor; i <= endFloor; i++)
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
                System.Console.WriteLine("\n");

            }

            
            // Console.WriteLine(string.Join(" | ", elevatorList));

        }


      
    }
}


