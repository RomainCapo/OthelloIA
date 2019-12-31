using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAIstub
{
    class AlphaBetaAlgo
    {
        /// <summary>
        /// Alphabeta algortihm
        /// </summary>
        /// <param name="root">A root node</param>
        /// <param name="depth">Max depth</param>
        /// <param name="minOrMax">Min or max node</param>
        /// <param name="parentvalue">Value of parent node</param>
        /// <returns>return a tuple, the first tuple value is the score of the move, the second value is a tuple wich represent a move</returns>
        public static Tuple<int, Tuple<int, int>> Alphabeta(TreeNode root, int depth, int minOrMax, int parentvalue)
        {
            if (depth == 0 || root.isFinal())
            {
                return new Tuple<int, Tuple<int, int>>(root.Score(), null);
            }

            int optVal = minOrMax * -int.MaxValue;
            Tuple<int, int> optOp = null;

            foreach (Tuple<int, int> move in root.ListOps())
            {
                TreeNode newNode = root.ApplyOp(move);

                Tuple<int, Tuple<int, int>> newMove = Alphabeta(newNode, depth - 1, -minOrMax, optVal);

                if ((newMove.Item1 * minOrMax) > (optVal * minOrMax))
                {
                    optVal = newMove.Item1;
                    optOp = move;

                    if ((optVal * minOrMax) > (parentvalue * minOrMax))
                    {
                        break;
                    }
                }
            }

            return new Tuple<int, Tuple<int, int>>(optVal, optOp);
        }
    }
}
