using gameBoard;
using gameBoard.Exceptions;
using match;
using Tic_Tac_Toe;

Match match = new Match();

while (!match.Finished) {
    try {
        Console.Clear();
        Screen.DrawMatch(match);

        Position p = Screen.ReadPosition().ToPosition();
        match.GameBoard.ValidatePosition(p);

        match.PerformsPlay(p);

    } 
    catch (BoardException ex) {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
    }
    catch(FormatException ex) {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
    }
}

Console.Clear();
Screen.DrawMatch(match);
