using Exercises;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;
namespace ConsoleApp1.Code.Stacks
{
    public class StackSorting : IClassMethods
    {
        Stack<int> stack = new Stack<int>();
        
        public void GenereateInput()
        {
            Random rand = new Random();
            
            for(int i = 0; i < 20; i++)
            {
                stack.Push(rand.Next(101));
            }
            
        }

        public void Sort()
        {
            Stack<int> stackTmp = new Stack<int>();
            Stack<int> outStack = new Stack<int>();
            int max = 0;

            Console.WriteLine(stack);
            while(true)
            {
                if(!stack.IsEmpty())
                {
                    max = stack.Pop();
                    while (!stack.IsEmpty())
                    {
                        int num = stack.Pop();
                        if(num > max)
                        {
                            stackTmp.Push(max);
                            max = num;
                        }
                        else
                            stackTmp.Push(num);
                    }
                    outStack.Push(max);
                    
                }
                if(!stackTmp.IsEmpty())
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

            Console.WriteLine(outStack);

            
        }
        public void Work()
        {
            GenereateInput();
            Sort();
            //Console.WriteLine(stack);

        }
    }
}
