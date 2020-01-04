using IAStub;
using System;
using System.Collections.Generic;

namespace OthelloAIstub
{
    class TreeNode
    {
        private bool isWhitePlayer;
        private OthelloBoard board; 

        /// <summary>
        /// COnstructor of TreeNode
        /// </summary>
        /// <param name="board">Instance of the primary board</param>
        /// <param name="isWhitePlayer">indicated if is the white player or not</param>
        public TreeNode(OthelloBoard board, bool isWhitePlayer)
        {
            this.isWhitePlayer = isWhitePlayer;
            this.board = board;
        }

        /// <summary>
        /// Score function. Return a score for a given board.
        /// </summary>
        /// <returns>Return a score for a board</returns>
        public int Score()
        {
            int score = 0;
            int[,] theBoard = board.GetBoard();
            int playerVal = isWhitePlayer ? 1 : 0;//Get the player value in the board array

            for (int i = 0; i < theBoard.GetLength(0); i++)
            {
                for (int j = 0; j < theBoard.GetLength(1); j++)
                {
                    int boardValue = theBoard[i, j];
                    if (boardValue == playerVal)
                    {
                        score +=  OthelloBoard.SCORE_MATRIX[i, j];//add the matrix score if is the correct player
                    }
                    else
                    {
                        score -= OthelloBoard.SCORE_MATRIX[i, j]; //substract the matrix score if is the other player
                    }
                }
            }

            //If the state is final, 
            if(isFinal())
            {
                //If the score is positive, the user win
                if (score > 0)
                {
                    return Int32.MaxValue;
                }
                else//If the score is negative, the user loose
                {
                    return Int32.MinValue;
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
            OthelloBoard newOB = new OthelloBoard(board.GetBoard());
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
        public bool isFinal()
        {
            return board.GetPossibleMove(isWhitePlayer).Count == 0;
        }
    }
}
