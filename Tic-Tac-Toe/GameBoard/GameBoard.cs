using gameBoard.Enums;
using gameBoard.Exceptions;

namespace gameBoard {
    internal class GameBoard {
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public Piece[,] Pieces { get; private set; }

        public GameBoard() {
            Columns = 3;
            Rows = 3;
            Pieces = new Piece[Rows, Columns];
        }

        public void AddPiece(Symbol cp, Position pos) {
            if (ExistsPieceOnPosition(pos)) {
                throw new BoardException("There is already a piece in this position");
            }
            Pieces[pos.Row, pos.Column] = new Piece(cp, pos);
        }

        public void RemovePiece(Position pos) {
            Pieces[pos.Row, pos.Column] = null;
        }

        // Returning a piece in a specific position
        public Piece GetPiece(Position pos) {
            return Pieces[pos.Row, pos.Column];
        }

        public Piece GetPiece(int row, int column) {
            return Pieces[row, column];
        }

        // Checks if the position is occupied by another piece
        private bool ExistsPieceOnPosition(Position pos) {
            ValidatePosition(pos);
            return GetPiece(pos) != null; // Checks if there is a piece at the parameter position
        }

        // Checks if the position is inside the tray
        private bool ValidPosition(Position pos) {           
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

        public bool IsFull() {
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    if (Pieces[i, j] is null) {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckWinner(Symbol player) {
            // Check rows
            for (int i = 0; i < 3; i++) {
                if (GetPiece(i, 0)?.Symbol == player && GetPiece(i, 1)?.Symbol == player && GetPiece(i, 2)?.Symbol == player)
                    return true;
            }

            // Check columns
            for (int i = 0; i < 3; i++) {
                if (GetPiece(0, i)?.Symbol == player && GetPiece(1, i)?.Symbol == player && GetPiece(2, i)?.Symbol == player)
                    return true;
            }

            // Check diagonals
            if (GetPiece(0, 0)?.Symbol == player && GetPiece(1, 1)?.Symbol == player && GetPiece(2, 2)?.Symbol == player)
                return true;

            if (GetPiece(0, 2)?.Symbol == player && GetPiece(1, 1)?.Symbol == player && GetPiece(2, 0)?.Symbol == player)
                return true;

            return false;
        }
    }
}
