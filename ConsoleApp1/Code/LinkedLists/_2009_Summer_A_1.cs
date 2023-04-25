using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp1.Code.LinkedLists
{
    public class _2009_Summer_A_1 : IClassMethods
    {
        Node<int> node;
        public void GenereateInput()
        {
            
            
            int[] input = new int[] { 2, 5, 3, 12 };
            node = new Node<int>(2);
            Node<int> tmp = node;
            
            for (int i = 0; i < 1; i++)
            {
                int j = 0;
                if (i == 0)
                    j = 1;
                for (; j < input.Length; j++)
                {
                    tmp.SetNext(new Node<int>(input[j]));
                    tmp = tmp.GetNext();

                }
                    
            }
            tmp = node;
            while(tmp != null)
            {
                Console.Write($" {tmp} ");
                tmp = tmp.GetNext();
            }


            
        }
        public bool IsTriangularList(Node<int> node)
        {
            Node<int> tmp = node;
            int c = 0;
            while(tmp != null)
            {
                c++;
                tmp = tmp.GetNext();
            }
            if (c == 0 || c % 3 != 0)
                return false;
            tmp = node;
            Node<int> laterThird = node;
            c /= 3;
            while (laterThird != null && c > 0)
            {
                laterThird = laterThird.GetNext();
                c--;

            }
                
            for(; tmp != null && laterThird != null; tmp = tmp.GetNext(), laterThird = laterThird.GetNext())
            {
                if (tmp.GetValue() != laterThird.GetValue())
                    return false;
            }
            return true;
        }
        public void Work()
        {
            GenereateInput();
            Console.WriteLine();
            Console.WriteLine(IsTriangularList(node));
        }
    }
}
