using System;
using System.Threading;

namespace Elevator_ConsoleApp_NetCore
{
	class Program
	{
		static string QuitApp = "quit";

		//TODO :moveoperations to Engine class and prop of ElevatorEngine in Elevator cls
		static void Main(string[] args)
		{
			Console.WriteLine($"Welcome to the Elevator App! {Environment.NewLine}");
			Console.WriteLine($"To quit the app, type 'quit' when prompted for user input. {Environment.NewLine}");
			string userInput = string.Empty;

		AskForFloors:
			Console.WriteLine("How many floors are in the building?");

			userInput = Console.ReadLine();
			ExitApp(IsQuitOperation(userInput));

			if (!int.TryParse(userInput, out int numberOfFloors))
            {
                Console.WriteLine($"Error: The input entered is not a number. Please try again... {Environment.NewLine}");
                Console.Beep();
                goto AskForFloors;
            }

            var elevator = new Elevator(numberOfFloors);

			while (userInput != QuitApp)
			{
			DestinationFloor:
				Console.WriteLine($"Enter the destination floor:");

				userInput = Console.ReadLine();
				ExitApp(IsQuitOperation(userInput));

				if (int.TryParse(userInput, out int requestedFloor))
				{
					if (!elevator.FloorExists(requestedFloor))
					{
						Console.WriteLine($"Destination floor does not exist. Our building has {elevator.MaxFloor} floors. Please try again... {Environment.NewLine}");
						goto DestinationFloor;
					}

					if (elevator.IsCurrentFloor(requestedFloor))
					{
						Console.WriteLine($"We are already on that floor. Please choose another... {Environment.NewLine}");
						goto DestinationFloor;
					}

					elevator.GoToFloor(requestedFloor);
				}
				else if (string.Equals(userInput, QuitApp, StringComparison.InvariantCultureIgnoreCase))
				{
					ExitApp(true);
				}
				else
				{
					if (!int.TryParse(userInput, out _))
					{
						Console.WriteLine($"Error: The input entered is not a number. Please try again... {Environment.NewLine}");
						Console.Beep();
						goto DestinationFloor;
					}
					else
					{
						Console.WriteLine($"Destination floor does not exist. Our building has {elevator.MaxFloor} floors. Please try again... {Environment.NewLine}");
						Console.Beep();
						goto DestinationFloor;
					}
				}
			}
		}

		static bool IsQuitOperation(string userInput)
		{
			return string.Equals(userInput, QuitApp, StringComparison.InvariantCultureIgnoreCase);
		}

		static void ExitApp(bool quitApp)
		{
			if (quitApp)
			{
				Console.WriteLine("Thank you for using the Elevator App. The app will close in a few seconds.");
				Thread.Sleep(3000);
				Environment.Exit(0);
			}
		}
	}
}