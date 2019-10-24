using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
	public class ConsoleOutput
	{
		public static void DisplayTitle()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("                                     *************************************");
			Console.Write("                                     *"); Console.ForegroundColor = ConsoleColor.White; Console.Write("      Welcome to Battleship!!!    ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(" *");
			Console.WriteLine("                                     *************************************");
			Console.ForegroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(
"                                                     | __\n" +
"                                                     |\\/\n" +
"                                                     ---\n" +
"                                                    / | [\n" +
"                                            !      | |||\n" +
"                                         _ /|   _ /| -++'\n" +
"                                       + +--|  | --| --|_ | -\n" +
"                                    { /| __ |  |/\\__ |  | --- ||| __ /\n" +
"                                    +---------------___[} -_ === _.'____                    /\\ \n" +
"                                    ____ -  ||___-{]_| _[}-  |      |_[___\\==--             \\/   _\n" +
"                  __..._____-- ==/ ___]_ | __ | _____________________________[___\\== --____, ------' .7\n" +
"               |                                                                        | Battleship /\n" +
"                \\_________________________________________________________________________________ |\n"
);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.WriteLine("            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.WriteLine("            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                       Press any key to start the game...\n\n");
			Console.ReadKey();
			Console.Clear();
			Header();
		}

		public static void Header()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("                                     *************************************");
			Console.Write("                                     *"); Console.ForegroundColor = ConsoleColor.White; Console.Write("            Battleship!!!         ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(" *");
			Console.WriteLine("                                     *************************************");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void ShowBoard(string[,] board)
		{
			Console.Clear();
			for (int i = 0; i < 11; i++)
			{
				Console.WriteLine("\n");
				for (int j = 0; j < 11; j++)
				{
					string spot = board[i, j];
					if (board[i, j] == " M  ")
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write(spot);
					}
					else if (board[i, j] == " H  ")
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(spot);
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write(spot);
					}
				}
			}
			Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WonTitle()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("                                     *************************************");
			Console.Write("                                     *"); Console.ForegroundColor = ConsoleColor.White; Console.Write("        You Won Battleship!!!     ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(" *");
			Console.WriteLine("                                     *************************************");
			Console.ForegroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(
"                                                     | __\n" +
"                                                     |\\/\n" +
"                                                     ---\n" +
"                                                    / | [\n" +
"                                            !      | |||\n" +
"                                         _ /|   _ /| -++'\n" +
"                                       + +--|  | --| --|_ | -\n" +
"                                    { /| __ |  |/\\__ |  | --- ||| __ /\n" +
"                                    +---------------___[} -_ === _.'____                    /\\ \n" +
"                                    ____ -  ||___-{]_| _[}-  |      |_[___\\==--             \\/   _\n" +
"                  __..._____-- ==/ ___]_ | __ | _____________________________[___\\== --____, ------' .7\n" +
"               |                                                                        | Battleship /\n" +
"                \\_________________________________________________________________________________ |\n"
);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.WriteLine("            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.WriteLine("            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                               CONGRATULATIONS!!!\n\n");
		}
	}
}

