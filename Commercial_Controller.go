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
	fmt.Println(battery)
	// fmt.Println("myke", battery.columnList[0])

	var requestedFloor = 2
	battery.assignElevator(requestedFloor)

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

// func createElevator()

func (b *Battery) NewBattery() {
	// b := Battery{floorTotal: floorTotal}
	// b.basementTotal = basementTotal
	// b.columnTotal = columnTotal
	// b.elevatorPerColumn = elevatorPerColumn
	floorExcludingBasement := b.floorTotal - b.basementTotal
	avgFloorPerColumn := int(math.Floor(float64((floorExcludingBasement / (b.columnTotal - 1)))))
	fmt.Println("avgFloorPerColumn", avgFloorPerColumn)
	startFloor := 2
	endFloor := avgFloorPerColumn
	currentColumn := 1
	for currentColumn <= b.columnTotal {

		if currentColumn == 1 {
			column := Column{ID: currentColumn, elevatorTotal: b.elevatorPerColumn, startFloor: -b.basementTotal, endFloor: -1}
			b.columnList = append(b.columnList, column)

			column.floorList = append(column.floorList, 1)
			for i := column.endFloor; i >= column.startFloor; i-- {
				column.floorList = append(column.floorList, i)
			}
			fmt.Println("this is floorlist", column.floorList)
			// fmt.Println(string.Join(" | ", floorList));

			for i := 1; i <= b.elevatorPerColumn; i++ {
				elevator := Elevator{ID: i}
				column.elevatorList = append(column.elevatorList, elevator)
				// fmt.Println(column.elevatorList[i-1].ID + " | ")

			}
			fmt.Println("this is elevator list", column.elevatorList[0])
			// fmt.Println("this is how columns looks like",)

		} else {
			column := Column{ID: currentColumn, elevatorTotal: b.elevatorPerColumn, startFloor: startFloor, endFloor: endFloor}
			b.columnList = append(b.columnList, column)
			startFloor = endFloor + 1
			endFloor = endFloor + avgFloorPerColumn

			column.floorList = append(column.floorList, 1)
			for i := column.startFloor; i <= column.endFloor; i++ {
				column.floorList = append(column.floorList, i)
			}
			fmt.Println("this is floorlist", column.floorList)
			// fmt.Println(string.Join(" | ", floorList));

			for i := 1; i <= b.elevatorPerColumn; i++ {
				elevator := Elevator{ID: i}
				column.elevatorList = append(column.elevatorList, elevator)
				// fmt.Println(column.elevatorList[i-1].ID + " | ")

			}
			fmt.Println("this is elevatorlist", column.elevatorList[0])
			// fmt.Println("\n")

		}
		currentColumn++

	}

}

func (b *Battery) assignElevator(requestedFloor int) *Column {
	var bestColumn Column

	for i, eachColumn := range b.columnList {
		if requestedFloor <= b.columnList[i].endFloor && requestedFloor >= b.columnList[i].startFloor {
			bestColumn = eachColumn
		}
	}
	fmt.Println("columnList", b.columnList[0].elevatorList[0])
	fmt.Println("best Column for your requested floor is: ", bestColumn.ID)
	// fmt.Println("")

	// sets user direction for top or basement floors
	if bestColumn.ID == 1 {
		userDirection := "DOWN"
		userFloor := 1
		foundElevator := bestColumn.findElevator(userDirection, requestedFloor, userFloor)
		fmt.Println("Best elevator for current scenario is: {0} \n", foundElevator.ID)
	} else {
		userDirection := "UP"
		userFloor := 1
		foundElevator := bestColumn.findElevator(userDirection, requestedFloor, userFloor)
		fmt.Println("Best elevator for current scenario is: {0} \n", foundElevator.ID)
	}

	return &bestColumn
}
func (bestColumn *Column) findElevator(userDirection string, requestedFloor, userFloor int) Elevator {
	fmt.Println("userDirection is", userDirection)
	elevatorSubList := []Elevator{}
	fmt.Println("bestColumn.elevatorList", len(bestColumn.elevatorList))
	for i := 0; i < len(bestColumn.elevatorList); i++ {

		fmt.Println("elevator ID {0}", bestColumn.elevatorList[i].ID)
		fmt.Println("elevator floor {0}", bestColumn.elevatorList[i].floor)
		fmt.Println("elevator direction {0}", bestColumn.elevatorList[i].direction)

		if userFloor < bestColumn.elevatorList[i].floor && userDirection != bestColumn.elevatorList[i].direction {
			elevatorSubList = append(elevatorSubList, bestColumn.elevatorList[i])
		} else if userFloor == bestColumn.elevatorList[i].floor && userDirection == bestColumn.elevatorList[i].direction {
			elevatorSubList = append(elevatorSubList, bestColumn.elevatorList[i])

		}

	}

	closestElevator := elevatorSubList[0]
	closeness := 10
	// System.Console.WriteLine(elevatorSubList[0].ID);

	for i := 0; i < len(elevatorSubList); i++ {
		{
			// System.Console.WriteLine("userFloor: {0}", userFloor);
			// System.Console.WriteLine("elevator.floor: {0}", elevator.floor);
			if int(math.Abs(float64(userFloor-bestColumn.elevatorList[i].floor))) < closeness {
				closeness = int(math.Abs(float64(userFloor - bestColumn.elevatorList[i].floor)))
				closestElevator = elevatorSubList[i]
			}

		}
		// System.Console.WriteLine("closest elevator: {0}", closestElevator.ID);

	}
	return closestElevator
}

