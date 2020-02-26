using System;
using System.Collections; 
using System.Collections.Generic; 

namespace Rocket_Elevators_Controllers
{
    public class Elevator
    {
        public string  doors, direction;
        public int ID, floor;
        // ArrayList floorRequestList = new ArrayList();
        double[] floorRequestList;

        public Elevator(int ID, int floor) {

            this.ID = ID;
            this.floor = floor;
            this.doors = "CLOSE";
            this.direction = "IDLE";
            this.floorRequestList = new double[] {};
            
        }




        }


    }



