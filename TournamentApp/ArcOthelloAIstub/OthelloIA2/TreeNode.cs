using IAStub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAIstub
{
    class TreeNode
    {
        private bool isWhitePlayer;
        private OthelloBoard board;

        public TreeNode(OthelloBoard board, bool isWhitePlayer)
        {
            this.isWhitePlayer = isWhitePlayer;
            this.board = board;
        }

        public int Score()
        {
            int score = 0;
            int[,] theBoard = board.GetBoard();
            int playerVal = isWhitePlayer ? 1 : 0;
            for (int i = 0; i < theBoard.GetLength(0); i++)
            {
                for (int j = 0; j < theBoard.GetLength(1); j++)
                {
                    int boardValue = theBoard[i, j];
                    if (boardValue == playerVal)
                    {
                        score +=  OthelloBoard.SCORE_MATRIX[i, j];
                    }
                    else
                    {
                        score -= OthelloBoard.SCORE_MATRIX[i, j]; 
                    }
                }
            }

            if(score < 0)
            {
                return 0;
            }
            else
            {
                return score;
            }
        }
        public TreeNode ApplyOp(Tuple<int, int> move)
        {
            board.PlayMove(move.Item1, move.Item2, isWhitePlayer);
            OthelloBoard newOB = new OthelloBoard(board.GetBoard());
            return new TreeNode(newOB, !isWhitePlayer);
        }

        public List<Tuple<int,int>> ListOps()
        {
            return board.GetPossibleMove(isWhitePlayer);
        }

        public bool isFinal()
        {
            return board.GetPossibleMove(isWhitePlayer).Count == 0;
        }
    }
}
