internal class Computer : Participant
{
    public Computer(char symbol) : base(symbol)
    {
        base.symbol = symbol;
    }

    public override void Play(Board board)
    {
        int row;
        int col;
        Random random = new Random();

        do
        {
            row = random.Next(0, 3);
            col = random.Next(0, 3);
        } while (!Char.IsDigit(board.boardMap[row, col]));

        board.boardMap[row, col] = symbol;
    }
}