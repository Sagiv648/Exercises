using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Code.BinaryTrees
{
    internal class _2022_Summer_A_7 : IClassMethods
    {
        BinNode<char> root;
        public void GenereateInput()
        {
            root = new BinNode<char>('h');
            root.SetLeft(new BinNode<char>('n'));
            root.GetLeft().SetLeft(new BinNode<char>('p'));
            root.SetRight(new BinNode<char>('e'));
            root.GetRight().SetRight(new BinNode<char>('l'));
            root.GetRight().GetRight().SetLeft(new BinNode<char>('p'));
            root.GetRight().GetRight().GetLeft().SetRight(new BinNode<char>('o'));
        }

        public static bool WordFromRoot(BinNode<char> tree, string str, int start)
        {
            if (tree == null || start >= str.Length )
                return true;

            if(tree != null && !tree.HasRight() && !tree.HasLeft())
            {
                return start + 1 >= str.Length && tree.GetValue() == str[start];
            }


            if (str[start] != tree.GetValue())
                return false;


            

            bool left = false;
            bool right = false;

            if(tree.HasLeft())
            {
                left = true && WordFromRoot(tree.GetLeft(), str, start + 1);
            }
            if(tree.HasRight())
            {
                right = true && WordFromRoot(tree.GetRight(), str, start + 1);
            }
            

            return left || right;
            
        }

        public void Work()
        {
            GenereateInput();
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(root);
            //Console.WriteLine(this);
            Console.WriteLine(WordFromRoot(root,"hep",0));
        }
    }
}
