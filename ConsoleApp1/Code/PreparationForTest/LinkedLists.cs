using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.PreparationForTest
{
    public class LinkedLists : IClassMethods
    {
        Node<int> head;
        //-------------------------------------------- Linked List --------------------------------------

        //Linked list -> Remove duplicates
        public static void RemoveDuplicates(Node<int> head)
        {
            Node<int> tmp = head;

            while (tmp != null && tmp.GetNext() != null)
            {
                Node<int> tmpSec = tmp;
                while (tmpSec.GetNext() != null)
                {
                    if (tmpSec.GetNext().GetValue() == tmp.GetValue())
                        tmpSec.SetNext(tmpSec.GetNext().GetNext());
                    else
                        tmpSec = tmpSec.GetNext();
                }
                tmp = tmp.GetNext();
            }
        }

        //Linked list -> Rotate by K
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
            for (int i = 0; i < len - k - 1; i++)
                tmp = tmp.GetNext();
            Node<int> newHead = tmp.GetNext();
            tmp.SetNext(null);
            tail.SetNext(head);
            return newHead;

        }

        //Linked list -> Reverse a linked list (Iteratively)
        public static Node<int> IterativeReverse(Node<int> head)
        {
            Node<int> prev = null;
            Node<int> curr = head;

            while (curr != null)
            {
                
                Node<int> tmp = curr.GetNext();
                
                curr.SetNext(prev);
                
                prev = curr;
                
                curr = tmp;
                
            }
            return prev;
        }

        //Linked list -> Reverse a linked list (Recursively)
        public static Node<int> RecursiveReverse(Node<int> head)
        {
            if (head == null)
                return head;

            Node<int> newHead = head;
            if (head.HasNext())
            {
                newHead = RecursiveReverse(head.GetNext());
                head.GetNext().SetNext(head);
            }
            head.SetNext(null);

            return newHead;
        }

        //Linked list -> Reorder list
        public static void ReorderLinkedList(Node<int> head)
        {
            //Find the middle
            Node<int> slow = head;
            Node<int> fast = head.GetNext();
            while(fast != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
            }
            
            //Reverse the second half
            Node<int> secHalf = slow.GetNext();
            slow.SetNext(null);
            Node<int> prev = null;

            while(secHalf != null)
            {
                Node<int> next = secHalf.GetNext();

                secHalf.SetNext(prev);

                prev = secHalf;

                secHalf = next;
            }

            //Merge the two halves
            Node<int> firstHalf = head;
            
            secHalf = prev;
            while(secHalf != null)
            {
                Node<int> tmpFirst = firstHalf.GetNext();
                Node<int> tmpSec = secHalf.GetNext();
                firstHalf.SetNext(secHalf);
                secHalf.SetNext(tmpFirst);
                firstHalf = tmpFirst;
                secHalf = tmpSec;
            }
            
        }

        //Linked list -> Remove a given element from the list
        public static Node<int> RemoveElements(Node<int> head, int val)
        {
            Node<int> dummy = new Node<int>(0, head);
            Node<int> prev = dummy;
            Node<int> curr = head;

            while(curr != null)
            {
                if (curr.GetValue() == val)
                    prev.SetNext(curr.GetNext());
                else
                    prev = curr;
                curr = curr.GetNext();
            }
            return dummy.GetNext();
        }

        //Linked list -> Check if a linked list is a palindrome
        public static bool IsLinkedListPalindrome(Node<int> head)
        {
            //Find the middle
            Node<int> slow = head;
            Node<int> fast = head;
            while(fast != null && fast.GetNext() !=null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();

            }

            Node<int> prev = null;

            while(slow != null)
            {
                Node<int> next = slow.GetNext();
                slow.SetNext(prev);
                prev = slow;
                slow = next;
            }

            while(prev != null)
            {
                if (prev.GetValue() != head.GetValue())
                    return false;
               
                
                head = head.GetNext();
                prev = prev.GetNext();
            }
            
            return true;

        }

        //Linked list -> Merge two sorted linked lists
        public static Node<int> MergeTwoSortedLists(Node<int> head1, Node<int> head2)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> tail = dummy;

            while(head1 != null && head2 != null)
            {
                if(head1.GetValue() < head2.GetValue())
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

        //Linked list -> Merge K sorted linked lists
        public static Node<int> MergeKSortedLists(Node<int>[] lists, int k)
        {
            if (lists.Length == 0)
                return null;

            while(lists.Length > 1)
            {
                List<Node<int>> mergedLists = new List<Node<int>>();
                for(int i =0; i < lists.Length; i+=2)
                {
                    Node<int> l1 = lists[i];
                    Node<int> l2 = null;
                    if (i + 1 < lists.Length)
                        l2 = lists[i + 1];
                    mergedLists.Add(MergeTwoSortedLists(l1, l2));
                }
                lists = mergedLists.ToArray();
            }
            return lists[0];
        }

        //Linked list -> Remove Nth node from the end of the linked list
        public static Node<int> RemoveNthNodeFromEndOfList(Node<int> head, int n)
        {
            Node<int> slow = head;
            Node<int> fast = head;
            while(fast != null && n > 0)
            {
                fast = fast.GetNext();
                n--;
            }
            if (fast == null)
                return head.GetNext();
            while(slow != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext();
            }
            slow.SetNext(slow.GetNext().GetNext());
            return head;
        }

        // Linked list -> Sort a linked list with Merge sort
        public static Node<int> MergeSortLinkedList(Node<int> head)
        {
            if (head == null || head.GetNext() == null)
                return head;

            //Get middle
            Node<int> slow = head, fast = head.GetNext();
            while(fast != null && fast.GetNext() != null)
            {
                fast = fast.GetNext().GetNext();
                slow = slow.GetNext();
            }
            Node<int> startRight = slow.GetNext();
            slow.SetNext(null);

            Node<int> left = MergeSortLinkedList(head);
            Node<int> right = MergeSortLinkedList(startRight);
            return MergeTwoSortedLists(left, right);
            

        }

        //Linked list -> Partition linked list by K
        public static Node<int> PartitionLinkedListByK(Node<int> head, int k)
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

        //Linked list -> Partition linked list by K, smaller than K to left, greater/equal to right
        //Has to keep the original order
        public static Node<int> PartitionByKAndKeepOrder(Node<int> head, int k)
        {
            //Dummy nodes
            Node<int> left = new Node<int>(0);
            Node<int> right = new Node<int>(0);

            Node<int> leftTail = left;
            Node<int> rightTail = right;

            while(head != null)
            {
                if(head.GetValue() < k)
                {
                    leftTail.SetNext(head);
                    leftTail = leftTail.GetNext();
                }
                else
                {
                    rightTail.SetNext(head);
                    rightTail = rightTail.GetNext(); 
                }
                head = head.GetNext();
            }
            leftTail.SetNext(right.GetNext());
            rightTail.SetNext(null);

            return left.GetNext();

        }

        //Linked list -> Return node where cycle starts/end
        public static Node<int> StartAndEndOfCycle(Node<int> head)
        {
            Node<int> slow = head;
            Node<int> fast = head;
            while(fast != null && fast.GetNext() != null)
            {


                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
                if (slow == fast)
                    break;
            }
            
            fast = slow;
            slow = head;
            
            while(slow != fast)
            {
                
                slow = slow.GetNext();
                fast = fast.GetNext();
            }
            return slow;
        }

        //Linked list -> Remove cycle from linked list
        public static Node<int> RemoveCycleFromLinkedList(Node<int> head)
        {
            Node<int> slow = head;
            Node<int> fast = head;

            while(fast != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
                if (slow == fast)
                    break;
            }
            fast = slow;
            slow = head;
            while(slow != fast)
            {
                slow = slow.GetNext();
                fast = fast.GetNext();

            }
            fast = head;
            int timesReached = 0;
            while(fast != null)
            {
                if (timesReached >= 1 && fast.GetNext() == slow)
                    fast.SetNext(null);
                 
                else if (fast == slow)
                    timesReached++;
                
                fast = fast.GetNext();
            }
            return head;
        }

        //Linked list -> Reverse linked list from node numbered left to node numbered right
        public static Node<int> ReverseLinkedListFromLeftToRight(Node<int> head, int left, int right)
        {
            Node<int> dummy = new Node<int>(0, head);

            //1) reach node at position left

            Node<int> leftPrev = dummy, cur = head;
            for(int i = 0; i < left-1; i++)
            {
                leftPrev = cur;
                cur = cur.GetNext();
                
            }

            // Now cur = left, leftPrev = node before left
            //2) reverse from left to right
            Node<int> prev = null;
            for(int i =0; i < right-left+1; i++)
            {
                Node<int> tmpNext = cur.GetNext();
                cur.SetNext(prev);
                prev = cur;
                cur = tmpNext;
            }

            //3) Update pointers
            leftPrev.GetNext().SetNext(cur);
            leftPrev.SetNext(prev);
            return dummy.GetNext();
        }

        //Linked list -> Remove duplicates from sorted list
        public static Node<int> RemoveDuplicatesFromSortedList(Node<int> head) 
        {
            if (head == null)
                return head;

            Node<int> cur = head;

            while (cur.GetNext() != null)
            {
                if (cur.GetNext().GetValue() == cur.GetValue())
                {
                    Node<int> removed = cur.GetNext();
                    cur.SetNext(removed.GetNext());
                    removed.SetNext(null);
                }
                else
                    cur = cur.GetNext();
            }
            return head;
        }

        //Linked list -> Intersection node of two lists
        public static Node<int> IntersectionNodeOfTwoLists(Node<int> head1, Node<int> head2)
        {
            Node<int> tmpOne = head1;
            Node<int> tmpTwo = head2;

            while(tmpOne != tmpTwo)
            {
                if (tmpOne == null)
                    tmpOne = head2;
                if (tmpTwo == null)
                    tmpTwo = head1;

                

                tmpOne = tmpOne.GetNext();
                tmpTwo = tmpTwo.GetNext();
            }
            return tmpOne;
            
        }

        //Linked list -> Insertion sort
        public static Node<int> InsertionSortLinkedList(Node<int> head)
        {
            Node<int> dummy = new Node<int>(0, head);
            Node<int> prev = head;
            Node<int> cur = head.GetNext();

            while(cur != null)
            {
                if (cur.GetValue() >= prev.GetValue())
                {
                    prev = cur;
                    cur = cur.GetNext();
                    continue;
                }

                Node<int> tmp = dummy;

                while (cur.GetValue() > tmp.GetNext().GetValue())
                    tmp = tmp.GetNext();

                prev.SetNext(cur.GetNext());
                cur.SetNext(tmp.GetNext());
                tmp.SetNext(cur);
                cur = prev.GetNext();
            }

            return dummy.GetNext();
        }

        void PrintList()
        {
            Node<int> tmp = head;
            while (tmp != null)
            {
                Console.Write($" {tmp} ");
                tmp = tmp.GetNext();
            }
            Console.WriteLine();
        }

        public void GenereateInput()
        {
            int[] x = { 1000,1,20,232,8,3,4,5, };
            head = new Node<int>(x[0]);
            Node<int> tmp = head;
            for(int i = 1; i < x.Length; i++)
            {
                tmp.SetNext(new Node<int>(x[i]));
                tmp = tmp.GetNext();
            }
            
        }

        public void Work()
        {
            GenereateInput();



            head = PartitionLinkedListByK(head, 2000);

            //head = PartitionByKAndKeepOrder(head, 5);
            
            PrintList();
            
        }
    }
}
