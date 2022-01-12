using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAALab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Algorithms a = new Algorithms();

            a.TestBinary(100);
            a.TestBinomial(100);

            a.TestBinary(1000);
            a.TestBinomial(1000);

            a.TestBinary(10000);
            a.TestBinomial(10000);

            a.TestBinary(100000);
            a.TestBinomial(100000);

        }
    }
}
