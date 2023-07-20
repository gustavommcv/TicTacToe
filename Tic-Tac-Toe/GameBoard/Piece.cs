using gameBoard.Enums;

namespace gameBoard {
    internal class Piece {
        public Symbol Symbol { get; private set; }
        public Position Position { get; private set; }

        public Piece(Symbol symbol, Position position) {
            Symbol = symbol;
            Position = position;
        }

        public override string ToString() {
            return Symbol.ToString();
        }
    }
}
