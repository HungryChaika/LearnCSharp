using System;
using System.Drawing;
using System.Runtime;

//This is tic_tac_toe

namespace lesson2
{
    class Programm
    {
        public static void Main(string[] args)
        {
            int GameTableSideSize;

            while (true)
            {
                Console.Write("Введите размер поля N * N, N должно быть > 1\nN = ");
                string elem = Console.ReadLine();
                try
                {
                    GameTableSideSize = Convert.ToInt32(elem);
                    if(GameTableSideSize > 1)
                        break;
                }
                catch
                {
                    Console.WriteLine($"Не вводите пожалуйста вот это вот '{elem}'");
                }
            }
            Game game = new Game(GameTableSideSize);
            UI ui = new UI();
            Console.WriteLine("\nУдачи и приятной игры!\n");
            ui.Render(game.GameTable, game.GameTableSideSize, game.SymbolWalkingPlayer, game.PlayerNumber);
            while (true)
            {
                game.Move();
                ui.Render(game.GameTable, game.GameTableSideSize, game.SymbolWalkingPlayer, game.PlayerNumber);

                if (game.CheckingWinner())
                {
                    Console.WriteLine($"\n\nПОБЕДИТЕЛЬ: '{game.SymbolWalkingPlayer}' !!!");
                    break;
                }
                else if (game.CheckingUnclean())
                {
                    Console.WriteLine("\n\nНИЧЬЯ !!!");
                    break;
                }
                else
                {
                    game.ChangePlayer();
                }
            }
        }
    }
}