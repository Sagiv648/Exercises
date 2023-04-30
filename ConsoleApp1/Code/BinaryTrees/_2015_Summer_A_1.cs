using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Code.BinaryTrees
{
    class _2015_Summer_A_1 : IClassMethods
    {
        BinNode<string> root;

        public void GenereateInput()
        {
            root = new BinNode<string>("AND");
            root.SetRight(new BinNode<string>("T"));
            root.SetLeft(new BinNode<string>("AND"));
            root.GetLeft().SetLeft(new BinNode<string>("T"));
            root.GetLeft().SetRight(new BinNode<string>("T"));

            //root = new BinNode<string>("AND");
            //root.SetRight(new BinNode<string>("F"));
            //root.SetLeft(new BinNode<string>("OR"));
            //root.GetLeft().SetLeft(new BinNode<string>("F"));
            //root.GetLeft().SetRight(new BinNode<string>("T"));
        }

        public static bool BooleanExpressionTree(BinNode<string> root)
        {
            if (root == null)
                return true;

            if (root.GetValue() == "AND")
            {
                return BooleanExpressionTree(root.GetLeft()) && BooleanExpressionTree(root.GetRight());
            }
            else if (root.GetValue() == "OR")
            {
                return BooleanExpressionTree(root.GetLeft()) || BooleanExpressionTree(root.GetRight());
            }

            else if (root.GetValue() == "F")
                return false;
            else
                return true;
            
            
            
        }

        public void Work()
        {
            GenereateInput();
            Console.WriteLine(BooleanExpressionTree(root));
            
        }
    }
}
