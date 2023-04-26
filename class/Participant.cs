internal abstract class Participant
{
    internal char symbol;

    public Participant(char symbol)
    {
        this.symbol = symbol;
    }

    abstract public void Play(Board board);

}