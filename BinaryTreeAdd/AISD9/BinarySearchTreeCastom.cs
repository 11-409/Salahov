using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD9
{
    internal class BinarySearchTreeCastom
    {
        public Node root;

        public Node Add(int value, Node node)
        {

            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.d)
            {
                node.Left = Add(value, node.Left);
            }
            else if (value > node.d)
            {
                node.Right = Add(value, node.Right);
            }

            return node;
        }

        public bool Search(int n, Node node)
        {
            if(node == null) return false;
            if (n == node.d) return true;
            if (n > node.d) return Search(n, node.Right);
            return Search(n, node.Left);
        }
    }
}

//для уменьшения размерности рекурсии - нужно принимать то, что уменьшается
//для графа - нода (мы же с каждым шагом двигаемся вниз)
//для метода с рекурсией - пиши сначала базу рекурсии