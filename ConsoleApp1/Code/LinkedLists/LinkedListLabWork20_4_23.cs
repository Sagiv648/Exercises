

using System;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code
{
    public class LinkedListLabWork20_4_23 : IClassMethods
    {
        Node<int> list1 = null;
        Node<int> list2 = null;





        public static Node<int> Reverse(Node<int> head)
        {

            Node<int> prev = null;
            Node<int> current = head;

            while( current != null)
            {
                Node<int> tmp = current.GetNext();
                current.SetNext(prev);
                prev = current;

                current = tmp;
            }
            return prev;
        }

        //TODO: Quicksort
        public static Node<int> Quicksort(Node<int> head)
        {
            return null;
        }

        //TODO: Merge
        public static Node<int> Merge(Node<int> head1, Node<int> head2)
        {
            return null;
        }

        //TODO: Kth element from end
        public static Node<int> KthElementFromEnd(Node<int> head, int k)
        {
            return null;
        }

        //TODO: Middle element
        public static Node<int> Middle(Node<int> head)
        {
            return null;
        }

        //TODO: Partition by K
        public static Node<int> PartitionByK(Node<int> head, int k)
        {
            return null;
        }

        //TODO: Find loop node
        public static Node<int> FindLoopNode(Node<int> head)
        {
            return null;
        }
        //public static Node<int> ReverseList(Node<int> node)
        //{
        //    if (node == null || node.GetNext() == null)
        //        return node;

        //    Node<int> e = ReverseList(node.GetNext());
        //    //e => 81
        //    //e->next = 82 (last)
        //    //e-> next = 81
        //    //82 81
        //    node.GetNext().SetNext(node);
        //    node.SetNext(null);
        //    return e;
        //}
        //public static void SortList(Node<int> node)
        //{
        //    Node<int> tmp = node;
        //    while (tmp != null)
        //    {
        //        Node<int> tmpSec = tmp.GetNext();
        //        while (tmpSec != null)
        //        {
        //            if (tmp.GetValue() > tmpSec.GetValue())
        //            {
        //                int val = tmp.GetValue();
        //                tmp.SetValue(tmpSec.GetValue());
        //                tmpSec.SetValue(val);
        //            }
        //            tmpSec = tmpSec.GetNext();
        //        }
        //        tmp = tmp.GetNext();
        //    }
        //}

        //public static Node<int> MergeLists(Node<int> head1, Node<int> head2)
        //{
        //    Node<int> output = null;
        //    Node<int>[] tmp = new Node<int>[] { head1, head2 };
        //    int remaining = -1;
        //    if (head1.GetValue() > head2.GetValue())
        //        remaining = 1;
        //    else
        //        remaining = 0;

        //    output = new Node<int>(tmp[remaining].GetValue());
        //    tmp[remaining] = tmp[remaining].GetNext();


        //    Node<int> outputTmp = output;


        //    while (tmp[0] != null && tmp[1] != null)
        //    {
        //        int iForward = 0;
        //        if (tmp[0].GetValue() < tmp[1].GetValue())
        //        {
        //            outputTmp.SetNext(new Node<int>(tmp[0].GetValue()));
        //            iForward = Convert.ToInt32(false);
        //        }
        //        else
        //        {
        //            outputTmp.SetNext(new Node<int>(tmp[1].GetValue()));
        //            iForward = Convert.ToInt32(true);
        //        }
        //        tmp[iForward] = tmp[iForward].GetNext();

        //        if (tmp[0] == null)
        //            remaining = 1;

        //        else
        //            remaining = 0;

        //        outputTmp = outputTmp.GetNext();
        //    }
        //    while (tmp[remaining] != null)
        //    {
        //        outputTmp.SetNext(new Node<int>(tmp[remaining].GetValue()));
        //        outputTmp = outputTmp.GetNext();
        //        tmp[remaining] = tmp[remaining].GetNext();
        //    }
        //    return output;
        //}


        //public static Node<int> NthFromEnd(Node<int> node, int n)
        //{
        //    Stack<Node<int>> s = new Stack<Node<int>>();
        //    Node<int> tmp = node;
        //    while (tmp != null)
        //    {
        //        s.Push(tmp);
        //        tmp = tmp.GetNext();
        //    }
        //    while (!s.IsEmpty() && n > 0)
        //    {
        //        s.Pop();
        //        n--;
        //    }
        //    return s.Pop();
        //}

        //public static Node<int> MiddleElement(Node<int> node)
        //{
        //    int len = 1;
        //    Node<int> tmp = node;
        //    while (tmp != null)
        //    {
        //        len += Convert.ToInt32((tmp = tmp.GetNext()) != null);
        //    }

        //    tmp = node;
        //    for (int i = 0; i < len / 2; i++)
        //    {
        //        tmp = tmp.GetNext();
        //    }
        //    return tmp;
        //}

        //public static void SortByN(Node<int> head, int n)
        //{


        //    Node<int> tmp = head;

        //    while (tmp != null)
        //    {
        //        Node<int> tmpSec = tmp.GetNext();
        //        while (tmp.GetValue() != n && tmpSec != null)
        //        {
        //            if (tmp.GetValue() > n)
        //            {
        //                int val = tmpSec.GetValue();
        //                tmpSec.SetValue(tmp.GetValue());
        //                tmp.SetValue(val);
        //            }
        //            tmpSec = tmpSec.GetNext();
        //        }
        //        tmp = tmp.GetNext();
        //    }



        //}




        //public static Node<int> FindLoop(Node<int> head)
        //{
        //    Node<int> slow = head;
        //    Node<int> fast = slow;
        //    while (slow != null && fast != null && fast.GetNext() != null)
        //    {
        //        if (slow == fast)
        //            return slow;
        //        slow = slow.GetNext();
        //        fast = fast.GetNext().GetNext();

        //    }
        //    return null;
        //}

        void PrintList(Node<int> head)
        {
            Node<int> cur = head;

            while(cur != null)
            {
                Console.Write($" {cur} ");
                cur = cur.GetNext();
            }
            Console.WriteLine();
        }

        public void Work()
        {
            GenereateInput();

            
           
            
           
           
        }

        public void GenereateInput()
        {
            int[] rand = new int[20];
            Random r = new Random();
            rand[0] = r.Next(101);
            list1 = new Node<int>(rand[0]);
            list2 = new Node<int>(rand[0]);
            Node<int> tmp = list1;
            Node<int> tmp2 = list2;
            
            for (int i = 1; i < rand.Length; i++)
            {
                rand[i] = r.Next(101);
                tmp.SetNext(new Node<int>(rand[i]));
                tmp = tmp.GetNext();

                
            }
            
            
            for (int i = 1; i < rand.Length; i++)
            {
                rand[i] = r.Next(101);
                tmp2.SetNext(new Node<int>(rand[i]));
                tmp2= tmp2.GetNext();

                
            }
        }
    } 
}