// 	return selectedColumn

// }

// bestColumn := b.columnList.Where(c.floorList.Contains(requestedFloor)).FirstOrDefault();
// fmt.Println("best Column for your requested floor is: {0} \n", bestColumn.ID);
// floorNumber, requestedFloor int

// bestCol := Column{}

// for i := 0; i < len(b.columnList); i++ {

// 	for _, k := range b.columnList[i].floorList {

// 		if floorNumber == 1 && requestedFloor == k {
// 			bestCol := b.columnList[i]
// 			// bestCol.findElevator(floorNumber, requestedFloor)
// 			return &bestCol

// 		} else if floorNumber == k && requestedFloor == 1 {
// 			bestCol := b.columnList[i]
// 			// bestCol.findElevator(floorNumber, requestedFloor)
// 			return &bestCol
// 		}
// 	}
// }
// // bestCol.findElevator(floorNumber, requestedFloor)
// fmt.Println("bestCol.ID", bestCol.ID)
// return &bestCol

// func(c *NewBattery) createElevatorAndFloor() {

// }

// func createFloors(startFloor int, endFloor int) *Elevator {
// 	if startFloor < 0 {

// 		floorList = append(floorList, 1)
// 		for i := startFloor; i >= endFloor; i-- {
// 			floorList.append(i)
// 		}
// 		fmt.Println()("Floor List")
// 		fmt.Println(string.Join(" | ", floorList))

// 		fmt.Println()("Elevator List")
// 		for i := 1; i <= elevatorTotal; i++ {
// 			elevatorList.append(Elevator(i, 1))
// 			System.Console.Write(elevatorList[i-1].ID + " | ")

// 		}
// 		fmt.Println()("\n")
// 	}

// }
// b := Battery{basementTotal: basementTotal}
// b := Battery{columnTotal: columnTotal}
// b := Battery{elevatorPerColumn: elevatorPerColumn}

// fmt.Println(currentColumn)
// }
// if startFloor < 0 {
// 	floorList.append(1)
// 	for i := startFloor; i >= endFloor; i-- {
// 		floorList.append(floorList, i)
// 	}
// 	fmt.Println("Floor List")
// 	fmt.Println(string.Join(" | ", floorList))

// 	fmt.Println("Elevator List")
// 	for i := 1; i <= elevatorTotal; i++ {
// 		elevatorList.append(elevatorList, Elevator(i, 1))
// 		System.Console.Write(elevatorList[i-1].ID + " | ")

// 	}
// 	fmt.Println("\n")

// } else {

// 	floorList.append(1)
// 	for i := startFloor; i <= endFloor; i++ {
// 		floorList.append(i)

// 	}
// 	fmt.Println("Floor List")
// 	fmt.Println(string.Join(" | ", floorList))

// 	fmt.Println("Elevator List")
// 	for i = 1; i <= elevatorTotal; i++ {
// 		elevatorList.append(elevatorList, Elevator(i, 1))
// 		System.Console.Write(elevatorList[i-1].ID + " | ")

// 	}
// fmt.Println("\n")
