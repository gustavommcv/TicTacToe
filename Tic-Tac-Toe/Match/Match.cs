﻿using gameBoard.Enums;
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

        private void ChangePlayer() {
            CurrentPlayer = (CurrentPlayer == Symbol.X) ? Symbol.O : Symbol.X;
        }

        public void PerformsPlay(Position p) {
            GameBoard.AddPiece(CurrentPlayer, p);
            
            if (!CheckWinner())
                ChangePlayer();
        }

        public bool CheckWinner() {
            for (int i = 0; i < 3; i++) {
                // Check rows
                if (GameBoard.GetPiece(i, 0) != null && GameBoard.GetPiece(i, 1) != null && GameBoard.GetPiece(i, 0) != null && GameBoard.GetPiece(i, 2) != null)
                    if (GameBoard.GetPiece(i, 0).Symbol == GameBoard.GetPiece(i, 1).Symbol && GameBoard.GetPiece(i, 0).Symbol == GameBoard.GetPiece(i, 2).Symbol) {
                        Finished = true;
                        return true;
                    }

                // Check columns
                if (GameBoard.GetPiece(0, i) != null && GameBoard.GetPiece(1, i) != null && GameBoard.GetPiece(0, i) != null && GameBoard.GetPiece(2, i) != null)
                    if (GameBoard.GetPiece(0, i).Symbol == GameBoard.GetPiece(1, i).Symbol && GameBoard.GetPiece(0, i).Symbol == GameBoard.GetPiece(2, i).Symbol) {
                        Finished = true;
                        return true;
                    }
            }

            // Check diagonals
            if (GameBoard.GetPiece(0, 0) != null && GameBoard.GetPiece(1, 1) != null && GameBoard.GetPiece(0, 0) != null && GameBoard.GetPiece(2, 2) != null)
                if (GameBoard.GetPiece(0, 0).Symbol == GameBoard.GetPiece(1, 1).Symbol && GameBoard.GetPiece(0, 0).Symbol == GameBoard.GetPiece(2, 2).Symbol) {
                    Finished = true;
                    return true;
                }

            if (GameBoard.GetPiece(0, 2) != null && GameBoard.GetPiece(1, 1) != null && GameBoard.GetPiece(0, 2) != null && GameBoard.GetPiece(2, 0) != null)
                if (GameBoard.GetPiece(0, 2).Symbol == GameBoard.GetPiece(1, 1).Symbol && GameBoard.GetPiece(0, 2).Symbol == GameBoard.GetPiece(2, 0).Symbol) {
                    Finished = true;
                    return true;
                }

            return false;
        }
    }
}
