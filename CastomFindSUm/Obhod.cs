using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD8
{
    internal class Obhod
    {
        public int max = 0;
        public int sum = 0;
        public void DoObhod(NodeCastom nodeCastom)
        {
            if(nodeCastom != null)
            {
                DoObhod(nodeCastom.Left);   //L
                Console.WriteLine(nodeCastom.d);  //D
                DoObhod(nodeCastom.Right); //R
            }
        }

        public int MaxFind(NodeCastom nodeCastom)
        {
            int a = 0, b = 0;
                max = nodeCastom.d;

                if (nodeCastom.Left!= null)
                {
                   a = MaxFind(nodeCastom.Left);
                }

                if (nodeCastom.Right != null)
                {
                   b = MaxFind(nodeCastom.Right);
                }

                int localMax = Math.Max(max, a);
                localMax = Math.Max(max, b);

                return localMax;
        }

        public int FindSum(NodeCastom nodeCastom)
        {
            if (nodeCastom == null) return 0;
            sum += nodeCastom.d + FindSum(nodeCastom.Left) + FindSum(nodeCastom.Right);
            return sum;
        }
    }
}
