using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Code.BinaryTrees
{
    class _2016_Summer_A_6 : IClassMethods
    {
        BinNode<int> root;
        public void GenereateInput()
        {
            root = new BinNode<int>(1);
            root.SetLeft(new BinNode<int>(6));
            root.GetLeft().SetRight(new BinNode<int>(4));
            root.GetLeft().SetLeft(new BinNode<int>(3));
            root.SetRight(new BinNode<int>(2));
            root.GetRight().SetRight(new BinNode<int>(11));
            root.GetRight().GetRight().SetRight(new BinNode<int>(10));
            root.GetRight().SetLeft(new BinNode<int>(17));
            root.GetRight().GetLeft().SetLeft(new BinNode<int>(19));
        }

        public static bool UpPath(BinNode<int> tr)
        {
            if (tr == null || !tr.HasLeft() && !tr.HasRight())
                return true;
            bool left = false;
            bool right = false;
            if(tr.HasLeft())
            {
                if (tr.GetValue() < tr.GetLeft().GetValue())
                {
                    left = true && UpPath(tr.GetLeft());
                }
                
                
            }
            if(tr.HasRight())
            {
                if (tr.GetValue() < tr.GetRight().GetValue())
                {
                    right = true && UpPath(tr.GetRight());
                }
                
            }


            return left || right ;
        }

        public void Work()
        {
            GenereateInput();
            Console.WriteLine(UpPath(root));
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(root);
        }
    }
}
