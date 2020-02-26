using System;
using System.Collections;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    public class Battery
    {

        public int i, floorTotal, elevatorTotal, columnTotal, elevatorPerColumn, basementTotal, avgFloorPerColumn;
        public int floorExcludingBasement, currentColumn, startFloor, endFloor;
        public List<Column> columnList = new List<Column>();


        public Battery(int floorTotal, int basementTotal, int elevatorPerColumn, int columnTotal)
        {

            this.elevatorPerColumn = elevatorPerColumn;
            this.floorTotal = floorTotal;
            this.columnTotal = columnTotal;
            this.basementTotal = basementTotal;


            // if (columnTotal == 1)
            // {
            //     elevatorTotal = elevatorPerColumn * columnTotal;
            //     for (int i = 0; i < columnTotal; i++)
            //     {
            //         columnList.Add(new Column(elevatorTotal, floorTotal));
            //         Console.WriteLine(columnList);
            //     }
            // }
            // else
            // {
            floorExcludingBasement = floorTotal - basementTotal;
            avgFloorPerColumn = (int)Math.Floor((double)(floorExcludingBasement / (columnTotal - 1)));
            Console.WriteLine(avgFloorPerColumn);
            startFloor = 2;
            endFloor = avgFloorPerColumn;
            currentColumn = 1;


            while (currentColumn <= columnTotal)
            {
                if (currentColumn == 1)
                {
                    
                    {
                        // Console.WriteLine("test {0}", elevatorPerColumn);
                        columnList.Add(new Column(currentColumn, elevatorPerColumn, -1, -basementTotal));

                    }

                }
                else
                {
                        for (i = startFloor; i < avgFloorPerColumn; i++)
                        columnList.Add(new Column(currentColumn, elevatorPerColumn, startFloor, endFloor));
                        System.Console.WriteLine("in prep");
                }
                currentColumn++;

            }


            // for (i = 0; i < elevatorTotal + 1; i++)
            // {
            //     columnList.Add(new Column(i, 1));
            //     // Console.WriteLine(elevatorList);
            // }
        }


    }


    // {
    //     return "Happy coding!";
    // }
}

