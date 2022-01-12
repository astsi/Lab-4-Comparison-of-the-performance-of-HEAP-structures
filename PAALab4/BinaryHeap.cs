using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAALab4
{
    //the implementation of the binary min heap
    public class BinaryHeap
    {
        private int[] arr;
        private int len;
        private int numOfElements;

        private BinaryHeap() { }
        public BinaryHeap(int length)
        {
            arr = new int[length];
            len = length;
            numOfElements = 0;
        }

        public bool InsertNode(int key)
        {
            if (numOfElements == len - 1)
                return false;
            numOfElements++;
            int i = numOfElements;

            while (i > 1 && arr[i / 2] > key)
            {
                arr[i] = arr[i / 2];
                i = i / 2;
            }
            arr[i] = key;
            return true;
        }

        public bool DeleteNode(int key)
        {
            int pos = -1;
            for (int i = 1; i< numOfElements; i++)
            {
                if (arr[i] == key)
                    pos = i;
            }
            if (pos == -1)
                return false;

            int temp = pos;
            temp = temp * 2;
            if (temp > numOfElements)
                temp = temp / 2;

            while (2* temp + 1 < numOfElements)
            {
                temp = 2 * temp + 1;
            }

            arr[pos] = arr[temp];
            arr[temp] = 0;
            numOfElements--;

            while (pos > 1 && arr[pos] < arr[pos/2])
            {
                arr[pos] = arr[pos / 2];
                pos = pos / 2;
            }

            while (2*pos < numOfElements + 1)
            {
                int child = 2 * pos;

                if (child + 1 < numOfElements + 1 && arr[child + 1] < arr[child])
                    child++;

                if (pos <= arr[child])
                    break;

                arr[pos] = arr[child];
                pos = child;
            }

            return true;


        }

        public int ExtractMinimum()
        {
            int min = arr[1];
            int last = arr[numOfElements];
            arr[numOfElements] = 0;
            numOfElements--;

            int i = 1;

            while (2 * i < numOfElements + 1)
            {
                int child = 2 * i;

                if (child + 1 < numOfElements + 1 && arr[child + 1] < arr[child])
                    child++;

                if (last <= arr[child]) break;

                arr[i] = arr[child];
                i = child;
            }

            arr[i] = last;
            return min;
        }

        public bool DecreaseKey(int old, int nov)
        {
            int pos = -1;

            for (int i = 0; i <= numOfElements; i++)
            {
                if (arr[i] == old)
                    pos = i;
            }

            if (pos == -1)
                return false;

            while (pos > 1 && arr[pos/2] > nov)
            {
                arr[pos] = arr[pos / 2];
                pos = pos / 2;
            }

            arr[pos] = nov;
            return true;
        }
    }
}
