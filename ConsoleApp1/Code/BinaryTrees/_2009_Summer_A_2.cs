using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.BinaryTrees
{
    public class _2009_Summer_A_2 : IClassMethods
    {
        BinNode<int> root;
        BinNode<char> sec;
        public void GenereateInput()
        {
            
        }

        public bool IsRightLeftTree(BinNode<int> root)
        {
            if (root == null)
                return true;
            bool flag = true;
            if(root.HasRight())
            {
                flag = root.HasLeft();
            }
            
           
            return flag && IsRightLeftTree(root.GetLeft()) && IsRightLeftTree(root.GetRight());
                
        }
        public void Work()
        {
            //X A I O N Y T D S -> preorder
            
            
            
            //I N O A X D T S Y -> inorder


            //I N O -> children of A
            //T S Y -> children of D

            //    X
            //   / \
            //  A   D
            // /     \
           // N       S
         // /  \     /  \
        // I    O   T     Y





            //root = X
            //root.left = A
            //root.left.left = I
            //root.left.left.left = N
            //root.left.left.left.left = O
            
        }
    }
}
