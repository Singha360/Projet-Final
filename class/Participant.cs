/// <summary>
/// La classe de base pour Player et Computer
/// </summary>
internal abstract class Participant
{
    internal char symbol;

    public Participant(char symbol)
    {
        this.symbol = symbol;
    }

    abstract public void Play(Board board);

}