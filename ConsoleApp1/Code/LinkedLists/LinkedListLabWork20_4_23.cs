

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

        
        public static Node<int> Mergesort(Node<int> head)
        {
            if (head == null || head.GetNext() == null)
                return head;

            Node<int> mid = Middle(head);
            Node<int> tmp = mid.GetNext();

            mid.SetNext(null);
            mid = tmp;

            Node<int> left = Mergesort(head);
            Node<int> right = Mergesort(mid);

            return Merge(left, right);


            
        }

        
        public static Node<int> Merge(Node<int> head1, Node<int> head2)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> tail = dummy;

            while (head1 != null && head2 != null)
            {
                if (head1.GetValue() < head2.GetValue())
                {
                    tail.SetNext(head1);
                    head1 = head1.GetNext();
                }
                else
                {
                    tail.SetNext(head2);
                    head2 = head2.GetNext();
                }
                tail = tail.GetNext();
            }
            if (head1 != null)
                tail.SetNext(head1);
            else if (head2 != null)
                tail.SetNext(head2);

            return dummy.GetNext();
        }

        
        public static Node<int> KthElementFromEnd(Node<int> head, int k)
        {
            Node<int> ahead = head;

            while(ahead != null && k > 0)
            {
                ahead = ahead.GetNext();
                k--;
            }
            Node<int> cur = head;
            while(ahead != null)
            {
                cur = cur.GetNext();
                ahead = ahead.GetNext();
            }
            return cur;

            
        }

        
        public static Node<int> Middle(Node<int> head)
        {
            Node<int> slow = head;
            Node<int> fast = head.GetNext();

            while(fast != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
            }
            return slow;
        }

        
        public static Node<int> PartitionByK(Node<int> head, int k)
        {
            Node<int> dummyRight = new Node<int>(0);
            Node<int> dummyMiddle = new Node<int>(0);
            Node<int> dummyLeft = new Node<int>(0);

            Node<int> leftTail = dummyLeft;
            Node<int> middleTail = dummyMiddle;
            Node<int> rightTail = dummyRight;


            while (head != null)
            {
                Node<int> current = head;
                head = head.GetNext();
                if (current.GetValue() < k)
                {
                    leftTail.SetNext(current);
                    leftTail = leftTail.GetNext();
                    leftTail.SetNext(null);
                }
                else if (current.GetValue() == k)
                {
                    middleTail.SetNext(current);
                    middleTail = middleTail.GetNext();
                    middleTail.SetNext(null);
                }
                else
                {
                    rightTail.SetNext(current);
                    rightTail = rightTail.GetNext();
                    rightTail.SetNext(null);
                }
            }

            middleTail.SetNext(dummyRight.GetNext());

            leftTail.SetNext(dummyMiddle.GetNext());

            return dummyLeft.GetNext();
        }

        
        public static Node<int> FindLoopNode(Node<int> head)
        {
            Node<int> slow = head;
            Node<int> fast = head.GetNext();

            while(fast != null && fast.GetNext() != null)
            {
                if (slow == fast)
                    break;

                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
            }
            if (fast == null || fast.GetNext() == null)
                return null;

            Node<int> tmp = head;
            while(tmp != slow)
            {
                tmp = tmp.GetNext();
                slow = slow.GetNext();
            }
            return tmp;
            
        }
        

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
        //Implemented from IClassMethod
        public void Work()
        {
            GenereateInput();


            PrintList(list1);

            list1 = Mergesort(list1);

            PrintList(list1);
            
           
           
        }

        //Implemented from IClassMethod
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

