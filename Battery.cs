using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rocket_Elevators_Controllers
{
    public class Battery
    {

        public int i, floorTotal, elevatorTotal, columnTotal, elevatorPerColumn, basementTotal, avgFloorPerColumn;
        public int floorExcludingBasement, currentColumn, startFloor, endFloor, requestedFloor, floorNumber;
        public int closeness, userFloor, userDestination;
        public List<Column> columnList = new List<Column>();
        public List<Elevator> elevatorSubList = new List<Elevator>();
        public Column bestColumn;
        public string userDirection;
        public Elevator closestElevator, foundElevator, movedElevator;


        public Battery(int floorTotal, int basementTotal, int elevatorPerColumn, int columnTotal)
        {

            this.elevatorPerColumn = elevatorPerColumn;
            this.floorTotal = floorTotal;
            this.columnTotal = columnTotal;
            this.basementTotal = basementTotal;



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
                    // for (i = currentColumn; i < columnTotal; i++)

                    columnList.Add(new Column(currentColumn, elevatorPerColumn, startFloor, endFloor));
                    startFloor = endFloor + 1;
                    endFloor = endFloor + avgFloorPerColumn;

                    // System.Console.WriteLine("in prep");
                }


                currentColumn++;
            }




        }
        // assigns elevator for user at RC
        public void AssignElevator(int requestedFloor)
        {

            this.bestColumn = this.columnList.Where(c => c.floorList.Contains(requestedFloor)).FirstOrDefault();
            System.Console.WriteLine("best Column for your requested floor is: {0} \n", bestColumn.ID);

            // sets user direction for top or basement floors
            if (bestColumn.ID == 1)
            {
                userDirection = "DOWN";
                userFloor = 1;
            }
            else
            {
                userDirection = "UP";
                userFloor = 1;
            }
            // looks for elevator       
            foundElevator = findElevator(userDirection, requestedFloor, userFloor);
            System.Console.WriteLine("Best elevator for current scenario is: {0} \n", foundElevator.ID);
            if (foundElevator.floor != userFloor)
            {
                foundElevator.floorRequestList.Add(userFloor);
                movedElevator = move(foundElevator, userFloor);
            }

            foundElevator.floorRequestList.Add(requestedFloor);
            movedElevator = move(foundElevator, requestedFloor);

            System.Console.WriteLine("The user has been dropped at {0}", movedElevator.floor);



        }

        public Elevator findElevator(string userDirection, int requestedFloor, int userFloor)
        {


            System.Console.WriteLine("userDirection is {0}", userDirection);
            // this.bestElevator = this.columnList.Where(c => e.elevatorList.Contains(floorNumber)).FirstOrDefault();
            // System.Console.WriteLine("best Column for your requested floor is: {0}", bestColumn.ID);
            foreach (Elevator elevator in bestColumn.elevatorList)
            {
                System.Console.WriteLine("elevator ID {0}", elevator.ID);
                System.Console.WriteLine("elevator floor {0}", elevator.floor);
                System.Console.WriteLine("elevator direction {0}", elevator.direction);

                if ((userFloor < elevator.floor) && (userDirection != elevator.direction))
                {
                    elevatorSubList.Add(elevator);
                }
                else if ((userFloor == elevator.floor) && (userDirection == elevator.direction))
                {
                    elevatorSubList.Add(elevator);

                }
                // else{
                //     elevatorSubList.Add(elevator);
                // }

                // System.Console.WriteLine(elevatorSubList[0]);

            }

            System.Console.WriteLine("\n");
            return findClosestElevator(elevatorSubList, userFloor);




        }
        public Elevator findClosestElevator(List<Elevator> elevatorSubList, int userFloor)
        {
            closestElevator = elevatorSubList[0];
            closeness = 10;
            // System.Console.WriteLine(elevatorSubList[0].ID);

            foreach (Elevator elevator in elevatorSubList)
            {
                // System.Console.WriteLine("userFloor: {0}", userFloor);
                // System.Console.WriteLine("elevator.floor: {0}", elevator.floor);
                if (Math.Abs(userFloor - elevator.floor) < closeness)
                {
                    closeness = Math.Abs(userFloor - elevator.floor);
                    closestElevator = elevator;
                }

            }
            // System.Console.WriteLine("closest elevator: {0}", closestElevator.ID);
            return closestElevator;



        }
        // assigns elevator for user anywhere else other than RC
        public void RequestElevator(int floorNumber)
        {

            this.bestColumn = this.columnList.Where(c => c.floorList.Contains(floorNumber)).FirstOrDefault();
            System.Console.WriteLine("best Column for your requested floor is: {0} \n", bestColumn.ID);

            // sets user direction for top or basement floors
            if (bestColumn.ID == 1)
            {
                userDirection = "UP";
                userDestination = 1;
            }
            else
            {
                userDirection = "DOWN";
                userDestination = 1;
            }

            // looks for elevator       
            foundElevator = returnElevator(userDirection, floorNumber, userDestination);
            System.Console.WriteLine("Best elevator for current scenario is: {0} \n", foundElevator.ID);
            if (foundElevator.floor != floorNumber)
            {
                foundElevator.floorRequestList.Add(floorNumber);
                movedElevator = move(foundElevator, floorNumber);
            }
            foundElevator.floorRequestList.Add(userDestination);
            movedElevator = move(foundElevator, userDestination);

            System.Console.WriteLine("The user has been dropped at floor: {0}", movedElevator.floor);

        }
        public Elevator returnElevator(string userDirection, int floorNumber, int userDestination)
        {


            System.Console.WriteLine("userDirection is {0}", userDirection);
            // this.bestElevator = this.columnList.Where(c => e.elevatorList.Contains(floorNumber)).FirstOrDefault();
            // System.Console.WriteLine("best Column for your requested floor is: {0}", bestColumn.ID);
            foreach (Elevator elevator in bestColumn.elevatorList)
            {
                System.Console.WriteLine("elevator ID {0}", elevator.ID);
                System.Console.WriteLine("elevator floor {0}", elevator.floor);
                System.Console.WriteLine("elevator direction {0}", elevator.direction);

                if ((userDestination < elevator.floor) && (userDirection == elevator.direction))
                {
                    elevatorSubList.Add(elevator);
                }
                else if ((userDestination > elevator.floor) && (userDirection == elevator.direction))
                {
                    elevatorSubList.Add(elevator);
                }


            }
            System.Console.WriteLine("\n");
            return returnClosestElevator(elevatorSubList, userDestination);

        }
        public Elevator returnClosestElevator(List<Elevator> elevatorSubList, int userDestination)
        {
            closestElevator = elevatorSubList[0];
            closeness = 10;

            foreach (Elevator elevator in elevatorSubList)
            {
                if (Math.Abs(userDestination - elevator.floor) < closeness)
                {
                    closeness = Math.Abs(userDestination - elevator.floor);
                    closestElevator = elevator;
                }

            }
            return closestElevator;

        }


        public Elevator move(Elevator elevator, int requestedFloor)
        {
            Console.Write("Elevator Current floor: {0}", elevator.floor);
            while (elevator.floorRequestList.Count > 0)
            {
                // elevator.direction = "UP"
                if (elevator.floor < elevator.floorRequestList[0])
                {
                    while (elevator.floor < elevator.floorRequestList[0])
                    {

                        elevator.floor++;
                        System.Console.Write(" - " + elevator.floor);
                    }
                    Console.WriteLine("\nElevator has arrived");
                    // Console.WriteLine("elevatorfloorlist status", elevator.floorRequestList)
                    door(elevator);
                    elevator.floorRequestList.RemoveAt(0);
                    // Console.WriteLine("elevatorfloorlist status", elevator.floorRequestList)
                    // return door(elevator);

                }
                // elevator.direction is "DOWN"
                else if (elevator.floor > elevator.floorRequestList[0])
                {
                    while (elevator.floor > elevator.floorRequestList[0])
                    {
                        elevator.floor--;
                        Console.Write(" - " + elevator.floor);
                    }
                    Console.WriteLine("\nElevator has arrived");
                    // Console.WriteLine("elevatorfloorlist status", elevator.floorRequestList);
                    door(elevator);
                    elevator.floorRequestList.RemoveAt(0);
                    // Console.WriteLine("elevatorfloorlist status", elevator.floorRequestList);



                }


            }

            return elevator;
        }
        public Elevator door(Elevator elevator)
        {

            if (elevator.floor == elevator.floorRequestList[0])
            {
                elevator.doors = "OPEN";
                Console.WriteLine(elevator.doors);
                // time.sleep(5);
                elevator.doors = "CLOSE";
                Console.WriteLine(elevator.doors);


            }
            return elevator;
        }
        public void Scenario1()
        {
            // //Scenario 1


            columnList[1].elevatorList[0].direction = "DOWN";
            columnList[1].elevatorList[0].floor = 20;
            columnList[1].elevatorList[1].direction = "UP";
            columnList[1].elevatorList[1].floor = 3;
            columnList[1].elevatorList[2].direction = "DOWN";
            columnList[1].elevatorList[2].floor = 13;
            columnList[1].elevatorList[3].direction = "DOWN";
            columnList[1].elevatorList[3].floor = 15;
            columnList[1].elevatorList[4].direction = "DOWN";
            columnList[1].elevatorList[4].floor = 6;
            AssignElevator(20);
        }
        public void Scenario2()
        {
            // //Scenario 2


            columnList[2].elevatorList[0].direction = "UP";
            columnList[2].elevatorList[0].floor = 1;
            columnList[2].elevatorList[0].floorRequestList.Add(21);
            columnList[2].elevatorList[1].direction = "UP";
            columnList[2].elevatorList[1].floor = 23;
            columnList[2].elevatorList[2].direction = "DOWN";
            columnList[2].elevatorList[2].floor = 33;
            columnList[2].elevatorList[3].direction = "DOWN";
            columnList[2].elevatorList[3].floor = 40;
            columnList[2].elevatorList[4].direction = "UP";
            columnList[2].elevatorList[4].floor = 39;
            AssignElevator(36);
        }
        public void Scenario3()
        {
            // //Scenario 3


            columnList[3].elevatorList[0].direction = "DOWN";
            columnList[3].elevatorList[0].floor = 58;
            columnList[3].elevatorList[1].direction = "UP";
            columnList[3].elevatorList[1].floor = 50;
            columnList[3].elevatorList[2].direction = "UP";
            columnList[3].elevatorList[2].floor = 46;
            columnList[3].elevatorList[3].direction = "UP";
            columnList[3].elevatorList[3].floor = 1;
            columnList[3].elevatorList[4].direction = "DOWN";
            columnList[3].elevatorList[4].floor = 60;
            RequestElevator(54);
        }
        public void Scenario4()
        {
            // //Scenario 4


            columnList[0].elevatorList[0].direction = "IDLE";
            columnList[0].elevatorList[0].floor = -4;
            columnList[0].elevatorList[1].direction = "IDLE";
            columnList[0].elevatorList[1].floor = 1;
            columnList[0].elevatorList[2].direction = "DOWN";
            columnList[0].elevatorList[2].floor = -3;
            columnList[0].elevatorList[3].direction = "UP";
            columnList[0].elevatorList[3].floor = -6;
            columnList[0].elevatorList[4].direction = "DOWN";
            columnList[0].elevatorList[4].floor = -1;
            RequestElevator(-3);
        }





    }


}

