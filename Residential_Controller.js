
class Column {
    constructor(floorTotal, elevatorTotal) {
        this.ID = "ID";
        this.elevatorList = [];
        this.floorTotal = [];
        this.CallButtonList = [];

        for (let i = 1; i < floorTotal+1; i++) {
            this.floorTotal.push(i);
            console.log(this.floorTotal);
        }

        for (let i = 1; i < elevatorTotal+1; i++) {
            this.elevatorList.push(new Elevator(i, 1))
            console.log(this.elevatorList)
        }


    }
}


class Controller {
    constructor(numberOfColumns, floorTotal, elevatorPerColumn) {
        this.columnList = [];
        for (let i = 0; i < numberOfColumns; i++) {
            this.columnList.push(new Column(floorTotal, elevatorPerColumn))
            // console.log("elevatorList", this.columnList[i].elevatorList)

        }
    }
    requestElevator(direction, floor) {
        // console.log("test input", direction, floor)
        let elevator = this.findElevator(direction, floor)
        elevator.floorRequestList.push(floor)
        this.move(elevator, floor)
        console.log("request gives us an elevator : ", elevator)
        return elevator
   
    }
    findElevator(direction, floor) {

        console.log("FIND ELEVATOR")
        console.log('request direction:', direction)
        console.log('request floor: ', floor)
        let elevatorSubList = [];
        this.columnList[0].elevatorList.forEach(function(elevator) {

            console.log("elevaror ID", elevator.ID);
            console.log('elevator floor', elevator.floor);
            console.log('elevator direction', elevator.direction);

            if (floor == elevator.floor && elevator.direction == "IDLE") {
                // console.log("case 1");
                elevatorSubList.push(elevator);

            }
            else if ((direction == "UP" || direction == "DOWN") && elevator.direction != "IDLE") {
                // console.log("case 2");
                if (direction == "UP" && floor > elevator.floor) {
                    // console.log("case 2.1");
                    elevatorSubList.push(elevator);

                }

                else if (direction == "DOWN" && floor < elevator.floor) {
                    // console.log("case 2.2");
                    elevatorSubList.push(elevator);


                }
            }

            else if (elevator.direction == "IDLE" && floor != elevator.floor) {
                // console.log("case 3");
                elevatorSubList.push(elevator);


                // console.log("ELEVATOR list status", elevatorSubList.length);

            }
            console.log("Found ELEVATOR", elevatorSubList);
        });
           return this.findClosestElevator(elevatorSubList, floor);

    }



    findClosestElevator(elevatorSubList, floor) {
        let closestElevator = elevatorSubList[0];
        let closeness = 10;
        // console.log('elevatorSubList[0]',elevatorSubList);
        elevatorSubList.forEach(function(elevator) {
              console.log('Math status',floor);
              console.log('Math status 2',elevator.floor);
            if (Math.abs(floor - elevator.floor) < closeness) {
                closeness = Math.abs(floor - elevator.floor);
                closestElevator = elevator;
            }
        });
        return closestElevator

    }

    requestFloor(elevator, floor) {
        elevator.floorRequestList.push(floor)

        console.log("requested floor from inside", elevator.floorRequestList)
        this.move(elevator, floor)

        return elevator
    }

