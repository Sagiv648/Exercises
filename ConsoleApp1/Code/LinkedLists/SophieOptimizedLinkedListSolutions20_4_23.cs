using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;
namespace ConsoleApp1.Code.LinkedLists
{
    public class SophieOptimizedLinkedListSolutions20_4_23 : IClassMethods
    {
        Node<int> head;
        public void GenereateInput()
        {
            
        }
        public static Node<int> FindMiddle(Node<int> head)
        {
            Node<int> tmp = head;
            while(head != null && head.HasNext())
            {
                head = head.GetNext().GetNext();
                tmp = tmp.GetNext();
            }
            return tmp;
        }
        public static Node<int> Partition(Node<int> head,int n)
        {
            Node<int> h=null, t=null, m=null, r=null;
            Node<int> tmp;
            while(head != null)
            {
                tmp = head;
                head = head.GetNext();
                if(tmp.GetValue() < n)
                {
                    tmp.SetNext(h);
                    h = tmp;
                    if (t == null)
                        t = h;
                }
                else if(tmp.GetValue() == n)
                {
                    m = tmp;
                    tmp.SetNext(null);
                }
                else
                {
                    tmp.SetNext(r);
                    r = tmp;
                }
                

                
            }
            t.SetNext(m);
            m.SetNext(r);
            return h;
        }
        public static Node<int> FindN(Node<int> head,int n)
        {
            Node<int> tmp = head;
            for(int i = 0; i < n; i++)
            {
                if (head == null)
                    return null;
                head = head.GetNext();
            }
            while(head != null)
            {
                head = head.GetNext();
                tmp = tmp.GetNext();
            }
            return tmp;
        }
        public void Work()
        {
            head = new Node<int>(4);
            head.SetNext(new Node<int>(8));
            head.GetNext().SetNext(new Node<int>(3));
            Node<int> x = Partition(head, 7);
            while(x != null)
            {
                Console.WriteLine(x);
                x = x.GetNext();
            }
            
        }
    }
}
