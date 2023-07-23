using gameBoard;
using gameBoard.Enums;
using gameBoard.Exceptions;
using match;
using Tic_Tac_Toe;

Match match = new Match();

while (match.Finished == Status.None) {
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
    catch(FormatException) {
        Console.WriteLine("Invalid position");
        Console.ReadLine();
    }
}

Console.Clear();
Screen.DrawMatch(match);
