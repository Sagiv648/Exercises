using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Code
{
    class Summer_2022_A_Sohpie_Solutions : IClassMethods
    {
        

        public void GenereateInput()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            Queue<int> t = new Queue<int>();
            

        }
    }

    public class Question_2
    {
        public static Queue<int> Filter(Queue<int> q1)
        {
            Queue<int> tmp = new Queue<int>();
            Queue<int> res = new Queue<int>();

            while (!q1.IsEmpty())
            {
                int x = q1.Remove();
                int count = 1;
                while (!q1.IsEmpty())
                {
                    int y = q1.Remove();
                    if (y == x) count++;
                    else tmp.Insert(y);
                }
                if (count > 2)
                    res.Insert(x);
                q1 = tmp;
                tmp = new Queue<int>();
            }
            return res;
        }
        public static Queue<int> Filter2(Queue<int> q1)
        {
            Queue<int> res = new Queue<int>();
            int size = 0;
            int j;
            while (!q1.IsEmpty())
            {
                res.Insert(q1.Remove());
                size++;
            }
            for (; size > 0;)
            {
                int x = res.Remove();
                int count = 1;
                size--;
                j = size;
                for (int i = 0; i < j; i++)
                {
                    if (res.Head() == x)
                    {
                        res.Remove();
                        count++;
                        size--;
                    }
                    else
                    {
                        res.Insert(x);
                    }
                }
                if (count > 2)
                    q1.Insert(x);
            }
            return q1;

        }
    }
}
