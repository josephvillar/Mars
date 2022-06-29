using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsLogic ml = new MarsLogic(10, 22);

            ml.SetRoute(MarsLogic.Direction.East, 2);
            ml.SetRoute(MarsLogic.Direction.North, 1);

            Console.WriteLine("Explored: {0}", ml.Explored);
            Console.ReadLine();
        }
    }
}
