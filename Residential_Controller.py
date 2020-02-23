import time

class Column():
  def __init__(self,floorTotal, elevatorTotal):
    self.ID = "ID"
    self.elevatorList = []
    self.floorTotal = []
    self.CallButtonList = []

    for i in range(1, floorTotal+1):
        self.floorTotal.append(i)
    print("Floor list: ", self.floorTotal)  

    for i in range(1, elevatorTotal+1):
        self.elevatorList.append(Elevator(i, 1))
    print("Total number of elevators:", len(self.elevatorList))

    for i in range(floorTotal):
        if i != 1: 
            callButton = CallButton("DOWN", i)
            self.CallButtonList.append(callButton)
        elif i != floorTotal:
            callButton = CallButton("UP", i)
            self.CallButtonList.append(callButton)

  
        

class CallButton():
  def __init__(self, direction, floor):
    self.direction = direction
    self.floor = floor
    self.light = "OFF"    


class Controller():
  def __init__(self, numberOfColumns, floorTotal, elevatorPerColumn):
    self.columnList = []
    for i in range(numberOfColumns):
      self.columnList.append(Column(floorTotal, elevatorPerColumn))
      # print("text", self.columnList[i].elevatorList)


  def requestElevator(self, direction, floor):
      # print("test input", direction, floor)
      elevator = self.findElevator(direction, floor)
      elevator.floorRequestList.append(floor)
      self.move(elevator, floor)
      # print("request returned elevator: ", elevator.ID)
      return elevator

    
  
  def findElevator(self,direction, floor):

      print("FIND ELEVATOR")
      print('request direction:', direction)
      print('request floor: ', floor)
      elevatorSubList = []
      for elevator in self.columnList[0].elevatorList:
        
        print("elevator ID: ", elevator.ID)
        print('elevator floor: ', elevator.floor)
        print('elevator direction: ', elevator.direction)





        if floor == elevator.floor and elevator.direction == "IDLE":
          # print("case 1")
          elevatorSubList.append(elevator)

        elif (direction == "UP" or direction == "DOWN") and elevator.direction != "IDLE":
          # print("case 2")
          if direction == "UP" and floor > elevator.floor: 
            # print("case 2.1")
            elevatorSubList.append(elevator)
          elif direction == "DOWN" and floor < elevator.floor:
            # print("case 2.2")
            elevatorSubList.append(elevator)

        elif elevator.direction == "IDLE" and floor != elevator.floor :
          # print("case 3")
          elevatorSubList.append(elevator)
          # print("test list", len(elevatorSubList))

      print("Found ELEVATOR")

      return self.findClosestElevator(elevatorSubList, floor)

  def findClosestElevator(self, elevatorSubList, floor):
    closestElevator = elevatorSubList[0]
    closeness = 10

    for elevator in elevatorSubList:
      if abs(floor - elevator.floor) < closeness:
        closeness = abs(floor - elevator.floor)
        closestElevator = elevator   

    return closestElevator

  def requestFloor(self,elevator, floor):
    elevator.floorRequestList.append(floor)

    print("requested floor from inside: ", elevator.floorRequestList)
    self.move(elevator, floor)

    return elevator


  def move(self, elevator, floor):

    while len(elevator.floorRequestList) > 0 :
      # elevator.direction = "UP"
      if elevator.floor < elevator.floorRequestList[0]:
        while elevator.floor < elevator.floorRequestList[0]:
          elevator.floor += 1
          print("current floor: ", elevator.floor)
        self.door(elevator)
        # print("elevatorfloorlist status", elevator.floorRequestList)
        elevator.floorRequestList.pop(0)
        # print("elevatorfloorlist status", elevator.floorRequestList)
  # elevator.direction is "DOWN"
      elif elevator.floor > elevator.floorRequestList[0]:
        while elevator.floor > elevator.floorRequestList[0]:
          elevator.floor -= 1
          print("current floor: ", elevator.floor)
        self.door(elevator)
        # print("elevatorfloorlist status", elevator.floorRequestList)
        elevator.floorRequestList.pop(0)
        # print("elevatorfloorlist status", elevator.floorRequestList)


  def door(self,elevator):

    if elevator.floor == elevator.floorRequestList[0]:
      elevator.door = "OPEN"
      print(elevator.door)
      time.sleep(5)
      elevator.door = "CLOSE"
      print(elevator.door)

      return elevator



