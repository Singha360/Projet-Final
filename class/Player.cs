internal class Player : Participant
{
    public Player(char symbol) : base(symbol)
    {
        base.symbol = symbol;
    }

    public override void Play(Board board)
    {
        int col = 0;
        int row = 0;
        int cellNum = 0;

        Console.WriteLine($"\nPlayer {symbol}, enter the cell number (1-9):");

        do
        {
            try
            {

                cellNum = int.Parse(Console.ReadLine());
            }
            catch (SystemException)
            {
                Console.Clear();
                board.Print();
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 9.");
                continue;
            }

            switch (cellNum)
            {
                case 1:
                    row = 0;
                    col = 0;
                    break;
                case 2:
                    row = 0;
                    col = 1;
                    break;
                case 3:
                    row = 0;
                    col = 2;
                    break;
                case 4:
                    row = 1;
                    col = 0;
                    break;
                case 5:
                    row = 1;
                    col = 1;
                    break;
                case 6:
                    row = 1;
                    col = 2;
                    break;
                case 7:
                    row = 2;
                    col = 0;
                    break;
                case 8:
                    row = 2;
                    col = 1;
                    break;
                case 9:
                    row = 2;
                    col = 2;
                    break;
                default:
                    Console.Clear();
                    board.Print();
                    Console.WriteLine("\nInvalid input. Please enter a number between 1 and 9.");
                    break;
            }

            if (!Char.IsDigit(board.boardMap[row, col]))
            {
                Console.Clear();
                board.Print();
                Console.WriteLine("\nThis cell is already occupied");
            }


        } while (cellNum < 1 || cellNum > 9 || !Char.IsDigit(board.boardMap[row, col]));

        board.boardMap[row, col] = symbol;
    }

}
