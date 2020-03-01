package main

import (
	"fmt"
	"math"
)

// type battery strruct

func main() {

	// fmt.Println("Hello Sam!")
	battery := Battery{floorTotal: 66, basementTotal: 6, columnTotal: 4, elevatorPerColumn: 5}
	battery.NewBattery()
	// fmt.Println(battery)

	// Scenario 1

	battery.columnList[1].elevatorList[0].direction = "DOWN"
	battery.columnList[1].elevatorList[0].floor = 20
	battery.columnList[1].elevatorList[1].direction = "UP"
	battery.columnList[1].elevatorList[1].floor = 3
	battery.columnList[1].elevatorList[2].direction = "DOWN"
	battery.columnList[1].elevatorList[2].floor = 13
	battery.columnList[1].elevatorList[3].direction = "DOWN"
	battery.columnList[1].elevatorList[3].floor = 15
	battery.columnList[1].elevatorList[4].direction = "DOWN"
	battery.columnList[1].elevatorList[4].floor = 6
	var requestedFloor = 20
	battery.AssignElevator(requestedFloor)

	//Scenario 2

	// battery.columnList[2].elevatorList[0].direction = "UP"
	// battery.columnList[2].elevatorList[0].floor = 1
	// battery.columnList[2].elevatorList[0].floorRequestList = append(battery.columnList[2].elevatorList[0].floorRequestList, 21)
	// battery.columnList[2].elevatorList[1].direction = "UP"
	// battery.columnList[2].elevatorList[1].floor = 23
	// battery.columnList[2].elevatorList[2].direction = "DOWN"
	// battery.columnList[2].elevatorList[2].floor = 33
	// battery.columnList[2].elevatorList[3].direction = "DOWN"
	// battery.columnList[2].elevatorList[3].floor = 40
	// battery.columnList[2].elevatorList[4].direction = "UP"
	// battery.columnList[2].elevatorList[4].floor = 39
	// var requestedFloor = 36
	// battery.AssignElevator(requestedFloor)

	//Scenario 3
	// battery.columnList[3].elevatorList[0].direction = "DOWN"
	// battery.columnList[3].elevatorList[0].floor = 58
	// battery.columnList[3].elevatorList[1].direction = "UP"
	// battery.columnList[3].elevatorList[1].floor = 50
	// battery.columnList[3].elevatorList[2].direction = "UP"
	// battery.columnList[3].elevatorList[2].floor = 46
	// battery.columnList[3].elevatorList[3].direction = "UP"
	// battery.columnList[3].elevatorList[3].floor = 1
	// battery.columnList[3].elevatorList[4].direction = "DOWN"
	// battery.columnList[3].elevatorList[4].floor = 60
	// var floorNumber = 54
	// battery.RequestElevator(floorNumber)

	//Scenario 4

	// battery.columnList[0].elevatorList[0].direction = "IDLE"
	// battery.columnList[0].elevatorList[0].floor = -4
	// battery.columnList[0].elevatorList[1].direction = "IDLE"
	// battery.columnList[0].elevatorList[1].floor = 1
	// battery.columnList[0].elevatorList[2].direction = "DOWN"
	// battery.columnList[0].elevatorList[2].floor = -3
	// battery.columnList[0].elevatorList[3].direction = "UP"
	// battery.columnList[0].elevatorList[3].floor = -6
	// battery.columnList[0].elevatorList[4].direction = "DOWN"
	// battery.columnList[0].elevatorList[4].floor = -1
	// var floorNumber = -3
	// battery.RequestElevator(floorNumber)

}

type Battery struct {
	floorTotal        int
	basementTotal     int
	columnTotal       int
	elevatorPerColumn int
	columnList        []Column
}

type Elevator struct {
	ID               int
	floor            int
	direction        string
	floorRequestList []int
}

type Column struct {
	ID            int
	elevatorTotal int
	startFloor    int
	endFloor      int
	elevatorList  []Elevator
	floorList     []int
}

func (b *Battery) NewBattery() {

	floorExcludingBasement := b.floorTotal - b.basementTotal
	avgFloorPerColumn := int(math.Floor(float64((floorExcludingBasement / (b.columnTotal - 1)))))
	// fmt.Println("avgFloorPerColumn", avgFloorPerColumn)
	startFloor := 2
	endFloor := avgFloorPerColumn
	currentColumn := 1
	for currentColumn <= b.columnTotal {

		if currentColumn == 1 {
			column := Column{ID: currentColumn, elevatorTotal: b.elevatorPerColumn, startFloor: -b.basementTotal, endFloor: -1}
			b.columnList = append(b.columnList, column)

			b.columnList[currentColumn-1].floorList = append(b.columnList[currentColumn-1].floorList, 1)
			for i := b.columnList[currentColumn-1].endFloor; i >= b.columnList[currentColumn-1].startFloor; i-- {
				b.columnList[currentColumn-1].floorList = append(b.columnList[currentColumn-1].floorList, i)
			}
			fmt.Println("this is floorlist", b.columnList[currentColumn-1].floorList)

			for i := 1; i <= b.elevatorPerColumn; i++ {
				elevator := Elevator{ID: i}
				b.columnList[currentColumn-1].elevatorList = append(b.columnList[currentColumn-1].elevatorList, elevator)

			}

		} else {
			column := Column{ID: currentColumn, elevatorTotal: b.elevatorPerColumn, startFloor: startFloor, endFloor: endFloor}
			b.columnList = append(b.columnList, column)
			startFloor = endFloor + 1
			endFloor = endFloor + avgFloorPerColumn

			b.columnList[currentColumn-1].floorList = append(b.columnList[currentColumn-1].floorList, 1)
			for i := b.columnList[currentColumn-1].startFloor; i <= b.columnList[currentColumn-1].endFloor; i++ {
				b.columnList[currentColumn-1].floorList = append(b.columnList[currentColumn-1].floorList, i)
			}
			fmt.Println("this is floorlist", b.columnList[currentColumn-1].floorList)

			for i := 1; i <= b.elevatorPerColumn; i++ {
				elevator := Elevator{ID: i}
				b.columnList[currentColumn-1].elevatorList = append(b.columnList[currentColumn-1].elevatorList, elevator)

			}

		}
		currentColumn++

	}

}

