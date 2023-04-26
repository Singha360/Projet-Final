internal class Board
{
    internal char[,] boardMap = new char[3, 3];

    public Board()
    {
        int cellNumber = 1;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                boardMap[row, col] = Convert.ToChar(cellNumber.ToString());
                cellNumber++;
            }
        }
    }

    internal void Print()
    {
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("-------------");
        for (int row = 0; row < 3; row++)
        {
            Console.Write("| ");
            for (int col = 0; col < 3; col++)
            {
                switch (boardMap[row, col])
                {
                    case 'X':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(boardMap[row, col]);
                        Console.ResetColor();
                        break;
                    case 'O':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(boardMap[row, col]);
                        Console.ResetColor();
                        break;
                    default:
                        Console.Write(boardMap[row, col]);
                        break;
                }
                Console.Write(" | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
        }
    }

    internal bool IsDone(out char winner)
    {
        // verifies le rangées
        for (int row = 0; row < 3; row++)
        {
            if (!Char.IsDigit(boardMap[row, 0]) && boardMap[row, 0] == boardMap[row, 1] && boardMap[row, 1] == boardMap[row, 2])
            {
                winner = boardMap[row, 0];
                return true;
            }
        }

        // verifies le colonnes
        for (int col = 0; col < 3; col++)
        {
            if (!Char.IsDigit(boardMap[0, col]) && boardMap[0, col] == boardMap[1, col] && boardMap[1, col] == boardMap[2, col])
            {
                winner = boardMap[0, col];
                return true;
            }
        }

        // verifies le diagonales
        if (!Char.IsDigit(boardMap[0, 0]) && boardMap[0, 0] == boardMap[1, 1] && boardMap[1, 1] == boardMap[2, 2])
        {
            winner = boardMap[0, 0];
            return true;
        }

        if (!Char.IsDigit(boardMap[0, 2]) && boardMap[0, 2] == boardMap[1, 1] && boardMap[1, 1] == boardMap[2, 0])
        {
            winner = boardMap[0, 2];
            return true;
        }

        // Retour faux si le jeu est encore actif
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (Char.IsDigit(boardMap[row, col]))
                {
                    winner = '-';
                    return false;
                }
            }
        }

        // Si on arrive ici c'est qu'il n'y a pas de gagnant
        winner = '-';
        return true;
    }
}
