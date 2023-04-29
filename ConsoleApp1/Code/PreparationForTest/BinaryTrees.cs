using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.PreparationForTest
{
    public class BinaryTrees : IClassMethods
    {

        //-------------------------------------------- Binary Trees --------------------------------------


        //bin tree -> morris traversal
        public static void MorrisTraversalInorder(BinNode<int> root)
        {
            BinNode<int> current = root;
            while (current != null)
            {
                //left is null, then process the node and go right
                if (current.GetLeft() == null)
                {
                    Console.Write($" {current} ");
                    current = current.GetRight();
                }
                else
                {
                    //find the predecessor
                    BinNode<int> predecessor = current.GetLeft();

                    //To find predecessor, keep going right
                    // until right node is not null or right node is not current
                    while (predecessor.GetRight() != current && predecessor.GetRight() != null)
                        predecessor = predecessor.GetRight();

                    //if right node is not null, then go left after establishing a link from predecessor to current
                    if (predecessor.GetRight() == null)
                    {
                        predecessor.SetRight(current);
                        current = current.GetLeft();
                    }

                    //left is already visited, go right after visiting current
                    else
                    {
                        predecessor.SetRight(null);
                        Console.Write($" {current} ");
                        current = current.GetRight();
                    }

                }
            }
        }

        public static void MorrisTraversalPreorder(BinNode<int> root)
        {
            BinNode<int> current = root;
            while (current != null)
            {
                if (current.GetLeft() == null)
                {
                    Console.Write($" {current} ");
                    current = current.GetRight();
                }
                else
                {
                    BinNode<int> predecessor = current.GetLeft();
                    while (predecessor.GetRight() != current && predecessor.GetRight() != null)
                        predecessor = predecessor.GetRight();
                    if (predecessor.GetRight() == null)
                    {
                        predecessor.SetRight(current);
                        Console.Write($" {current} ");
                        current = current.GetLeft();
                    }
                    else
                    {
                        predecessor.SetRight(null);
                        current = current.GetRight();
                    }
                }
            }
        }

        //bin tree -> Max depth
        public static int MaxDepth(BinNode<int> root)
        {
            if (root == null)
                return 0;

            int maxLeft = MaxDepth(root.GetLeft());
            int maxRight = MaxDepth(root.GetRight());
            if (maxLeft > maxRight)
                return 1 + maxLeft;
            else

                return 1 + maxRight;

        }

        //bin tree -> Level Order Traversal
        //Using MaxDepth to find height of tree
        public static void PrintCurrentLevel(BinNode<int> root, int height)
        {
            if (root == null) return;
            if (height == 1)
                Console.Write($" {root} ");

            PrintCurrentLevel(root.GetLeft(), height - 1);
            PrintCurrentLevel(root.GetRight(), height - 1);
        }
        public static void LevelOrderTraversal(BinNode<int> root)
        {
            int maxHeight = MaxDepth(root);
            for (int i = 1; i <= maxHeight; i++)
            {
                PrintCurrentLevel(root, i);
                Console.WriteLine();
            }
        }

        //bin tree -> Check if a Bin tree is a BST
        static bool IsBstUtil(BinNode<int> root, int minBoundary, int maxBoundary)
        {
            if (root == null)
                return true;

            if (root.GetValue() < minBoundary || root.GetValue() > maxBoundary)
                return false;

            return IsBstUtil(root.GetLeft(), minBoundary, root.GetValue())
                   && IsBstUtil(root.GetRight(), root.GetValue(), maxBoundary);
        }
        public static bool IsBst(BinNode<int> root)
        {
            return IsBstUtil(root, int.MinValue, int.MaxValue);
        }

        //bin tree -> Sum of root to leaf path
        static int RootLeavesDigitToNumSumUtil(BinNode<int> root, int num)
        {
            if (root == null)
                return 0;
            num = num * 10 + root.GetValue();
            if (!root.HasLeft() && !root.HasRight())
                return num;
            return RootLeavesDigitToNumSumUtil(root.GetLeft(), num) + RootLeavesDigitToNumSumUtil(root.GetRight(), num);
        }
        public static int RootLeavesDigitsToNumSum(BinNode<int> root)
        {

            return RootLeavesDigitToNumSumUtil(root, 0);
        }

        //bin tree -> Merge 2 bin trees
        public static BinNode<int> MergeBinaryTrees(BinNode<int> root1, BinNode<int> root2)
        {
            if (root1 == null && root2 == null)
                return null;

            int val1 = 0;
            int val2 = 0;
            if (root1 != null)
                val1 = root1.GetValue();
            if (root2 != null)
                val2 = root2.GetValue();

            BinNode<int> root = new BinNode<int>(val1 + val2);

            if (root1 != null && root2 != null)
            {
                root.SetLeft(MergeBinaryTrees(root1.GetLeft(), root2.GetLeft()));
                root.SetRight(MergeBinaryTrees(root1.GetRight(), root2.GetRight()));

            }
            else if (root1 == null && root2 != null)
            {
                root.SetLeft(MergeBinaryTrees(null, root2.GetLeft()));
                root.SetRight(MergeBinaryTrees(null, root2.GetRight()));
            }
            else if (root1 != null && root2 == null)
            {
                root.SetLeft(MergeBinaryTrees(root1.GetLeft(), null));
                root.SetRight(MergeBinaryTrees(root1.GetRight(), null));
            }

            return root;

        }

        //bin tree -> Sorted array to BST
        public static BinNode<int> SortedArrayToBst(int[] arr, int start, int end)
        {
            if (start > end)
                return null;

            int mid = start + (end - start) / 2;

            BinNode<int> root = new BinNode<int>(arr[mid]);
            root.SetLeft(SortedArrayToBst(arr, start, mid - 1));
            root.SetRight(SortedArrayToBst(arr, mid + 1, end));
            return root;
        }

        //bin tree -> Invert Binary Tree
        public static void InvertBinaryTree(BinNode<int> root)
        {
            if (root == null)
                return;

            BinNode<int> tmp = root.GetLeft();
            root.SetLeft(root.GetRight());
            root.SetRight(tmp);

            InvertBinaryTree(root.GetLeft());
            InvertBinaryTree(root.GetRight());
        }

        //bin tree -> KthSmallestElement (Morris Traversal)
        public static BinNode<int> KthSmallestElement(BinNode<int> root, int k)
        {
            BinNode<int> current = root;
            int count = 0;
            BinNode<int> kSmall = null;
            while (current != null)
            {
                if (current.GetLeft() == null)
                {
                    count++;
                    if (count == k)
                        kSmall = current;
                    current = current.GetRight();
                }
                else
                {
                    BinNode<int> predecessor = current.GetLeft();
                    while (predecessor.GetRight() != null && predecessor.GetRight() != current)
                        predecessor = predecessor.GetRight();
                    if (predecessor.GetRight() == null)
                    {
                        predecessor.SetRight(current);
                        current = current.GetLeft();
                    }
                    else
                    {
                        predecessor.SetRight(null);

                        count++;
                        if (count == k)
                            kSmall = current;

                        current = current.GetRight();

                    }
                }
            }


            return kSmall;

        }

        //bin tree -> KthBiggestElement (Morris Traversal)
        public static BinNode<int> KthBiggestElement(BinNode<int> root, int k)
        {
            BinNode<int> current = root;
            int count = 0;
            BinNode<int> kBig = null;

            while (current != null)
            {
                //left is null, then process the node and go right
                if (current.GetRight() == null)
                {
                    count++;
                    if (count == k)
                        kBig = current;
                    current = current.GetLeft();

                }
                else
                {
                    //find the predecessor
                    BinNode<int> successor = current.GetRight();

                    //To find predecessor, keep going right
                    // until right node is not null or right node is not current
                    while (successor.GetLeft() != current && successor.GetLeft() != null)
                        successor = successor.GetLeft();

                    //if right node is not null, then go left after establishing a link from predecessor to current
                    if (successor.GetLeft() == null)
                    {
                        successor.SetLeft(current);
                        current = current.GetRight();
                    }

                    //left is already visited, go right after visiting current
                    else
                    {
                        successor.SetLeft(null);
                        count++;
                        if (count == k)
                            kBig = current;
                        current = current.GetLeft();

                    }

                }
            }


            return kBig;

        }

        //bin tree -> LowestCommonAncestor
        public static BinNode<int> LowestCommonAncestor(BinNode<int> root, int num1, int num2)
        {
            BinNode<int> current = root;
            while (current != null)
            {
                if (num1 < current.GetValue() && num2 < current.GetValue())
                    current = current.GetLeft();
                else if (num1 > current.GetValue() && num2 > current.GetValue())
                {
                    current = current.GetRight();
                }
                else
                    break;
            }
            return current;
        }

        //bin tree -> All nodes greater than k
        public static int BstGreaterThanK(BinNode<int> root, int k)
        {
            if (root == null)
                return 0;

            int left = BstGreaterThanK(root.GetLeft(), k);
            int right = BstGreaterThanK(root.GetRight(), k);

            if (root.GetValue() > k)
                return 1 + left + right;
            else
                return left + right;
        }

        //bin trees -> Identical trees
        public static bool IdenticalTrees(BinNode<int> root1, BinNode<int> root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;

            return root1.GetValue() == root2.GetValue()
                && IdenticalTrees(root1.GetLeft(), root2.GetLeft())
                && IdenticalTrees(root1.GetRight(), root2.GetRight());
        }

        //bin tree -> Construct Bin tree from inorder array and preorder array
        public BinNode<int> ConstructBinTreeFromInorderPreorder(int[] preorder, int[] inorder)
        {
            return Helper(0, 0, inorder.Length - 1, preorder, inorder);
        }
        public BinNode<int> Helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            if (preStart > preorder.Length - 1 || inStart > inEnd)
            {
                return null;
            }
            BinNode<int> root = new BinNode<int>(preorder[preStart]);
            int inIndex = 0; // Index of current root in inorder
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == root.GetValue())
                {
                    inIndex = i;
                }
            }
            root.SetLeft(Helper(preStart + 1, inStart, inIndex - 1, preorder, inorder));
            root.SetRight(Helper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inorder));
            return root;
        }

        //bin tree -> Bin trees permuations of 1...k
        public static int UniqueBstPermutationsByK(int k)
        {
            int[] numTrees = new int[k + 1];

            for (int i = 0; i < numTrees.Length; i++)
                numTrees[i] = 1;

            for (int nodes = 2; nodes < k + 1; nodes++)
            {
                int total = 0;
                for (int root = 1; root < nodes + 1; root++)
                {
                    int left = root - 1;
                    int right = nodes - root;
                    total += numTrees[left] * numTrees[right];
                }
                numTrees[nodes] = total;
            }
            return numTrees[k];
        }


        public void GenereateInput()
        {
            
        }

        public void Work()
        {
            BinNode<int> root = new BinNode<int>(10);
            root.SetLeft(new BinNode<int>(143));
            root.SetRight(new BinNode<int>(78));
            root.GetRight().SetRight(new BinNode<int>(14));
            root.GetRight().SetLeft(new BinNode<int>(468));
            root.GetLeft().SetLeft(new BinNode<int>(690));


            Console.WriteLine(UniqueBstPermutationsByK(2));



            //LevelOrderTraversal(root);
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(root);

            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(root);

            //BinNode<int> root2 = new BinNode<int>(10);
            //root2.SetLeft(new BinNode<int>(3));
            //root2.GetLeft().SetLeft(new BinNode<int>(4));
            //root2.GetLeft().GetLeft().SetLeft(new BinNode<int>(5));
            //root2.SetRight(new BinNode<int>(2));

            //int[] testcase = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };


            //BinNode<int> rootTest = SortedArrayToBst(testcase, 0, testcase.Length - 1);

            //BinNode<int> rootTest2 = SortedArrayToBst(testcase, 0, testcase.Length - 1);
            //Console.WriteLine(IdenticalTrees(rootTest,rootTest2));
            //LevelOrderTraversal(rootTest);
            //Console.WriteLine(BstGreaterThanK(rootTest,0));
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(rootTest);
            ////Console.WriteLine(  KthSmallestElement(rootTest, 2) );
            ////Console.WriteLine(KthBiggestElement(rootTest,2));
            ////MorrisTraversalInorder(rootTest);
            //Console.WriteLine();
            ////MorrisTraversalPreorder(rootTest);
            //Unit4.BinTreeCanvasLib.TreeCanvas.AddTree(rootTest);
            //Console.WriteLine(MaxDepth(rootTest));
        }
    }
}
