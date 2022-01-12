using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAALab4
{
    public class Algorithms
    {
        //Helpers class, for testing the algorithms

      //Testirati ponasanje struktura za slucajno generisane vrednosti od od 10, 100, 1k, 10K i 100K elemenata 
      //opseg elemenata 0 - 10K

        //Zatim testirati ponasanje algoritama za prethodno navedene brojeve elemenanta

        //Ponasanje algoritama:
        //Za radnom 10 % elemenata uraditi:
        //Extract node
        //Decrease key
        //Delete node
        // Za novih 10% elemenata Add()

        //Test
        public int[] RandArrGenerator(int size)
        {
            Random rnd = new Random();
            int[] retArr = new int[size];

            for (int i = 0; i < size; i++)
            {
                retArr[i] = rnd.Next(0, 10000);
            }

            return retArr;
        }

        public void TestBinary(int size)
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            BinaryHeap binHeap = new BinaryHeap(size);

            int[] rndArr = RandArrGenerator(size);

            Console.WriteLine("Binary Heap of size: " + size);

            sw.Start();
            for (int i=0; i < size/10; i++)
            {
                binHeap.InsertNode(rndArr[i]);
            }

            sw.Stop();

            for (int i = size / 10; i < size; i++)
            {
                binHeap.InsertNode(rndArr[i]);
            }
            Console.WriteLine("The insertion of 10% of the elements: " + sw.Elapsed + " MS");

            sw.Restart();

            for (int i = size / 10; i < size; i++)
            {
                binHeap.ExtractMinimum();
            }
            sw.Stop();

            Console.WriteLine("Extract minimum, 10% of Nodes: " + sw.Elapsed + " MS");

            sw.Restart();
            for (int i = size / 10; i < size; i++)
            {
                int rnd1 = rnd.Next(0, 10000);
                int rnd2 = rnd.Next(0, 10000);
                if (rnd1 < rnd2)
                    binHeap.DecreaseKey(rnd2, rnd1);
                else
                    binHeap.DecreaseKey(rnd1, rnd2);

            }
            sw.Stop();

            Console.WriteLine("Decrease key, 10% of Nodes: " + sw.Elapsed + " MS");

            sw.Restart();
            for (int i = size / 10; i < size; i++)
            {
                binHeap.DeleteNode(rnd.Next(0, 10000));
            }
            sw.Stop();

            Console.WriteLine("Delete node, 10% of Nodes: " + sw.Elapsed + " MS");

        }

        public void TestBinomial(int size)
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            BinomialHeap binomial = new BinomialHeap();

            int[] rndArr = RandArrGenerator(size);

            Console.WriteLine("Binomial Heap of size: " + size);

            sw.Start();
            for (int i = 0; i < size / 10; i++)
            {
                //binHeap.InsertNode(rndArr[i]);
                binomial.Insert(rndArr[i]);
            }

            sw.Stop();

            for (int i = size / 10; i < size; i++)
            {
                //binHeap.InsertNode(rndArr[i]);
                binomial.Insert(rndArr[i]);
            }
            Console.WriteLine("The insertion of 10% of the elements: " + sw.Elapsed + " MS");

            sw.Restart();

            for (int i = size / 10; i < size; i++)
            {
                //binHeap.ExtractMinimum();
                binomial.ExtractMin();
            }
            sw.Stop();

            Console.WriteLine("Extract minimum, 10% of Nodes: " + sw.Elapsed + " MS");

            sw.Restart();
            for (int i = size / 10; i < size; i++)
            {

                int rnd1 = rnd.Next(0, 10000);
                int rnd2 = rnd.Next(0, 10000);
                if (rnd1 < rnd2)
                    binomial.DecreaseKey(rnd2, rnd1);
                else
                    binomial.DecreaseKey(rnd1, rnd2);
            }
            sw.Stop();

            Console.WriteLine("Decrease key, 10% of Nodes: " + sw.Elapsed + " MS");

            sw.Restart();
            for (int i = size / 10; i < size; i++)
            {
                //binHeap.DeleteNode(rnd.Next(0, 10000));
                binomial.DeleteNode(rnd.Next(0, 10000));
            }
            sw.Stop();

            Console.WriteLine("Delete node, 10% of Nodes: " + sw.Elapsed + " MS");

        }


    }
}