class Elevator():
  def __init__(self,ID,floor):
    self.ID = ID
    self.floor = floor
    self.floorRequestList = []  
    # self.currentFloor = 1
    # self.status = "MOVING"
    self.direction = "IDLE"
    self.doors = "CLOSED"
    
    



 
def main():

# Scenario 1

    controller = Controller(1, 10, 2)

    column_test_case_1 = controller.columnList[0]
    
    column_test_case_1.elevatorList[0].floor = 2
    column_test_case_1.elevatorList[0].direction = "IDLE"



    column_test_case_1.elevatorList[1].floor = 6
    column_test_case_1.elevatorList[1].direction = "IDLE"


    userPosition = 3
    userDirection = 'UP'
    userRequestFloor = 7
    best_elevator_scenario_1 = controller.requestElevator(userDirection, userPosition)

    print("The best elevator for scenario 1 is " + str(best_elevator_scenario_1.ID))
    best_elevator_scenario_11 = controller.requestFloor(best_elevator_scenario_1, userRequestFloor)

    print("User has been successfully droppped at floor: " + str(best_elevator_scenario_11.floor))



       # # Scenario 2

    # controller = Controller(1, 10, 2)

    # column_test_case_2 = controller.columnList[0]
    
    # column_test_case_2.elevatorList[0].floor = 10
    # column_test_case_2.elevatorList[0].direction = "IDLE"



    # column_test_case_2.elevatorList[1].floor = 3
    # column_test_case_2.elevatorList[1].direction = "IDLE"


    # userPosition = 1
    # userDirection = 'UP'
    # userRequestFloor = 6

    # best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    # print("The best elevator for scenario 2 is " + str(best_elevator_scenario_2.ID))

    # best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    # print("User has been successfully droppped at floor:" + str(best_elevator_scenario_2.floor))
    


    # userPosition = 3
    # userDirection = 'UP'
    # userRequestFloor = 5


    # best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    # print("The best elevator for scenario 2.1 is " + str(best_elevator_scenario_2.ID))

    # best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    # print("User has been successfully droppped at floor:" + str(best_elevator_scenario_2.floor))

    # userPosition = 9
    # userDirection = 'DOWN'
    # userRequestFloor = 2

    # best_elevator_scenario_2 = controller.requestElevator(userDirection, userPosition)
    # print("The best elevator for scenario 2.2 is " + str(best_elevator_scenario_2.ID))

    # best_elevator_scenario_2 = controller.requestFloor(best_elevator_scenario_2, userRequestFloor)
    # print("User has been successfully droppped at floor:" + str(best_elevator_scenario_2.floor)) 


# Scenario 3 


    # controller = Controller(1, 10, 2)

    # column_test_case_3 = controller.columnList[0]
    
    # column_test_case_3.elevatorList[0].floor = 10
    # column_test_case_3.elevatorList[0].direction = "IDLE"



    # column_test_case_3.elevatorList[1].floor = 3
    # column_test_case_3.elevatorList[1].direction = "UP"
    # controller.move(column_test_case_3.elevatorList[1], 6)



    # userPosition = 3
    # userDirection = 'DOWN'
    # userRequestFloor = 2

    # best_elevator_scenario_3 = controller.requestElevator(userDirection, userPosition)
    # print("The best elevator for scenario 3 is " + str(best_elevator_scenario_3.ID))

    # best_elevator_scenario_3 = controller.requestFloor(best_elevator_scenario_3, userRequestFloor)
    # print("User has been successfully droppped at floor: " + str(best_elevator_scenario_3.floor))
    


    # userPosition = 10
    # userDirection = 'DOWN'
    # userRequestFloor = 3


    # column_test_case_3.elevatorList[1].floor = 6
    # column_test_case_3.elevatorList[1].direction = "IDLE"


    # best_elevator_scenario_3 = controller.requestElevator(userDirection, userPosition)
    # print("The found elevator for scenario 3.1 is " + str(best_elevator_scenario_3.ID))

    # best_elevator_scenario_3 = controller.requestFloor(best_elevator_scenario_3, userRequestFloor)
    # print("User has been successfully droppped at floor: " + str(best_elevator_scenario_3.floor))







main()