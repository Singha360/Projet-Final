/// <summary>
/// La classe Game contient le "state" du jeu.
/// 
/// </summary>
internal class Game
{
    private Board board;
    private Participant[] players = new Participant[2];
    private char winner;

    public Game()
    {

        int numberOfPlayers = 0;
        board = new Board();
        Console.Clear();
        Console.WriteLine("How many players are going to play (1-2)?");
        do
        {
            try
            {
                numberOfPlayers = int.Parse(Console.ReadLine());

                if (numberOfPlayers < 1 || numberOfPlayers > 2)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Either type 1 or 2.");
                }
            }
            catch (SystemException)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Either type 1 or 2.");
            }
        } while (numberOfPlayers < 1 || numberOfPlayers > 2);



        if (numberOfPlayers == 1)
        {
            players[0] = new Player('X');
            players[1] = new Computer('O');
        }
        else
        {
            players[0] = new Player('X');
            players[1] = new Player('O');
        }
    }

    public void Start()
    {
        do
        {
            board.Print();
            Console.ForegroundColor = ConsoleColor.Blue;
            players[0].Play(board);
            Console.ResetColor();
            board.Print();
            // Le IF ici est nécessaire dû au fait de comment 
            // les classes sont écrient. La denière tours (9e tour)
            // sera toujours le premier joueur alors on veut s'assurer
            // que cette boucle termine. Sinon la method "Play"
            // du deuxiéme joueur va causer une boucle infinie...
            if (!board.IsDone(out winner))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                players[1].Play(board);
                Console.ResetColor();
            }

        } while (!board.IsDone(out winner));

        Console.Clear();
        board.Print();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        if (winner != '-')
        {
            Console.WriteLine($"\nThe winner is : {winner}");
        }
        else
        {
            Console.WriteLine($"\nThe game ended in a draw");
        }
    }
}
