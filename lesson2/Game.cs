using System;

namespace lesson2
{
    public class Game
    {
        string _SymbolWalkingPlayer = "X";
        public string SymbolWalkingPlayer
        {
            get => _SymbolWalkingPlayer;
            set => _SymbolWalkingPlayer = value;
        }
        public int GameTableSideSize { get; set; }
        public string[] GameTable;
        public Game(int gameTableSideSize)
        {
            GameTableSideSize = gameTableSideSize;
            GameTable = new string[gameTableSideSize * gameTableSideSize];
            for (int i = 0; i < GameTableSideSize * gameTableSideSize; i++)
            {
                GameTable[i] = Convert.ToString(i + 1);
            }
        }
        int _PlayerNumber = 0;
        public int PlayerNumber
        {
            get => _PlayerNumber;
            set => _PlayerNumber = value;
        }

        public void Move()
        {
            while (true)
            {
                Console.Write($"\nВведите номер, расположенный на той клетке, в которую вы хотите сходить.\nХодят {SymbolWalkingPlayer} :");
                string elem = Console.ReadLine();
                try
                {
                    PlayerNumber = Convert.ToInt32(elem);
                    if (PlayerNumber > 0 && PlayerNumber <= GameTableSideSize * GameTableSideSize
                        && GameTable[PlayerNumber - 1] != "X" && GameTable[PlayerNumber - 1] != "O")
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine($"Вводите пожалуйста числа из таблицы, а не вот это вот '{elem}'");
                }
            }
            GameTable[PlayerNumber - 1] = SymbolWalkingPlayer;
        }
        public bool CheckingWinner()
        {
            int TopAndButtonCount = 0;
            int LeftAndRightCount = 0;
            int TopLeft_ButtomRightAndReversCount = 0;
            int TopRight_ButtomLeftAndReversCount = 0;
            for (int i = 1; i <= GameTableSideSize; i++)
            {
                //Top
                if (PlayerNumber - 1 - GameTableSideSize * i >= 0)
                {
                    if (GameTable[PlayerNumber - 1 - GameTableSideSize * i] == SymbolWalkingPlayer)
                    {
                        TopAndButtonCount++;
                    }
                    else
                    {
                        TopAndButtonCount--;
                    }
                }
                //Buttom
                if (PlayerNumber - 1 + GameTableSideSize * i < GameTableSideSize * GameTableSideSize)
                {
                    if (GameTable[PlayerNumber - 1 + GameTableSideSize * i] == SymbolWalkingPlayer)
                    {
                        TopAndButtonCount++;
                    }
                    else
                    {
                        TopAndButtonCount--;
                    }
                }
                //Left
                if (PlayerNumber - 1 - i >= (PlayerNumber / GameTableSideSize - (PlayerNumber / GameTableSideSize) % 1 + (PlayerNumber % GameTableSideSize != 0 ? 1 : 0)) * GameTableSideSize - GameTableSideSize)
                {
                    if (GameTable[PlayerNumber - 1 - i] == SymbolWalkingPlayer)
                    {
                        LeftAndRightCount++;
                    }
                    else
                    {
                        LeftAndRightCount--;
                    }
                }
                //Right
                if (PlayerNumber - 1 + i < (PlayerNumber / GameTableSideSize - (PlayerNumber / GameTableSideSize) % 1 + (PlayerNumber % GameTableSideSize != 0 ? 1 : 0)) * GameTableSideSize)
                {
                    if (GameTable[PlayerNumber - 1 + i] == SymbolWalkingPlayer)

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
                    if (PlayerNumber - 1 + (GameTableSideSize + 1) * i < GameTableSideSize * GameTableSideSize)
                    {
                        if (GameTable[PlayerNumber - 1 + (GameTableSideSize + 1) * i] == SymbolWalkingPlayer)
                        {
                            TopLeft_ButtomRightAndReversCount++;
                        }
                        else
                        {
                            TopLeft_ButtomRightAndReversCount--;
                        }
                    }
                    //TopLeft <-> ButtomRight (\) <-
                    if (PlayerNumber - 1 - (GameTableSideSize + 1) * i >= 0)
                    {
                        if (GameTable[PlayerNumber - 1 - (GameTableSideSize + 1) * i] == SymbolWalkingPlayer)
                        {
                            TopLeft_ButtomRightAndReversCount++;
                        }
                        else
                        {
                            TopLeft_ButtomRightAndReversCount--;
                        }
                    }
                    //TopRight <->ButtomLeft(/) <-
                    if (PlayerNumber - 1 + (GameTableSideSize - 1) * i < GameTableSideSize * GameTableSideSize - 1)
                    {
                        if (GameTable[PlayerNumber - 1 + (GameTableSideSize - 1) * i] == SymbolWalkingPlayer)
                        {
                            TopRight_ButtomLeftAndReversCount++;
                        }
                        else
                        {
                            TopRight_ButtomLeftAndReversCount--;
                        }
                    }
                    //TopRight <->ButtomLeft(/) ->
                    if (PlayerNumber - 1 - (GameTableSideSize - 1) * i > 0)
                    {
                        if (GameTable[PlayerNumber - 1 - (GameTableSideSize - 1) * i] == SymbolWalkingPlayer)
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

            if (TopAndButtonCount == GameTableSideSize - 1 ||
               LeftAndRightCount == GameTableSideSize - 1 ||
               TopLeft_ButtomRightAndReversCount == GameTableSideSize - 1 ||
               TopRight_ButtomLeftAndReversCount == GameTableSideSize - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckingUnclean()
        {
            int MaxCountElems = GameTableSideSize * GameTableSideSize;
            for (int i = 0; i < GameTableSideSize * GameTableSideSize; i++)
            {
                if (GameTable[i] == "X" || GameTable[i] == "O")
                {
                    MaxCountElems--;
                }
            }
            if (MaxCountElems == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangePlayer()
        {
            if (SymbolWalkingPlayer == "X")
            {
                SymbolWalkingPlayer = "O";
            }
            else
            {
                SymbolWalkingPlayer = "X";
            }
        }
    }
}
