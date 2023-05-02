using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.SophieWork
{
    public class Assignment_27_4_23 : IClassMethods
    {
        Node<int> head;
        

        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public void SwapStacks(Stack<int> stack1, Stack<int> stack2)
        {
            Stack<int> tmp = new Stack<int>();
            
            int S2len = 0;
            while (!stack1.IsEmpty())
            {
                tmp.Push(stack1.Pop());
                
            }
                
            while(!stack2.IsEmpty())
            {
                tmp.Push(stack2.Pop());
                S2len++;
            }
            while(!tmp.IsEmpty())
            {
                if(S2len > 0)
                {
                    stack1.Push(tmp.Pop());
                    S2len--;
                }
                else
                {
                    stack2.Push(tmp.Pop());
                }
            }
        }


        
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

        
        
        public static void NumbersRelations(BinNode<int> root, int num1, int num2)
        {
            if (root == null)
                return;

            if (root.HasRight() && root.HasLeft())
            {

                if ((root.GetLeft().GetValue() == num1 && root.GetRight().GetValue() == num2)
                   || (root.GetRight().GetValue() == num1 && root.GetLeft().GetValue() == num2))
                {

                    Console.WriteLine($"{num1} is sibling to {num2}");
                    return;
                }
                
            }
            
            if (root.HasRight())
            {
                if (root.GetValue() == num1 && root.GetRight().GetValue() == num2)
                {
                    Console.WriteLine($"{num1} is parent to {num2} ");
                    return;
                }
                else if (root.GetValue() == num2 && root.GetRight().GetValue() == num1)
                {
                    Console.WriteLine($"{num2} is parent to {num1} ");
                    return;
                }

            }
            if (root.HasLeft())
            {

                if (root.GetValue() == num1 && root.GetLeft().GetValue() == num2)
                {
                    Console.WriteLine($"{num1} is parent to {num2} ");
                    return;
                }
                else if(root.GetValue() == num2 && root.GetLeft().GetValue() == num1)
                {
                    Console.WriteLine($"{num2} is parent to {num1} ");
                    return;
                }

            }
            
            Console.WriteLine("no immeediate relations");
            
             NumbersRelations(root.GetLeft(), num1, num2);
             NumbersRelations(root.GetRight(), num1, num2);

            


        }
        



        public static int LeavesCount(BinNode<int> root)
        {
            if (root == null)
                return 0;
            if (!root.HasLeft() && !root.HasRight())
                return 1;
            return LeavesCount(root.GetLeft()) + LeavesCount(root.GetRight());
        }

        
        public static void RemoveDuplicates(Node<int> head)
        {
            Node<int> tmp = head;

            while(tmp != null && tmp.GetNext() != null)
            {
                Node<int> tmpSec = tmp;
                while(tmpSec.GetNext() != null)
                {
                    if (tmpSec.GetNext().GetValue() == tmp.GetValue())
                        tmpSec.SetNext(tmpSec.GetNext().GetNext());
                    else
                        tmpSec = tmpSec.GetNext();
                }
                tmp = tmp.GetNext();
            }
        }


        
        public Node<int> RotateListByK(Node<int> head, int k)
        {
            if (head == null)
                return head;

            int len = 1;
            Node<int> tail = head;
            while (tail.HasNext())
            {
                tail = tail.GetNext();
                len++;
            }
            
            k %= len;
            if (k == 0)
                return head;
            Node<int> tmp = head;
            for(int i = 0; i < len-k-1; i++)
                tmp = tmp.GetNext();
            Node<int> newHead = tmp.GetNext();
            tmp.SetNext(null);
            tail.SetNext(head);
            return newHead;
            
                
            
        }

        public void PrintList(Node<int> head)
        {
            Node<int> tmp = head;
            while(tmp != null)
            {
                Console.Write($" {tmp} ");
                tmp = tmp.GetNext();
            }
            Console.WriteLine();
        }

        //Implemented from IClassMethods
        public void GenereateInput()
        {
            int[] testcase = { 1,7,2,0,2,5,2,2,2,1,5,6,7,10,0,0,0 };
            head = new Node<int>(testcase[0]);
            Node<int> tmp = head;
            for (int i = 1; i < testcase.Length; i++)
            {
                tmp.SetNext(new Node<int>(testcase[i]));
                tmp = tmp.GetNext();
            }

        }
        //Implemented from IClassMethods
        public void Work()
        {
            GenereateInput();
            RemoveDuplicates(head);
            PrintList(head);
            

            //PrintList(head);




        }
    }
}
