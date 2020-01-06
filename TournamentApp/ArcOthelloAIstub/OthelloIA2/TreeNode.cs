using IACapocasaleMoulin;
using System;
using System.Collections.Generic;

namespace OthelloAIstub
{
    class TreeNode
    {
        private readonly bool isWhitePlayer;
        private readonly OthelloBoard board; 

        /// <summary>
        /// Constructor of TreeNode
        /// </summary>
        /// <param name="board">Instance of the primary board</param>
        /// <param name="isWhitePlayer">indicated if the player is white or black</param>
        public TreeNode(OthelloBoard board, bool isWhitePlayer)
        {
            this.isWhitePlayer = isWhitePlayer;
            this.board = board;
        }

        /// <summary>
        /// Score function. Return a score for a given board for each box.
        /// </summary>
        /// <returns>Returns a score for a given board</returns>
        public int Score()
        {
            int score = 0;
            int[,] theBoard = board.GetBoard();
            int playerVal = isWhitePlayer ? 1 : 0; // Get the player value in the board array

            for (int i = 0; i < theBoard.GetLength(1); i++)
            {
                for (int j = 0; j < theBoard.GetLength(0); j++)
                {
                    int boardValue = theBoard[j, i];

                    if(boardValue != -1)
                    {
                        if (boardValue == playerVal)
                        {
                            score += OthelloBoard.SCORE_MATRIX[j, i]; // Add the matrix score if is the correct player
                        }
                        else
                        {
                            score -= OthelloBoard.SCORE_MATRIX[j, i]; // Substract the matrix score if is the other player
                        }
                    }
                }
            }

            Tuple<int, int> nbPawns = OthelloBoard.CountPawn(theBoard, playerVal);

            score += 25 * ((nbPawns.Item1 + nbPawns.Item2 + 1) % 2);//Add a weight if the current user play the last move

            score += 25 * ((nbPawns.Item1 - nbPawns.Item2) / (nbPawns.Item1 + nbPawns.Item2));//Add a weight from the pawn parity

            Tuple<int, int> nbCorners = OthelloBoard.CountCorner(theBoard, playerVal);

            if(nbCorners.Item1 + nbCorners.Item2 != 0)
            {
                score += 100 * (nbCorners.Item1 - nbCorners.Item2) / (nbCorners.Item1 + nbCorners.Item2);//Add weight from the number of captured corner
            }

            // If the state is final
            if (IsFinal())
            {
                // If the score is positive, the user win
                if (score > 0)
                {
                    return Int32.MaxValue-1;
                }
                else // If the score is negative, the user loose
                {
                    return Int32.MinValue+1;
                }
            }

            return score;
             
        }

        /// <summary>
        /// Apply a move in a board
        /// </summary>
        /// <param name="move">a given move</param>
        /// <returns>A tree node with the applied operator</returns>
        public TreeNode ApplyOp(Tuple<int, int> move)
        {
            OthelloBoard newOB = new OthelloBoard(board.GetBoard()); // Make a copy of the board

            newOB.PlayMove(move.Item1, move.Item2, isWhitePlayer);
            return new TreeNode(newOB, !isWhitePlayer);
        }

        /// <summary>
        /// Return the list of all posibles moves
        /// </summary>
        /// <returns>List of possibles moves</returns>
        public List<Tuple<int,int>> ListOps()
        {
            return board.GetPossibleMove(isWhitePlayer);
        }

        /// <summary>
        /// Indicated if node is a final node. The game is ended.
        /// </summary>
        /// <returns>Boolean indicated if the game is ended or not</returns>
        public bool IsFinal()
        {
            return board.GetPossibleMove(isWhitePlayer).Count == 0;
        }
    }
}
