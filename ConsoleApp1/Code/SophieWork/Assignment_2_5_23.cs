using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ConsoleApp1.Code.SophieWork
{
    internal class Assignment_2_5_23 : IClassMethods
    {
        int[] testCase = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static int BinarySearch(int[] arr, int k)
        {
            return BinarySearch(arr, k, 0, arr.Length - 1);
        }
        static int BinarySearch(int[] arr, int k, int start, int end)
        {
            if (start > end)
                return -1;

            int mid = start + (end - start) / 2;
            if (k < arr[mid])
                return BinarySearch(arr, k, start, mid - 1);
            else if (k > arr[mid])
                return BinarySearch(arr, k, mid + 1, end);
            else
                return arr[mid];

        }

        public static void TowersOfHanoi(Stack<int> firstPole,
            Stack<int> secondPole, Stack<int> thirdPole)
        {

        }

        public static void ReverseStack(Stack<int> stack)
        {
            if (stack.IsEmpty())
                return;


            int x = stack.Pop();
            ReverseStack(stack);
            ReverseStackUtil(stack, x);





        }

        public static void ReverseStackUtil(Stack<int> stack, int x)
        {
            if (stack.IsEmpty())
            {
                stack.Push(x);
                return;
            }
            int top = stack.Pop();
            ReverseStackUtil(stack, x);
            stack.Push(top);
        }

        // 500
        // 32
        // 120
        public static void SortStackRecursive(Stack<int> stack)
        {
            if (stack.IsEmpty())
                return;

            int item = stack.Pop();
            SortStackRecursive(stack);
            // 120
            // 32
            // 500
            SortStackRecursiveUtil(stack, item);


        }
        public static void SortStackRecursiveUtil(Stack<int> stack, int item)
        {
            if (stack.IsEmpty() || stack.Top() > item)
            {
                stack.Push(item);
                return;
            }
            int x = stack.Pop();
            SortStackRecursiveUtil(stack, item);
            stack.Push(x);
        }



        public Stack<int> SortStackIterative(Stack<int> stack)
        {
            Stack<int> stackTmp = new Stack<int>();
            Stack<int> outStack = new Stack<int>();
            int max = 0;


            while (true)
            {
                if (!stack.IsEmpty())
                {
                    max = stack.Pop();
                    while (!stack.IsEmpty())
                    {
                        int num = stack.Pop();
                        if (num > max)
                        {
                            stackTmp.Push(max);
                            max = num;
                        }
                        else
                            stackTmp.Push(num);
                    }
                    outStack.Push(max);

                }
                if (!stackTmp.IsEmpty())
                {
                    max = stackTmp.Pop();
                    while (!stackTmp.IsEmpty())
                    {
                        int num = stackTmp.Pop();
                        if (num > max)
                        {
                            stack.Push(max);
                            max = num;
                        }
                        else
                            stack.Push(num);
                    }
                    outStack.Push(max);
                }

                if (stack.IsEmpty() && stackTmp.IsEmpty())
                    break;
            }

            return outStack;


        }

        public static int DigitsSum(int num)
        {
            if (num == 0)
                return 0;

            return num % 10 + DigitsSum(num / 10);
        }
        public static int DigitsCount(int num)
        {
            if (num == 0)
                return 0;

            return 1 + DigitsCount(num / 10);
        }
        public static int GCDIterative(int num1, int num2, int x)
        {
            int max = 0;
            int i = 1;
            for (; i < num1 && i < num2; i++)
            {
                if (num1 % i == 0 && num2 % i == 0)
                    max = i;
            }
            return max;

        }
        public static int GCDRecursive(int num1, int num2, int index, int max)
        {
            if (index >= num1 || index >= num2)
                return max;

            if (num1 % index == 0 && num2 % index == 0)
                return GCDRecursive(num1, num2, index + 1, index);
            else
                return GCDRecursive(num1, num2, index + 1, max);


        }
        public static int LargestDigit(int num)
        {
            if (num / 10 == 0)
                return num % 10;

            int max = LargestDigit(num / 10);
            if (num % 10 > max)
                return num % 10;
            else
                return max;
        }
        public static bool IsPalindrome(string str)
        {

            return Reverse(str) == str; ;
        }
        static string Reverse(string str)
        {
            if (str.Length == 1)
                return str;

            return Reverse(str.Substring(1, str.Length - 1)) + str[0];
        }
        
        public static bool IsLegalParenthesisIterative(string str)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(c);
                else
                {
                    if (c == ')' && stack.Top() != '('
                        || c == '}' && stack.Top() != '{'
                        || c == ']' && stack.Top() != '[')
                    
                        
                        return false;

                   

                    stack.Pop();
                }
            }
            return stack.IsEmpty();
        }
        public void GenereateInput()
        {
            
        }

        public void Work()
        {
            Stack<int> firstPole = new Stack<int>();
            Stack<int> secondPole = new Stack<int>();
            Stack<int> thirdPole = new Stack<int>();
            firstPole.Push(120);
            firstPole.Push(32);
            firstPole.Push(500);
            //Console.WriteLine(firstPole);
            //firstPole = SortStackIterative(firstPole);
            //SortStackRecursive(firstPole);
            //Console.WriteLine(firstPole);
            //ReverseStack(firstPole);
            //Console.WriteLine(firstPole);
            //Console.WriteLine(DigitsSum(111));
            //Console.WriteLine(DigitsCount(12345));
            //Console.WriteLine( IsPalindrome("abcba"));
            //Console.WriteLine(GCDRecursive(36,30,1,0));
            //Console.WriteLine(GCDIterative(36,30,0));
            //Console.WriteLine(LargestDigit(5392));
            //Console.WriteLine(IsLegalParenthesis("({(()[])})"));
        }
    }
}
