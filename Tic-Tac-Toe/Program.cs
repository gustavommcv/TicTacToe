using gameBoard;
using gameBoard.Enums;
using gameBoard.Exceptions;
using match;
using Tic_Tac_Toe;

class Program {
    static void Main(string[] args) {
        Match match = new Match();
        Bot bot = new Bot(Symbol.O); // Create an instance of the bot with the symbol O

        while (match.Finished == Status.None) {
            try {
                Console.Clear();
                Screen.DrawMatch(match);

                if (match.CurrentPlayer == Symbol.X) {
                    // If it is the human player's turn (X), ask him/her to choose the position.
                    Position p = Screen.ReadPosition().ToPosition();
                    match.GameBoard.ValidatePosition(p);

                    match.PerformsPlay(p);
                } else {
                    // If it is the bot's turn (O), use the Minimax algorithm to choose the best move.
                    Position bestMove = bot.FindBestMove(match.GameBoard);
                    match.PerformsPlay(bestMove);
                }

            } catch (BoardException ex) {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            } catch (FormatException) {
                Console.WriteLine("Invalid position");
                Console.ReadLine();
            }
        }

        Console.Clear();
        Screen.DrawMatch(match);
    }
}
