using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
	public class ConsoleInput
	{
		public static string GetPlayerName(int number)
		{
			while (true)
			{
				string player;
				Console.Write($"\nPlayer {number}: Enter your name.  \n");
				player = Console.ReadLine();
				if (player.Length == 0)
				{
					Console.Write("Your player has to have a name. Please try again.");
					continue;
				}
				else
				{
					Console.Write($"\nWelcome {player}. You are player {number}...\n");
					return player;
				}
			}
		}

		public static Board PlayerBoard()
		{
			Board board = new Board();
			for (int i = 0; i < 5; i++)
			{
				board.Ships[i] = ShipCreator.CreateShip((ShipType)i);
			}

			string[,] boardGrid = new string[11, 11];
			boardGrid[0, 0] = "   ";

			//grid that the user can see: columns
			boardGrid[0, 1] = "|_1_|"; boardGrid[0, 2] = "_2_|"; boardGrid[0, 3] = "_3_|"; boardGrid[0, 4] = "_4_|"; boardGrid[0, 5] = "_5_|";
			boardGrid[0, 6] = "_6_|"; boardGrid[0, 7] = "_7_|"; boardGrid[0, 8] = "_8_|"; boardGrid[0, 9] = "_9_|"; boardGrid[0, 10] = "_10_|";

			//grid that the user can see: rows
			boardGrid[1, 0] = " A |"; boardGrid[2, 0] = " B |"; boardGrid[3, 0] = " C |"; boardGrid[4, 0] = " D |"; boardGrid[5, 0] = " E |"; boardGrid[6, 0] = " F |"; boardGrid[7, 0] = " G |"; boardGrid[8, 0] = " H |"; boardGrid[9, 0] = " I |"; boardGrid[10, 0] = " J |";
			boardGrid[1, 1] = "    "; boardGrid[2, 1] = "    "; boardGrid[3, 1] = "    "; boardGrid[4, 1] = "    "; boardGrid[5, 1] = "    "; boardGrid[6, 1] = "    "; boardGrid[7, 1] = "    "; boardGrid[8, 1] = "    "; boardGrid[9, 1] = "    "; boardGrid[10, 1] = "    ";
			boardGrid[1, 2] = "    "; boardGrid[2, 2] = "    "; boardGrid[3, 2] = "    "; boardGrid[4, 2] = "    "; boardGrid[5, 2] = "    "; boardGrid[6, 2] = "    "; boardGrid[7, 2] = "    "; boardGrid[8, 2] = "    "; boardGrid[9, 2] = "    "; boardGrid[10, 2] = "    ";
			boardGrid[1, 3] = "    "; boardGrid[2, 3] = "    "; boardGrid[3, 3] = "    "; boardGrid[4, 3] = "    "; boardGrid[5, 3] = "    "; boardGrid[6, 3] = "    "; boardGrid[7, 3] = "    "; boardGrid[8, 3] = "    "; boardGrid[9, 3] = "    "; boardGrid[10, 3] = "    ";
			boardGrid[1, 4] = "    "; boardGrid[2, 4] = "    "; boardGrid[3, 4] = "    "; boardGrid[4, 4] = "    "; boardGrid[5, 4] = "    "; boardGrid[6, 4] = "    "; boardGrid[7, 4] = "    "; boardGrid[8, 4] = "    "; boardGrid[9, 4] = "    "; boardGrid[10, 4] = "    ";
			boardGrid[1, 5] = "    "; boardGrid[2, 5] = "    "; boardGrid[3, 5] = "    "; boardGrid[4, 5] = "    "; boardGrid[5, 5] = "    "; boardGrid[6, 5] = "    "; boardGrid[7, 5] = "    "; boardGrid[8, 5] = "    "; boardGrid[9, 5] = "    "; boardGrid[10, 5] = "    ";
			boardGrid[1, 6] = "    "; boardGrid[2, 6] = "    "; boardGrid[3, 6] = "    "; boardGrid[4, 6] = "    "; boardGrid[5, 6] = "    "; boardGrid[6, 6] = "    "; boardGrid[7, 6] = "    "; boardGrid[8, 6] = "    "; boardGrid[9, 6] = "    "; boardGrid[10, 6] = "    ";
			boardGrid[1, 7] = "    "; boardGrid[2, 7] = "    "; boardGrid[3, 7] = "    "; boardGrid[4, 7] = "    "; boardGrid[5, 7] = "    "; boardGrid[6, 7] = "    "; boardGrid[7, 7] = "    "; boardGrid[8, 7] = "    "; boardGrid[9, 7] = "    "; boardGrid[10, 7] = "    ";
			boardGrid[1, 8] = "    "; boardGrid[2, 8] = "    "; boardGrid[3, 8] = "    "; boardGrid[4, 8] = "    "; boardGrid[5, 8] = "    "; boardGrid[6, 8] = "    "; boardGrid[7, 8] = "    "; boardGrid[8, 8] = "    "; boardGrid[9, 8] = "    "; boardGrid[10, 8] = "    ";
			boardGrid[1, 9] = "    "; boardGrid[2, 9] = "    "; boardGrid[3, 9] = "    "; boardGrid[4, 9] = "    "; boardGrid[5, 9] = "    "; boardGrid[6, 9] = "    "; boardGrid[7, 9] = "    "; boardGrid[8, 9] = "    "; boardGrid[9, 9] = "    "; boardGrid[10, 9] = "    ";
			boardGrid[1, 10] = "    "; boardGrid[2, 10] = "    "; boardGrid[3, 10] = "    "; boardGrid[4, 10] = "    "; boardGrid[5, 10] = "    "; boardGrid[6, 10] = "    "; boardGrid[7, 10] = "    "; boardGrid[8, 10] = "    "; boardGrid[9, 10] = "    "; boardGrid[10, 10] = "    ";

			board.DisplayBoard = boardGrid;

			return board;
		}

		public static Coordinate GetCoordinate()
		{
			int x;

			while (true)
			{
				string userInput = Console.ReadLine();

				if (userInput.Length < 2 || userInput.Length > 3 || !int.TryParse(userInput.Substring(1, 1), out int z))
				{
					Console.WriteLine("Invalid coordinate entry. Try again.");
					continue;
				}
				else if (userInput.Length == 3 && userInput.Substring(1, 2) != "10")
				{
					Console.WriteLine("Invalid coordinate entry. Try again.");
					continue;
				}
				else if (userInput.Length == 3 && userInput.Substring(1, 2) == "10")
				{
					int.TryParse(userInput.Substring(1, 2), out int y);
					//change the x coordinate into an int for sending to Coordinate class
					switch (userInput.Substring(0, 1).ToUpper())
					{
						case "A":
							x = 1;
							break;
						case "B":
							x = 2;
							break;
						case "C":
							x = 3;
							break;
						case "D":
							x = 4;
							break;
						case "E":
							x = 5;
							break;
						case "F":
							x = 6;
							break;
						case "G":
							x = 7;
							break;
						case "H":
							x = 8;
							break;
						case "I":
							x = 9;
							break;
						case "J":
							x = 10;
							break;
						default:
							Console.WriteLine("Invalid coordinate entry. Try again.");
							continue;
					}
					Coordinate coordinate = new Coordinate(x, y);
					return coordinate;
				}
				else
				{
					int.TryParse(userInput.Substring(1, 1), out int y);
					//change the x coordinate into an int for sending to Coordinate class
					switch (userInput.Substring(0, 1).ToUpper())
					{
						case "A":
							x = 1;
							break;
						case "B":
							x = 2;
							break;
						case "C":
							x = 3;
							break;
						case "D":
							x = 4;
							break;
						case "E":
							x = 5;
							break;
						case "F":
							x = 6;
							break;
						case "G":
							x = 7;
							break;
						case "H":
							x = 8;
							break;
						case "I":
							x = 9;
							break;
						case "J":
							x = 10;
							break;
						default:
							Console.WriteLine("Invalid coordinate entry. Try again.");
							continue;
					}
					Coordinate coordinate = new Coordinate(x, y);
					return coordinate;
				}
			}
		}

		public static ShipDirection GetDirection()
		{
			Console.WriteLine("Enter direction you'd like the ship to face: Up, Down, Left, Right: (Ex. U for up) ");
			while (true)
			{
				string userInput = Console.ReadLine();

				if (userInput.Length > 2 || userInput.Length == 0)
				{
					Console.WriteLine("Invalid direction entry. Try again.");
					continue;
				}
				switch (userInput.Substring(0, 1).ToUpper())
				{
					case "U":
						return ShipDirection.Up;
					case "D":
						return ShipDirection.Down;
					case "L":
						return ShipDirection.Left;
					case "R":
						return ShipDirection.Right;
					default:
						Console.WriteLine("Invalid direction entry. Try again.");
						continue;
				}
			}
		}
	}
}