    move(elevator, floor) {

        while (elevator.floorRequestList.length > 0) {
            // elevator.direction = "UP"
            if (elevator.floor < elevator.floorRequestList[0]) {
                while (elevator.floor < elevator.floorRequestList[0]) {
                    elevator.floor ++;
                    console.log("current floor: ", elevator.floor)
                }
                    this.door(elevator)
                    // console.log("elevatorfloorlist status", elevator.floorRequestList)
                    elevator.floorRequestList.pop(0)
                    // console.log("elevatorfloorlist status", elevator.floorRequestList)
                
            }
            // elevator.direction is "DOWN"
            else if (elevator.floor > elevator.floorRequestList[0]) {
                while (elevator.floor > elevator.floorRequestList[0]) {
                    elevator.floor --;
                    console.log("current floor: ", elevator.floor);
                }
                    this.door(elevator);
                    // console.log("elevatorfloorlist status", elevator.floorRequestList);
                    elevator.floorRequestList.pop(0);
                    // console.log("elevatorfloorlist status", elevator.floorRequestList);

                
            }
        }
    }
    door(elevator) {

        if (elevator.floor == elevator.floorRequestList[0]) {
            elevator.door = "OPEN";
            console.log(elevator.door);
            // time.sleep(5);
            elevator.door = "CLOSE";
            console.log(elevator.door);

            return elevator;
        }
    }
}
class Elevator {
    constructor(ID, floor) {
        this.ID = ID;
        this.floor = floor;
        this.floorRequestList = [];
        // this.currentFloor = 1
        // this.status = "MOVING"
        this.direction = "IDLE";
        this.doors = "CLOSED";


    }
}
main()
function main() {

    // Scenario 1

    let controller = new Controller(1, 10, 2);

    column_test_case_1 = controller.columnList[0]

    column_test_case_1.elevatorList[0].floor = 2
    column_test_case_1.elevatorList[0].direction = "IDLE"



    column_test_case_1.elevatorList[1].floor = 6
    column_test_case_1.elevatorList[1].direction = "IDLE"


    userPosition = 3
    userDirection = 'UP'
    userRequestFloor = 7
    best_elevator_scenario_1 = controller.requestElevator(userDirection, userPosition)

    console.log("The found elevator for scenario 1 is " + (best_elevator_scenario_1.ID))
    best_elevator_scenario_11 = controller.requestFloor(best_elevator_scenario_1, userRequestFloor)

    console.log("The found elevator is at " + (best_elevator_scenario_11.floor))



    // Scenario 2

    // controller = new Controller(1, 10, 2)

    // column_test_case_2 = controller.columnList[0]

    // column_test_case_2.elevatorList[0].floor = 10
    // column_test_case_2.elevatorList[0].direction = "IDLE"



    // column_test_case_2.elevatorList[1].floor = 3
    // column_test_case_2.elevatorList[1].direction = "IDLE"


    // userPosition = 1
    // userDirection = 'UP'
    // userRequestFloor = 6

    // best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    // console.log("The best elevator for scenario 2 is " + (best_elevator_scenario_2.ID))

    // best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    // console.log("The found elevator is at floor " + (best_elevator_scenario_2.floor))



    // userPosition = 3
    // userDirection = 'UP'
    // userRequestFloor = 5


    // best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    // console.log("The found elevator for scenario 2 is " + (best_elevator_scenario_2.ID))

    // best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    // console.log("The found elevator is at floor " + (best_elevator_scenario_2.floor))

    // userPosition = 9
    // userDirection = 'DOWN'
    // userRequestFloor = 2

    // best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    // console.log("The best found elevator for scenario 2 is " + (best_elevator_scenario_2.ID))

    // best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    // console.log("The found elevator is at floor " + (best_elevator_scenario_2.floor))


    // // Scenario 3 


    // let controller = new Controller(1, 10, 2);

    // column_test_case_3 = controller.columnList[0];

    // column_test_case_3.elevatorList[0].floor = 10;
    // column_test_case_3.elevatorList[0].direction = "IDLE";



    // column_test_case_3.elevatorList[1].floor = 3;
    // column_test_case_3.elevatorList[1].direction = "UP";
    // controller.move(column_test_case_3.elevatorList[1], 6)


    // let userPosition = 3
    // let userDirection = 'DOWN'
    // let userRequestFloor = 2

    // best_elevator_scenario_3 = controller.requestElevator(userDirection, userPosition);
    // console.log("The best elevator for scenario 3 is " + (best_elevator_scenario_3.ID));

    // best_elevator_scenario_3 = controller.requestFloor(best_elevator_scenario_3, userRequestFloor);
    // console.log("The found elevator is at floor " + (best_elevator_scenario_3.floor));



    // userPosition = 10
    // userDirection = 'DOWN'
    // userRequestFloor = 3

    // column_test_case_3.elevatorList[1].floor = 6
    // column_test_case_3.elevatorList[1].direction = "IDLE"

    // best_elevator_scenario_3 = controller.requestElevator(userDirection, userPosition)
    // console.log("The found elevator for scenario 3 is " + (best_elevator_scenario_3.ID))

    // best_elevator_scenario_3 = controller.requestFloor(best_elevator_scenario_3, userRequestFloor)
    // console.log("The found elevator is at floor " + (best_elevator_scenario_3.floor))







}
