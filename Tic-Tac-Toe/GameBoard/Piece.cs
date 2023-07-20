using GameBoard.Enums;

namespace GameBoard {
    internal class Piece {
        public Symbol Symbol { get; private set; }
        public Position Position { get; private set; }

        public Piece(Symbol symbol, Position position) {
            Symbol = symbol;
            Position = position;
        }
    }
}
