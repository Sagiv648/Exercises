using ConsoleApp1.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.BinarySearchTree
{
    public class BstLCA : IClassMethods
    {

        static BinNode<int> LowestCommonAncestor(BinNode<int> root, int key1, int key2)
        {
            if (root == null)
                return null;

            if (key2 < root.GetValue())
                return LowestCommonAncestor(root.GetLeft(), key1, key2);
            else if (key1 > root.GetValue())
                return LowestCommonAncestor(root.GetRight(), key1, key2);
            else 
                return root;
        }

        static BinNode<int> Insert(BinNode<int> root, int key)
        {
            BinNode<int> curr = root;
            BinNode<int> parent = null;

            while(curr != null)
            {
                parent = curr;
                if (key < curr.GetValue())
                    curr = curr.GetLeft();
                else if (key > curr.GetValue())
                    curr = curr.GetRight();
                else
                    return curr;
            }
            BinNode<int> res = new BinNode<int>(key);
            if(parent != null)
            {
                if (parent.GetValue() > key)
                    parent.SetLeft(res);
                else if (parent.GetValue() < key)
                    parent.SetRight(res);
                else
                    return parent;
                    
            }
            return res;
            
        }
        static void Inorder(BinNode<int> root)
        {
            if (root == null)
                return;
            Inorder(root.GetLeft());
            Console.WriteLine(root);
            Inorder(root.GetRight());
        }

        public void Work()
        {
            int[] x = new int[] { 5, 8, 1, 7, 2,3 ,6, 20, 9, 30, 15 };
            BinNode<int> root = null;
            root = Insert(root, x[0]);
            foreach (var item in x)
            {
                Insert(root, item);
            }

            
            
            Console.WriteLine($"LCA is: {LowestCommonAncestor(root,2,20)}");
            Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(root);
        }

        public void GenereateInput()
        {
            throw new NotImplementedException();
        }
    }
}
