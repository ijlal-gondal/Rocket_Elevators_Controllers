

class Column{
  constructor(floorTotal, elevatorTotal){
    this.ID = "ID";
    this.elevatorList = [];
    this.floorTotal = [];
    this.CallButtonList = [];

    for (let i=1; i < floorTotal; i++){
        this.floorTotal.push(i);
    console.log(this.floorTotal);  
    }
    for i in range(elevatorTotal):
        this.elevatorList.push(Elevator(i, 1))
    console.log(this.elevatorList.length)

    for i in range(1, floorTotal):
        if i != 1: 
            callButton = CallButton("DOWN", i)
            this.CallButtonList.push(callButton)
        else if i != floorTotal:
            callButton = CallButton("UP", i)
            this.CallButtonList.push(callButton)

  }
}
        

class CallButton():
   __init__(this, direction, floor):
    this.direction = direction
    this.floor = floor
    this.light = "OFF"    


class Controller():
   __init__(this, numberOfColumns, floorTotal, elevatorPerColumn):
    this.columnList = []
    for i in range(numberOfColumns):
      this.columnList.push(Column(floorTotal, elevatorPerColumn))
      console.log("text", this.columnList[i].elevatorList)

  //  requestElevator(this,floor,direction):
  //   best_elevator = this.requestElevator(direction, floor)
  //   this.move(best_elevator, floor)
  //   return best_elevator

  requestElevator(this, direction, floor){
      console.log("test input", direction, floor)
      // this.columnList[0].CallButtonList.push(floor)
      // console.log("request stop list", this.columnList[0].CallButtonList)
      let elevator = this.findElevator(direction, floor)
      elevator.floorRequestList.push(floor)
      this.move(elevator, floor)
      console.log("request gives us an elevator : ", elevator)
      return elevator
      //return this.requestFloor(elevator,floor)
    }
  findElevator(this,direction, floor):

      console.log("FIND ELEVATOR")
      let elevatorSubList = []
      for elevator in this.columnList[0].elevatorList:
        
        console.log(elevator.ID)
        console.log(elevator.floor)
        console.log(elevator.direction)

        console.log('direction', direction)
        console.log('floor', floor)
        console.log('elevator floor', elevator.floor)
        console.log('elevator direction', elevator.direction)

        if floor == elevator.floor and elevator.direction == "IDLE":
          console.log("11")
          elevatorSubList.push(elevator)

        else if (direction == "UP" or direction == "DOWN") and elevator.direction != "IDLE":
          console.log("12")
          if direction == "UP" and floor > elevator.floor: 
            console.log("12.4")
            elevatorSubList.push(elevator)
          else if direction == "DOWN" and floor < elevator.floor:
            console.log("12.99")
            elevatorSubList.push(elevator)

        else if elevator.direction == "IDLE" and floor != elevator.floor :
          console.log("13", elevator.ID)
          elevatorSubList.push(elevator)
          console.log("test ELEVATOR", elevatorSubList.length)

      console.log("Found ELEVATOR", elevatorSubList)

      return this.findClosestElevator(elevatorSubList, floor)

   findClosestElevator(this, elevatorSubList, floor):
    closestElevator = elevatorSubList[0]
    let closeness = 10

    for elevator in elevatorSubList:
      console.log('fllllllllllopooor',floor)
      console.log('ellllllllllllllll',elevator.floor)
      if Math.abs(floor - elevator.floor) < closeness:
        closeness = Math.abs(floor - elevator.floor)
        closestElevator = elevator   

    return closestElevator

   requestFloor(this,elevator, floor):
    elevator.floorRequestList.push(floor)

    console.log("elevator", elevator.floorRequestList)
    this.move(elevator, floor)

    return elevator


   move(this, elevator, floor):

    while elevator.floorRequestList.length > 0 :
      // elevator.direction = "UP"
      if elevator.floor < elevator.floorRequestList[0]:
        while elevator.floor < elevator.floorRequestList[0]:
          elevator.floor += 1;
          console.log("lemon", elevator.floor)
        this.door(elevator)
        console.log("elevatorfloorlist", elevator.floorRequestList)
        elevator.floorRequestList.pop(0)
        console.log("elevatorfloorlist 2", elevator.floorRequestList)
  // elevator.direction is "DOWN"
      else if elevator.floor > elevator.floorRequestList[0]:
        while elevator.floor > elevator.floorRequestList[0]:
          elevator.floor -= 1
          console.log("watermelon", elevator.floor)
        this.door(elevator)
        console.log("elevatorfloorlist", elevator.floorRequestList)
        elevator.floorRequestList.pop(0)
        console.log("elevatorfloorlist 2", elevator.floorRequestList)
      // else:
      //   console.log("Tomato")

   door(this,elevator):

    if elevator.floor == elevator.floorRequestList[0]:
      elevator.door = "OPEN"
      console.log(elevator.door)
      time.sleep(5)
      elevator.door = "CLOSE"
      console.log(elevator.door)

      return elevator



