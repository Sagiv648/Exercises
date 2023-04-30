using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.BinaryTrees
{

    class _2014_Summer_A_1 : IClassMethods
    {
        BinNode<int> rootUnbalanced;
        BinNode<int> rootBalanced;
        public void GenereateInput()
        {
            rootUnbalanced = new BinNode<int>(1);
            rootUnbalanced.SetLeft(new BinNode<int>(2));
            rootUnbalanced.GetLeft().SetLeft(new BinNode<int>(3));
            rootUnbalanced.GetLeft().SetRight(new BinNode<int>(4));
            //rootUnbalanced.SetRight(new BinNode<int>(5));

            rootBalanced = new BinNode<int>(1);
            rootBalanced.SetRight(new BinNode<int>(2));
            rootBalanced.SetLeft(new BinNode<int>(3));
        }

        public static bool IsBalanced(BinNode<int> root)
        {
            if (root == null)
                return true;
            int depthLeft = 0;
            int depthRight = 0;
            if(root.HasLeft())
            {
                BinNode<int> tmp = root.GetLeft();
                while(tmp != null)
                {
                    tmp = tmp.GetLeft();
                    depthLeft++;
                }
            }
            if (root.HasRight())
            {
                BinNode<int> tmp = root.GetRight();
                while(tmp != null)
                {
                    tmp = tmp.GetRight();
                    depthRight++;
                }
            }

            return IsBalanced(root.GetLeft()) && IsBalanced(root.GetRight()) && 
                (Math.Abs(depthLeft-depthRight) <= 1);
        }

        

        public void Work()
        {
            GenereateInput();
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(rootUnbalanced);
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(rootBalanced);
            //Console.WriteLine(IsBalanced(rootUnbalanced));

        }
    }
}
