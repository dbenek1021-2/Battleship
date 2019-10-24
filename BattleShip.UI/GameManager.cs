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
	public class GameManager
	{

		public static int WhoGoesFirst()
		{
			Random player = new Random();
			int goesFirst = player.Next(1, 3);

			ConsoleOutput.Header();
			Console.Write($"\nPlayer {goesFirst} will go first. \n");
			Console.WriteLine("\nLet's play Battleship!!! Press enter to play...");
			Console.ReadKey();
			Console.Clear();
			return goesFirst;
		}

		////keep track of who's turn it is
		////send to appropriate player board in ConsoleInput; never ending loop until Victory
		public static void WhoseTurn(Player playerOne, Player playerTwo)
		{
			if (playerOne.WhoseTurn == true || playerTwo.WhoseTurn == false)
			{
				playerTwo.WhoseTurn = true;
				playerOne.WhoseTurn = false;
			}
			else
			{
				playerTwo.WhoseTurn = false;
				playerOne.WhoseTurn = true;
			}
		}

		public static void HitOrMiss(Coordinate coordinate, FireShotResponse fireShotResponse, Player player)
		{
			//if the coordinate is a Hit, add a red H to that coordinate on the guessingBoard
			//if the coordinate is a Miss, add a yellow M to that coordinate on the guessingBoard
			if (fireShotResponse.ShotStatus == ShotStatus.Hit)
			{
				//Console.ForegroundColor = ConsoleColor.Red;
				player.GuessBoard.DisplayBoard[coordinate.XCoordinate, coordinate.YCoordinate] = " H  ";
			}
			if (fireShotResponse.ShotStatus == ShotStatus.Miss)
			{
				//Console.ForegroundColor = ConsoleColor.Yellow;
				player.GuessBoard.DisplayBoard[coordinate.XCoordinate, coordinate.YCoordinate] = " M  ";
			}
			if (fireShotResponse.ShotStatus == ShotStatus.HitAndSunk)
			{
				//Console.ForegroundColor = ConsoleColor.Red;
				player.GuessBoard.DisplayBoard[coordinate.XCoordinate, coordinate.YCoordinate] = " H  ";
			}
		}

		//each player place their ships
		public static void PlaceShips(Player player, int i)
		{
			PlaceShipRequest placeShipRequest = new PlaceShipRequest();
			string shipName;
			ShipPlacement placement;
			shipName = player.PlayerBoard.Ships[i].ShipName;
			do
			{
				ConsoleOutput.ShowBoard(player.PlayerBoard.DisplayBoard);

				Console.WriteLine($"{player.Name}, enter a starting coordinate for your {shipName}: (Ex. A2) ");

				placeShipRequest.Coordinate = ConsoleInput.GetCoordinate();
				placeShipRequest.Direction = ConsoleInput.GetDirection();
				placeShipRequest.ShipType = player.PlayerBoard.Ships[i].ShipType;
				placement = player.PlayerBoard.PlaceShip(placeShipRequest);
				if (placement != ShipPlacement.Ok)
				{
					Console.WriteLine($"{placement}.\nPlease press enter to try a new coordinate for your {shipName}.");
					Console.ReadKey();
					Console.Clear();
				}
			} while (placement != ShipPlacement.Ok);

			Console.WriteLine($"Your {shipName} has been placed. Press enter to continue.");
			Console.ReadKey();
		}

		public static bool Game(Board enemyPlayerBoard, Player player, Player otherPlayer)
		{
			bool checkVictory;

			ConsoleOutput.ShowBoard(player.GuessBoard.DisplayBoard);
			Console.WriteLine($"{player.Name}, enter a coordinate to fire a shot at enemy ships: (Ex. A2) ");
			Coordinate shot = ConsoleInput.GetCoordinate();
			FireShotResponse fireShotResponse = enemyPlayerBoard.FireShot(shot);
			HitOrMiss(shot, fireShotResponse, player);
			if (fireShotResponse.ShotStatus == ShotStatus.Invalid || fireShotResponse.ShotStatus == ShotStatus.Duplicate)
			{
				Console.WriteLine($"{fireShotResponse.ShotStatus} entry! Press enter to clear the screen and try again.");
				Console.ReadKey();
				player.WhoseTurn = false;
				otherPlayer.WhoseTurn = true;
			}
			else if (fireShotResponse.ShotStatus == ShotStatus.HitAndSunk)
			{
				Console.WriteLine($"{fireShotResponse.ShotStatus} {fireShotResponse.ShipImpacted}! Press enter to end your turn.");
				Console.ReadKey();
			}
			else if (fireShotResponse.ShotStatus == ShotStatus.Victory)
			{
				Console.WriteLine($"{fireShotResponse.ShotStatus}! {player.Name} sunk all enemy ships!  Press enter to end the game.");
				Console.ReadKey();
			}
			else
			{
				Console.WriteLine($"{fireShotResponse.ShotStatus}! Press enter to end your turn.");
				Console.ReadKey();
			}
			checkVictory = Win(fireShotResponse);
			Console.Clear();
			return checkVictory;
		}

		//if someone won
		public static bool Win(FireShotResponse response)
		{
			if (response.ShotStatus == ShotStatus.Victory)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
