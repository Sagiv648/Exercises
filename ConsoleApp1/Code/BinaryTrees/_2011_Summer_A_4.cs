using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.BinaryTrees
{
    public class _2011_Summer_A_4 : IClassMethods
    {
        BinNode<int> root;
        BinNode<int> root2;
        public static void Leaves(BinNode<int> t, Stack<int> s)
        {
            if (t == null)
                return;

            if (t != null && t.GetLeft() == null && t.GetRight() == null)
                s.Push(t.GetValue());


            Leaves(t.GetRight(), s);
            Leaves(t.GetLeft(), s);


        }
        public static bool SameLeavesNumAndValues(BinNode<int> root1, BinNode<int> root2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();
            Leaves(root1, s1);
            Leaves(root2, s2);
            while(!s1.IsEmpty() && !s2.IsEmpty())
            {
                if (s1.Pop() != s2.Pop())
                    return false;
            }

            return s1.IsEmpty() && s2.IsEmpty();

        }

        public void GenereateInput()
        {
            root = new BinNode<int>(1);
            root.SetLeft(new BinNode<int>(2));
            root.SetRight(new BinNode<int>(3));
            root.GetRight().SetRight(new BinNode<int>(4));

            root2 = new BinNode<int>(1);
            root2.SetLeft(new BinNode<int>(2));
            root2.SetRight(new BinNode<int>(3));
            //root2.GetRight().SetRight(new BinNode<int>(5));
        }

        public void Work()
        {
            GenereateInput();
            Stack<int> s = new Stack<int>();
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(root);
            Console.WriteLine(SameLeavesNumAndValues(root,root2));
        }
    }
}
