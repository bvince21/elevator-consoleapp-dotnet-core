using System;
using System.Threading;

namespace Elevator_ConsoleApp_NetCore
{
    public class Elevator
    {
        public int MaxFloor { get; set; }

        public int CurrentFloor { get; set; }

        public Elevator(int floors)
        {
			MaxFloor = floors;
            CurrentFloor = 1;
        }

        public bool FloorExists(int floor)
        {
            return floor < MaxFloor;
		}

        public void GoToFloor(int requestedFloor)
        {
            Console.WriteLine($"Going to Floor: {requestedFloor}.");

            if (requestedFloor > CurrentFloor)
            {
                GoUp(requestedFloor);
            }
            else 
            { 
                GoDown(requestedFloor);
            }
        }

        private void GoUp(int requestedFloor)
        {
            for (int i = CurrentFloor; i <= requestedFloor; i++)
            {
                MoveElevator(i);

                if (i == requestedFloor)
                {
                    Console.WriteLine($"You have arrived! {Environment.NewLine}");
                    CurrentFloor = i;
                }
            }
        }

        private void GoDown(int requestedFloor)
        {
            for (int i = CurrentFloor; i >= requestedFloor; i--)
            {
                MoveElevator(i);

                if (i == requestedFloor)
                {
                    Console.WriteLine($"You have arrived! {Environment.NewLine}");
                    CurrentFloor = i;
                }
            }
        }

        private void MoveElevator(int currentFloor)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Floor {currentFloor}...");
        }

        public bool IsCurrentFloor(int requestedFloor)
        {
            return CurrentFloor == requestedFloor;
        }
    }
}
