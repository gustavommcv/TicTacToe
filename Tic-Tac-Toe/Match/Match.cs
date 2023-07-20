using gameBoard.Enums;
using gameBoard;

namespace match {
    internal class Match {
        public GameBoard GameBoard { get; set; }
        public bool Finished { get; private set; }
        public Symbol CurrentPlayer { get; private set; }

        public Match() {
            Finished = false;
            CurrentPlayer = Symbol.X;
            GameBoard = new GameBoard();
        }

        public void ChangePlayer() {
            CurrentPlayer = (CurrentPlayer == Symbol.X) ? Symbol.O : Symbol.X;
        }

        public void PerformsPlay(Position p) {
            GameBoard.AddPiece(CurrentPlayer, p);
            ChangePlayer();
        }
    }
}
