using gameBoard;
using gameBoard.Enums;
using gameBoard.Exceptions;
using match;
using System;

namespace Tic_Tac_Toe {
    internal static class Screen {

        public static void DrawMatch(Match match) {
            DrawBoard(match.GameBoard);
            Console.WriteLine();
            
            if (!match.Finished) {
                Console.WriteLine("Waiting for player: " + match.CurrentPlayer.ToString());
            } else {
                Console.WriteLine("Winner: " + match.CurrentPlayer.ToString());
            }
        }

        public static void DrawBoard(GameBoard board) {
            for (int i = 0; i < board.Rows; i++) {
                for (int j = 0; j < board.Columns; j++) {
                    DrawPiece(board.GetPiece(i, j));
                    if (j < board.Columns - 1) {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (i < board.Rows - 1) {
                    Console.WriteLine(new string('-', board.Columns * 4 - 1));
                }
            }
        }

        public static void DrawPiece(Piece piece) {
            if (piece == null) {
                Console.Write("   ");
            } else {
                if (piece.Symbol == Symbol.X) {
                    Console.Write($" {piece} ");
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($" {piece} ");
                    Console.ForegroundColor = aux;
                }
            }
        }

        public static MatchPosition ReadPosition() {
            string p = Console.ReadLine().ToLower();

            int row = int.Parse(p[0] + "");
            char column = p[1];

            return new MatchPosition(row, column);
        }
    }
}
