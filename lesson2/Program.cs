using System;
using System.Drawing;
using System.Runtime;

//This is tic_tac_toe

namespace lesson2
{

    class Game
    {
        int GameTableSideSize;
        string SymbolWalkingPlayer = "X";
        int PlayerNumber = 0;

        public static void Main(string[] args)
        {
            Game game = new Game();
            while(true)
            {
                Console.Write("Введите размер поля N * N, N должно быть > 1\nN = ");
                string elem = Console.ReadLine();
                try
                {
                    game.GameTableSideSize = Convert.ToByte(elem);
                    if(game.GameTableSideSize > 1)
                        break;
                }
                catch(Exception)
                {
                    Console.WriteLine($"Вводите пожалуйста числа следуя условиям, а не вот это вот '{elem}'");
                }
            }

            string[] GameTable = new string[game.GameTableSideSize * game.GameTableSideSize];
            game.FillInTheTable(ref GameTable);

            Console.WriteLine("\nУдачи и приятной игры!\n");
            game.Render(ref GameTable);
            while (true)
            {
                while (true)
                {
                    Console.Write($"\nВведите номер, расположенный на той клетке, в которую вы хотите сходить.\nХодят {game.SymbolWalkingPlayer} :");
                    string elem = Console.ReadLine();
                    try
                    {
                        game.PlayerNumber = Convert.ToInt32(elem);
                        if (game.PlayerNumber > 0 && game.PlayerNumber <= game.GameTableSideSize * game.GameTableSideSize
                            && GameTable[game.PlayerNumber - 1] != "X" && GameTable[game.PlayerNumber - 1] != "O")
                        {
                            break;
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine($"Вводите пожалуйста числа из таблицы, а не вот это вот '{elem}'");
                    }
                }
                GameTable[game.PlayerNumber - 1] = game.SymbolWalkingPlayer;

                game.Render(ref GameTable);

                if (game.CheckingWinner(ref GameTable))
                {
                    Console.WriteLine($"\n\nПОБЕДИТЕЛЬ: '{game.SymbolWalkingPlayer}' !!!");
                    break;
                }
                else if (game.CheckingUnclean(ref GameTable))
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

        void FillInTheTable(ref string[] table)
        {
            for(int i = 0; i < table.Length; i++)
            {
                table[i] = Convert.ToString(i + 1);
            }
        }

        void Render(ref string[] table)
        {

            int NumberForTable = 0;
            int Counter = 2;
            int DigitNumber = (Convert.ToString(GameTableSideSize * GameTableSideSize)).Length;

            for(int i = 0; i < GameTableSideSize * 2 + 1; i++)
            {
                if (i % 2 == 0)
                {
                    for(int t = 0; t < (DigitNumber * 2 + 1 + 1) * GameTableSideSize + 1; t++)
                    {
                        Console.Write("-");
                    }
                    Counter = 2;
                }
                else
                {
                    for (int j = 0; j < GameTableSideSize * (4 + DigitNumber - 1) + 1; j++)
                    {
                        if (j % (4 + DigitNumber - 1) == 0)
                        {
                            if (j == 0)
                            {
                                Console.Write("\n");
                            }
                            Console.Write("|");
                            if (j == GameTableSideSize * (4 + DigitNumber - 1))
                            {
                                Console.Write("\n");
                            }
                        }
                        else
                        {
                            if (j == Counter)
                            {
                                int NumberOfSpaces = DigitNumber - table[NumberForTable].Length;
                                for (int k = 0; k < NumberOfSpaces; k++)
                                {
                                    Console.Write(" ");
                                }
                                if(PlayerNumber != 0 && NumberForTable == PlayerNumber - 1)
                                {
                                    SetCollor(SymbolWalkingPlayer);
                                }
                                Console.Write(table[NumberForTable]);
                                Counter += 4 + DigitNumber - 1;
                                NumberForTable++;
                                SetCollor();
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                }
            }
        }

        bool CheckingWinner(ref string[] table)
        {
            int TopAndButtonCount = 0;
            int LeftAndRightCount = 0;
            int TopLeft_ButtomRightAndReversCount = 0;
            int TopRight_ButtomLeftAndReversCount = 0;
            for(int i = 1; i <= GameTableSideSize; i++)
            {
                //Top
                if(PlayerNumber - 1 - GameTableSideSize * i >= 0)
                {
                    if(table[PlayerNumber - 1 - GameTableSideSize * i] == SymbolWalkingPlayer)
                    {
                        TopAndButtonCount++;
                    } else
                    {
                        TopAndButtonCount--;
                    }
                }
                 //Buttom
                if(PlayerNumber - 1 + GameTableSideSize * i < GameTableSideSize * GameTableSideSize)
                {
                    if(table[PlayerNumber - 1 + GameTableSideSize * i] == SymbolWalkingPlayer) {
                        TopAndButtonCount++;
                    } else
                    {
                        TopAndButtonCount--;
                    }
                }
                //Left
                if(PlayerNumber - 1 - i >= (PlayerNumber / GameTableSideSize - (PlayerNumber / GameTableSideSize) % 1 + (PlayerNumber % GameTableSideSize != 0 ? 1 : 0)) * GameTableSideSize - GameTableSideSize)
                {
                    if(table[PlayerNumber - 1 - i] == SymbolWalkingPlayer)
                    {
                        LeftAndRightCount++;
                    }
                    else
                    {
                        LeftAndRightCount--;
                    }
                }
                //Right
                if(PlayerNumber - 1 + i < (PlayerNumber / GameTableSideSize - (PlayerNumber / GameTableSideSize) % 1 + (PlayerNumber % GameTableSideSize != 0 ? 1 : 0)) * GameTableSideSize)
                {
                    if(table[PlayerNumber - 1 + i] == SymbolWalkingPlayer)

                    {
                        LeftAndRightCount++;
                    }
                    else
                    {
                        LeftAndRightCount--;
                    }
                }
                //Diagonals
                if ((PlayerNumber - 1) % (GameTableSideSize + 1) == 0 || (PlayerNumber - 1) % (GameTableSideSize - 1) == 0)
                {
                    //TopLeft <-> ButtomRight (\) ->
                    if(PlayerNumber - 1 + (GameTableSideSize + 1) * i < GameTableSideSize * GameTableSideSize)
                    {
                        if(table[PlayerNumber - 1 + (GameTableSideSize + 1) * i] == SymbolWalkingPlayer)
                        {
                            TopLeft_ButtomRightAndReversCount++;
                        }
                        else
                        {
                            TopLeft_ButtomRightAndReversCount--;
                        }
                    }
                    //TopLeft <-> ButtomRight (\) <-
                    if(PlayerNumber - 1 - (GameTableSideSize + 1) * i >= 0)
                    {
                        if(table[PlayerNumber - 1 - (GameTableSideSize + 1) * i] == SymbolWalkingPlayer)
                        {
                            TopLeft_ButtomRightAndReversCount++;
                        }
                        else
                        {
                            TopLeft_ButtomRightAndReversCount--;
                        }
                    }
                    //TopRight <->ButtomLeft(/) <-
                    if(PlayerNumber - 1 + (GameTableSideSize - 1) * i < GameTableSideSize * GameTableSideSize - 1)
                    {
                        if(table[PlayerNumber - 1 + (GameTableSideSize - 1) * i] == SymbolWalkingPlayer)
                        {
                            TopRight_ButtomLeftAndReversCount++;
                        }
                        else
                        {
                            TopRight_ButtomLeftAndReversCount--;
                        }
                    }
                    //TopRight <->ButtomLeft(/) ->
                    if(PlayerNumber - 1 - (GameTableSideSize - 1) * i > 0)
                    {
                        if(table[PlayerNumber - 1 - (GameTableSideSize - 1) * i] == SymbolWalkingPlayer)
                        {
                            TopRight_ButtomLeftAndReversCount++;
                        }
                        else
                        {
                            TopRight_ButtomLeftAndReversCount--;
                        }
                    }
                }
            }

            if(TopAndButtonCount == GameTableSideSize - 1 ||
               LeftAndRightCount == GameTableSideSize - 1 ||
               TopLeft_ButtomRightAndReversCount == GameTableSideSize - 1 ||
               TopRight_ButtomLeftAndReversCount == GameTableSideSize - 1 )
            {
                return true;
            } else
            {
                return false;
            }
        }

        bool CheckingUnclean(ref string[] table)
        {
            int MaxCountElems = table.Length;
            for(int i = 0; i < table.Length; i++)
            { 
                if(table[i] == "X" || table[i] == "O")
                {
                    MaxCountElems--;
                }
            }
            if(MaxCountElems == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        void SetCollor(string elem = " ")
        {
            if(elem == "X")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return;
            }
            if(elem == "O")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return;
            }
            if(elem == " ")
            {
                Console.ResetColor();
                return;
            }
        }

        void ChangePlayer()
        {
            if(SymbolWalkingPlayer == "X")
            {
                SymbolWalkingPlayer = "O";
            } else
            {
                SymbolWalkingPlayer = "X";
            }
        }


    }

    
}