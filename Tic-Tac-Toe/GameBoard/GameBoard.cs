using GameBoard.Exceptions;

namespace GameBoard {
    internal class GameBoard {
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public Piece[,] Pieces { get; private set; }

        public GameBoard() {
            Columns = 3;
            Rows = 3;
            Pieces = new Piece[Rows, Columns];
        }

        public void AddPiece(Position pos) {
            if (ExistsPieceOnBoard(pos)) {
                throw new BoardException("There is already a piece in this position");
            }

            throw new NotImplementedException();

        }

        // Checks if there is a piece at the parameter position
        public Piece PieceExists(Position pos) {
            return Pieces[pos.Row, pos.Column];
        }

        // Checks if the position is occupied by another piece
        public bool ExistsPieceOnBoard(Position pos) {
            ValidatePosition(pos);
            return PieceExists(pos) != null;
        }

        // Checks if the position is inside the tray
        public bool ValidPosition(Position pos) {
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns) {
                return false;
            } else {
                return true;
            }
        }

        public void ValidatePosition(Position pos) {
            if (!ValidPosition(pos)) {
                throw new BoardException("Invalid position");
            }
        }
    }
}
