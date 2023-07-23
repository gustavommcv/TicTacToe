using gameBoard;
using gameBoard.Enums;  

namespace Tic_Tac_Toe {
    internal class Bot {
        public Symbol BotSymbol { get; private set; }

        public Bot(Symbol botSymbol) {
            BotSymbol = botSymbol;
        }

        public Position FindBestMove(GameBoard board) {
            int bestScore = int.MinValue;
            Position bestMove = null;

            foreach (var emptyPosition in GetEmptyPositions(board)) {
                board.AddPiece(BotSymbol, emptyPosition);
                int score = Minimax(board, 0, false);
                board.RemovePiece(emptyPosition);

                if (score > bestScore) {
                    bestScore = score;
                    bestMove = emptyPosition;
                }
            }

            return bestMove;
        }

        private int Minimax(GameBoard board, int depth, bool isMaximizingPlayer) {
            if (board.CheckWinner(Symbol.X))
                return -10 + depth; // Higher depth means a more desirable move for the bot (prefer winning sooner).
            if (board.CheckWinner(Symbol.O))
                return 10 - depth; // Higher depth means a less desirable move for the opponent (prefer losing later).
            if (board.IsFull())
                return 0; // Draw

            if (isMaximizingPlayer) {
                int bestScore = int.MinValue;

                foreach (var emptyPosition in GetEmptyPositions(board)) {
                    board.AddPiece(BotSymbol, emptyPosition);
                    int score = Minimax(board, depth + 1, false);
                    board.RemovePiece(emptyPosition);
                    bestScore = Math.Max(score, bestScore);
                }

                return bestScore;
            } else {
                int bestScore = int.MaxValue;

                foreach (var emptyPosition in GetEmptyPositions(board)) {
                    board.AddPiece(GetOpponentSymbol(), emptyPosition);
                    int score = Minimax(board, depth + 1, true);
                    board.RemovePiece(emptyPosition);
                    bestScore = Math.Min(score, bestScore);
                }

                return bestScore;
            }
        }

        private Position[] GetEmptyPositions(GameBoard board) {
            var emptyPositions = new System.Collections.Generic.List<Position>();

            for (int i = 0; i < board.Rows; i++) {
                for (int j = 0; j < board.Columns; j++) {
                    if (board.GetPiece(i, j) == null) {
                        emptyPositions.Add(new Position(i, j));
                    }
                }
            }

            return emptyPositions.ToArray();
        }

        private Symbol GetOpponentSymbol() {
            return BotSymbol == Symbol.X ? Symbol.O : Symbol.X;
        }
    }
}