class Elevator():
   __init__(this,ID,floor):
    this.ID = ID
    this.floor = floor
    this.floorRequestList = []  
    // this.currentFloor = 1
    // this.status = "MOVING"
    this.direction = "IDLE"
    this.doors = "CLOSED"
    
    



 
 function main():

// Scenario 1

    controller = new Controller(1, 10, 2)

    // column_test_case_1 = controller.columnList[0]
    
    // column_test_case_1.elevatorList[0].floor = 2
    // column_test_case_1.elevatorList[0].direction = "IDLE"



    // column_test_case_1.elevatorList[1].floor = 6
    // column_test_case_1.elevatorList[1].direction = "IDLE"


    // userPosition = 3
    // userDirection = 'UP'
    // userRequestFloor = 7
    // best_elevator_scenario_1 = controller.requestElevator(userDirection, userPosition)

    // console.log("The found elevator for scenario 1 is " + str(best_elevator_scenario_1.ID))
    // best_elevator_scenario_11 = controller.requestFloor(best_elevator_scenario_1, userRequestFloor)

    // console.log("The found elevator is moving to " + str(best_elevator_scenario_11.floor))



    


// Scenario 2 


    controller = Controller(1, 10, 2)

    column_test_case_3 = controller.columnList[0]
    
    column_test_case_3.elevatorList[0].floor = 10
    column_test_case_3.elevatorList[0].direction = "IDLE"



    column_test_case_3.elevatorList[1].floor = 3
    column_test_case_3.elevatorList[1].direction = "UP"
    column_test_case_3.elevatorList[1].floorRequestList.push(6)


    userPosition = 3
    userDirection = 'DOWN'
    userRequestFloor = 2

    best_elevator_scenario_3 = controller.requestElevator(userDirection, userPosition)
    console.log("The best elevator for scenario 3 is " + str(best_elevator_scenario_3.ID))

    best_elevator_scenario_3 = controller.requestFloor(best_elevator_scenario_3, userRequestFloor)
    console.log("The found elevator is at floor " + str(best_elevator_scenario_3.floor))
    


    userPosition = 10
    userDirection = 'DOWN'
    userRequestFloor = 3


    best_elevator_scenario_3 = controller.requestElevator(userDirection, userPosition)
    console.log("The found elevator for scenario 3 is " + str(best_elevator_scenario_3.ID))

    best_elevator_scenario_3 = controller.requestFloor(best_elevator_scenario_3, userRequestFloor)
    console.log("The found elevator is at floor " + str(best_elevator_scenario_3.floor))

    // userPosition = 9
    // userDirection = 'DOWN'
    // userRequestFloor = 2

    // best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    // console.log("The best found elevator for scenario 2 is " + str(best_elevator_scenario_2.ID))

    // best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    // console.log("The found elevator is at floor " + str(best_elevator_scenario_2.floor))


    // // Scenario 3

    // controller = Controller(1, 10, 2)

    // column_test_case_2 = controller.columnList[0]
    
    // column_test_case_2.elevatorList[0].floor = 10
    // column_test_case_2.elevatorList[0].direction = "IDLE"



    // column_test_case_2.elevatorList[1].floor = 3
    // column_test_case_2.elevatorList[1].direction = "IDLE"


    // userPosition = 1
    // userDirection = 'UP'
    // userRequestFloor = 6

    // best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    // console.log("The best elevator for scenario 2 is " + str(best_elevator_scenario_2.ID))

    // best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    // console.log("The found elevator is at floor " + str(best_elevator_scenario_2.floor))
    


    // userPosition = 3
    // userDirection = 'UP'
    // userRequestFloor = 5


    // best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    // console.log("The found elevator for scenario 2 is " + str(best_elevator_scenario_2.ID))

    // best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    // console.log("The found elevator is at floor " + str(best_elevator_scenario_2.floor))

    // userPosition = 9
    // userDirection = 'DOWN'
    // userRequestFloor = 2

    // best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    // console.log("The best found elevator for scenario 2 is " + str(best_elevator_scenario_2.ID))

    // best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    // console.log("The found elevator is at floor " + str(best_elevator_scenario_2.floor))


          // if len(elevatorSubList) == 0:
      //     elevatorSubList.push(this.columnList[0].elevatorList[0])

    // best_elevator_scenario_1 = column_test_case_1.requestElevator(userPosition, userDirection)
    // console.log("SECOND ELEVATOR ID " + str(column_test_case_1.elevatorList[1].ID))
  // console.log("FIRST ELEVATOR ID " + str(column_test_case_1.elevatorList[0].ID))
  // console.log('test1', column_test_case_1.elevatorList[0].ID)
    // findElevator('UP', column_test_case_1.elevatorList, 5)

    // best_elevator = column_test_case_1.findCallButton("UP", 2)
    // console.log("BEST ELEVATOR ID " + str(best_elevator.ID))
  
    // column_test_case_1.findElevator("up",4)
    // column_test_case_1.elevatorList[0].currentFloor = 1

    // column_test_case_1.elevatorList[1].currentFloor = 1


    // call_button = column_test_case_1.findCallButton(10,2)


    // column_test_case_1.requestElevator(1, 'Up')


    // best_elevator = call_button.findElevator(1,"Up")

    //  callButton = CallButton()

    // else if floor != elevator.floor:
    //   elevator.door == "CLOSE"
    // callButton = CallButton(this.direction, this.floor)

      // elevator = this.findElevator(direction,floor)
      // elevator.floorRequestList.push(floor)
      // elevator.move
    
    // controller1 = Controller(2,10)
   
    // // elevator = this.setDirection(direction, elevator)
    //    setDirection(this, direction, elevator):
 
    // if direction == "UP":
    //   elevator.direction = "UP"
    // else if direction == "DOWN":
    //   elevator.direction == "DOWN"

      // if this.direction == (UP or DOWN or Up or Down) and this.floor <= column.floorTotal
    // elevator = Elevator.CallButtonRequestList.push(direction,floor)
    // console.log(floor,direction)
    
    // elevator = Elevator(1,2)
    // controller = Controller(2,10)
    // controller.move(callButton.direction,elevator.ID)

    //  CallingElevator(direction, floor):
    //     if CallButton == "Pressed":
    //         this.StopList.push(User.floor,User.direction)
    //     ActivateCallButton()
    //     FindElevator()
  //  status(this, elevator, floor):

  //   if len(elevator.floorRequestList) != [] and floor != elevator.floor:
  //     elevator.status = "MOVING"
  //   else if len(elevator.CallButtonRequestList) != [] and floor != elevator.floor:
  //     elevator.status = "MOVING"
  //   else if len(elevator.floorRequestList) != [] and floor == elevator.floor:
  //     elevator.status = "STOPPED"
  //   else if len(elevator.CallButtonRequestList) != [] and floor == elevator.floor:
  //     elevator.status = "STOPPED"
  //   else if len(elevator.floorRequestList) == [] and len(elevator.CallButtonRequestList) == []:
  //     elevator.status = "IDLE"

  //     return elevator

    // if direction == elevator.direction and floor == elevator.floor and elevator.status == "STOPPED":
    // return elevator
    //  FindElevator(direction, floor):

   // console.log("elevator: ", elevator)
    // console.log("Moving :", direction)
    // return ElevatorNumber


main()



