using gameBoard;
using gameBoard.Enums;
using gameBoard.Exceptions;
using System;

namespace Tic_Tac_Toe {
    internal static class Screen {
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
    }
}
