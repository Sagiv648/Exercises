using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.BinaryTrees
{
    class _2012_Summer_A_2 : IClassMethods
    {
        BinNode<Stack<int>> root;
        public void GenereateInput()
        {
            Stack<int> x = new Stack<int>();
            x.Push(7);
            x.Push(9);
            x.Push(4);
            x.Push(8);

            Stack<int> y = new Stack<int>();
            y.Push(2);
            y.Push(1);
            y.Push(8);
            y.Push(1);
            Stack<int> z = new Stack<int>();
            z.Push(1);
            z.Push(3);
            Stack<int> empty = new Stack<int>();
            Stack<int> last = new Stack<int>();
            last.Push(1);
            last.Push(4);
            last.Push(9);
            last.Push(2);

            root = new BinNode<Stack<int>>(x);
            root.SetRight(new BinNode<Stack<int>>(y));
            root.GetRight().SetRight(new BinNode<Stack<int>>(empty));
            root.GetRight().SetLeft(new BinNode<Stack<int>>(z));
            root.GetRight().GetRight().SetLeft(new BinNode<Stack<int>>(last));
        }

        public static Stack<int> MorrisTraversalInorderStacksSum(BinNode<Stack<int>> root)
        {
            Stack<int> output = new Stack<int>();

            BinNode<Stack<int>> curr = root;

            while(curr != null)
            {
                int c = 0;
                int sum = 0;
                if(curr.GetLeft() == null)
                {
                    
                    
                    
                    Stack<int> val = curr.GetValue();
                    while (!val.IsEmpty())
                    {
                        if (c == 3)
                            break;
                        sum += val.Pop();
                        c++;

                    }
                    output.Push(sum);
                    

                    //Console.WriteLine(curr);
                    curr = curr.GetRight();
                }
                else
                {
                    BinNode<Stack<int>> predecessor = curr.GetLeft();
                    while (predecessor.GetRight() != curr && predecessor.GetRight() != null)
                        predecessor = predecessor.GetRight();

                    if(predecessor.GetRight() == null)
                    {
                        predecessor.SetRight(curr);
                        curr = curr.GetLeft();
                    }
                    else
                    {
                        predecessor.SetRight(null);

                        Stack<int> val = curr.GetValue();
                        while (!val.IsEmpty())
                        {
                            if (c == 3)
                                break;
                            sum += val.Pop();
                            c++;

                        }
                        output.Push(sum);

                        //Console.WriteLine(curr);
                        curr = curr.GetRight();
                    }
                }
            }

            return output;
        }

        public void Work()
        {
            GenereateInput();
            Console.WriteLine(   MorrisTraversalInorderStacksSum(root));
        }
    }
}
