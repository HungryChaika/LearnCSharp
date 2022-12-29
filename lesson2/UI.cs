using System;

namespace lesson2
{
    public class UI
    {
        public void Render(string[] GameTable, int GameTableSideSize, string SymbolWalkingPlayer, int PlayerNumber)
        {
            int NumberForTable = 0;
            int Counter = 2;
            int DigitNumber = (Convert.ToString(GameTableSideSize * GameTableSideSize)).Length;
            for (int i = 0; i < GameTableSideSize * 2 + 1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int t = 0; t < (DigitNumber * 2 + 1 + 1) * GameTableSideSize + 1; t++)
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
                                int NumberOfSpaces = DigitNumber - GameTable[NumberForTable].Length;
                                for (int k = 0; k < NumberOfSpaces; k++)
                                {
                                    Console.Write(" ");
                                }
                                if (PlayerNumber != 0 && NumberForTable == PlayerNumber - 1)
                                {
                                    SetCollor(SymbolWalkingPlayer);
                                }
                                Console.Write(GameTable[NumberForTable]);
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
        void SetCollor(string elem = " ")
        {
            if (elem == "X")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return;
            }
            if (elem == "O")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return;
            }
            if (elem == " ")
            {
                Console.ResetColor();
                return;
            }
        }
    }
}