func (b *Battery) AssignElevator(requestedFloor int) *Column {
	var bestColumn Column

	for i, eachColumn := range b.columnList {
		if requestedFloor <= b.columnList[i].endFloor && requestedFloor >= b.columnList[i].startFloor {
			bestColumn = eachColumn
		}
	}

	fmt.Println("best Column for your requested floor is: ", bestColumn.ID)
	// fmt.Println("")

	// sets user direction for top or basement floors
	if bestColumn.ID == 1 {
		userDirection := "DOWN"
		userFloor := 1
		foundElevator := bestColumn.findElevator(userDirection, requestedFloor, userFloor)
		fmt.Println("Best elevator for current scenario is: ", foundElevator.ID)
	} else {
		userDirection := "UP"
		userFloor := 1
		foundElevator := bestColumn.findElevator(userDirection, requestedFloor, userFloor)
		fmt.Println("Best elevator for current scenario is: ", foundElevator.ID)
	}

	return &bestColumn
}
func (bestColumn *Column) findElevator(userDirection string, requestedFloor, userFloor int) Elevator {
	fmt.Println("userDirection is", userDirection)
	fmt.Println("userFloor  is", userFloor)
	elevatorSubList := []Elevator{}
	// fmt.Println("bestColumn.elevatorList", len(bestColumn.elevatorList))
	for i := 0; i < len(bestColumn.elevatorList); i++ {

		// fmt.Println("elevator ID {0}", bestColumn.elevatorList[i].ID)
		// fmt.Println("elevator floor {0}", bestColumn.elevatorList[i].floor)
		// fmt.Println("elevator direction {0}", bestColumn.elevatorList[i].direction)

		if userFloor < bestColumn.elevatorList[i].floor && userDirection != bestColumn.elevatorList[i].direction {
			elevatorSubList = append(elevatorSubList, bestColumn.elevatorList[i])
		} else if userFloor == bestColumn.elevatorList[i].floor && userDirection == bestColumn.elevatorList[i].direction {
			elevatorSubList = append(elevatorSubList, bestColumn.elevatorList[i])

		}

	}

	closestElevator := elevatorSubList[0]
	closeness := 10

	for i := 0; i < len(elevatorSubList); i++ {
		{
			// System.Console.WriteLine("userFloor: {0}", userFloor);
			// System.Console.WriteLine("elevator.floor: {0}", elevator.floor);
			if int(math.Abs(float64(userFloor-elevatorSubList[i].floor))) < closeness {
				closeness = int(math.Abs(float64(userFloor - elevatorSubList[i].floor)))
				closestElevator = elevatorSubList[i]
			}

		}

	}
	return closestElevator
}

func (b *Battery) RequestElevator(floorNumber int) *Column {
	var bestColumn Column

	for i, eachColumn := range b.columnList {
		if floorNumber <= b.columnList[i].endFloor && floorNumber >= b.columnList[i].startFloor {
			bestColumn = eachColumn
		}
	}

	fmt.Println("best Column for your requested floor is: ", bestColumn.ID)

	// sets user direction for top or basement floors
	if bestColumn.ID == 1 {
		userDirection := "UP"
		userDestination := 1
		foundElevator := bestColumn.returnElevator(userDirection, floorNumber, userDestination)
		fmt.Println("Best elevator for current scenario is: ", foundElevator.ID)
	} else {
		userDirection := "DOWN"
		userDestination := 1
		foundElevator := bestColumn.returnElevator(userDirection, floorNumber, userDestination)
		fmt.Println("Best elevator for current scenario is: ", foundElevator.ID)
	}

	return &bestColumn
}
func (bestColumn *Column) returnElevator(userDirection string, floorNumber, userDestination int) Elevator {
	fmt.Println("userDirection is", userDirection)
	elevatorSubList := []Elevator{}
	// fmt.Println("bestColumn.elevatorList", len(bestColumn.elevatorList))
	for i := 0; i < len(bestColumn.elevatorList); i++ {

		if userDestination < bestColumn.elevatorList[i].floor && userDirection == bestColumn.elevatorList[i].direction {
			elevatorSubList = append(elevatorSubList, bestColumn.elevatorList[i])
		} else if userDestination > bestColumn.elevatorList[i].floor && userDirection == bestColumn.elevatorList[i].direction {
			elevatorSubList = append(elevatorSubList, bestColumn.elevatorList[i])

		}

	}

	closestElevator := elevatorSubList[0]
	closeness := 10

	for i := 0; i < len(elevatorSubList); i++ {
		{

			if int(math.Abs(float64(userDestination-elevatorSubList[i].floor))) < closeness {
				closeness = int(math.Abs(float64(userDestination - elevatorSubList[i].floor)))
				closestElevator = elevatorSubList[i]
			}

		}

	}
	return closestElevator
}
