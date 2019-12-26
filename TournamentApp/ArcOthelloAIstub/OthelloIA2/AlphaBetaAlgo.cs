using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAIstub
{
    class AlphaBetaAlgo
    {
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
