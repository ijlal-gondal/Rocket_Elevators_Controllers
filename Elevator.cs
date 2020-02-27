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
        public List<int> floorRequestList = new List<int>();

        public Elevator(int ID, int floor) {

            this.ID = ID;
            this.floor = 1;
            this.doors = "CLOSE";
            this.direction = "IDLE";
            this.floorRequestList = new List<int>();
            
        }




        }


    }



