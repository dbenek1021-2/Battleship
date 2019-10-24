using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
	public class GameFlow
	{
		public void Start()
		{
			Player playerOne = new Player();
			Player playerTwo = new Player();

			//shows start menu & displays header
			ConsoleOutput.DisplayTitle();

			//get players names
			playerOne.Name = ConsoleInput.GetPlayerName(1);
			playerTwo.Name = ConsoleInput.GetPlayerName(2);
			Console.WriteLine("Press enter to start...");
			Console.ReadKey();

			//the player's boards: their boards with ships & their guess board
			playerOne.PlayerBoard = ConsoleInput.PlayerBoard();
			playerOne.GuessBoard = ConsoleInput.PlayerBoard();
			playerTwo.PlayerBoard = ConsoleInput.PlayerBoard();
			playerTwo.GuessBoard = ConsoleInput.PlayerBoard();

			//for loop to place their 5 ships for player 1
			for (int i = 0; i < 5; i++)
			{
                GameManager.PlaceShips(playerOne, i);
			}
			Console.Clear();
			Console.WriteLine($"{playerTwo.Name}, it's your turn to fill your board. Press enter if you are ready...");
			Console.ReadKey();

			//for loop to place their 5 ships for player 2
			for (int i = 0; i < 5; i++)
			{
                GameManager.PlaceShips(playerTwo, i);
            }

            //randomly chooses who goes first & playing the game
            //randomly find's out who's going first
            Console.Clear();
			int StartingPlayer = GameManager.WhoGoesFirst();
			if (StartingPlayer == 1)
			{
				playerOne.WhoseTurn = true;
				playerTwo.WhoseTurn = false;
			}
			else
			{
				playerOne.WhoseTurn = false;
				playerTwo.WhoseTurn = true;
			}

			//bool checkVictory;

			//playing the game
			bool isVictory = false;
			do
			{
				if (playerOne.WhoseTurn == true)
				{
					Console.WriteLine($"\n\n\n   {playerOne.Name}, it is your turn.");
					Console.ReadKey();
					isVictory = GameManager.Game(playerTwo.PlayerBoard, playerOne, playerTwo);
					GameManager.WhoseTurn(playerOne, playerTwo);
				}

				else
				{
					Console.WriteLine($"\n\n\n   {playerTwo.Name}, it is your turn.");
					Console.ReadKey();
					isVictory = GameManager.Game(playerOne.PlayerBoard, playerTwo, playerOne);
					GameManager.WhoseTurn(playerOne, playerTwo);
				}
			} while (isVictory == false);

			//do
			//{
			//	if (playerOne.WhoseTurn)
			//	{
			//		ConsoleOutput.ShowBoard(playerOne.GuessBoard.DisplayBoard);
			//		Console.WriteLine($"{playerOne.Name}, enter a coordinate to fire a shot at enemy ships: (Ex. A2) ");
			//		Coordinate shot = ConsoleInput.GetCoordinate();
			//		FireShotResponse fireShotResponse = playerTwo.PlayerBoard.FireShot(shot);
			//		GameManager.HitOrMiss(shot, fireShotResponse, playerOne);
			//		if (fireShotResponse.ShotStatus == ShotStatus.Invalid || fireShotResponse.ShotStatus == ShotStatus.Duplicate)
			//		{
			//			Console.WriteLine($"{fireShotResponse.ShotStatus} entry! Press enter to try again.");
			//			Console.ReadKey();
			//			playerOne.WhoseTurn = false;
			//		}
			//		else
			//		{
			//			Console.WriteLine($"{fireShotResponse.ShotStatus} {fireShotResponse.ShipImpacted}! Press enter to end your turn.");
			//			Console.ReadKey();
			//			playerOne.WhoseTurn = false;
			//		}
			//		//GameManager.Game(playerTwo.PlayerBoard, playerOne);
			//		checkVictory = GameManager.Win(fireShotResponse);
			//		Console.Clear();
			//	}
			//	else
			//	{
			//		ConsoleOutput.ShowBoard(playerTwo.GuessBoard.DisplayBoard);
			//		Console.WriteLine($"{playerTwo.Name}, enter a coordinate to fire a shot at enemy ships: (Ex. A2) ");
			//		Coordinate shot = ConsoleInput.GetCoordinate();
			//		FireShotResponse fireShotResponse = playerOne.PlayerBoard.FireShot(shot);
			//		GameManager.HitOrMiss(shot, fireShotResponse, playerTwo);
			//		if (fireShotResponse.ShotStatus == ShotStatus.Invalid || fireShotResponse.ShotStatus == ShotStatus.Duplicate)
			//		{
			//			Console.WriteLine($"{fireShotResponse.ShotStatus} entry! Press enter to try again.");
			//			Console.ReadKey();
			//			playerTwo.WhoseTurn = false;
			//		}
			//		else
			//		{
			//			Console.WriteLine($"{fireShotResponse.ShotStatus} {fireShotResponse.ShipImpacted}! Press enter to end your turn.");
			//			Console.ReadKey();
			//			playerTwo.WhoseTurn = false;
			//		}
			//		checkVictory = GameManager.Win(fireShotResponse);
			//		Console.Clear();
			//	}

			//	GameManager.WhoseTurn(playerOne, playerTwo);

			//} while (checkVictory == false);  //keep game going until someone wins

			//to end the game or restart a new one
			if (isVictory == true && playerOne.WhoseTurn == false)
			{
				ConsoleOutput.WonTitle();
				Console.WriteLine($"                                                {playerOne.Name} wins! \n\nWould you like to play again?\nPress Y then enter for Yes or any key to quit.");
				string playOrQuit = Console.ReadLine().ToUpper();

				if (playOrQuit == "Y" || playOrQuit == "YES")
				{
					Console.Clear();
					Start();
				}
			}
			else if (isVictory == true && playerTwo.WhoseTurn == false)
			{
				ConsoleOutput.WonTitle();
				Console.WriteLine($"                                                {playerTwo.Name} wins! \n\nWould you like to play again?\nPress Y then enter for Yes or any key to quit.");
				string playOrQuit = Console.ReadLine().ToUpper();

				if (playOrQuit == "Y" || playOrQuit =="YES")
				{
					Console.Clear();
					Start();
				}
			}
		}
	}
}
