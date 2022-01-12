using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAALab4
{
    public class BinomialHeapNode
    {
        public int key, degree;
        public BinomialHeapNode parent;
        public BinomialHeapNode sibling;
        public BinomialHeapNode child;

        public BinomialHeapNode(int key)
        {
            this.key = key;
            degree = 0;
            parent = null;
            sibling = null;
            child = null;
        }

        public BinomialHeapNode FindANodeWithKey(int value)
        {
            BinomialHeapNode temp = this, node = null;

            while (temp != null)
            {
                if (temp.key == value)
                {
                    node = temp;
                    break;
                }
                if (temp.child == null)
                    temp = temp.sibling;
                else
                {
                    node = temp.child.FindANodeWithKey(value);
                    if (node == null)
                        temp = temp.sibling;
                    else
                        break;
                }
            }

            return node;
        }

        public BinomialHeapNode FindMinNode()
        {
            BinomialHeapNode x = this, y = this;
            int min = x.key;

            while (x != null)
            {
                if (x.key < min)
                {
                    y = x;
                    min = x.key;
                }
                x = x.sibling;
            }

            return y;
        }

        public BinomialHeapNode Reverse (BinomialHeapNode sibl)
        {
                BinomialHeapNode ret;
                if (sibling != null)
                    ret = sibling.Reverse(this);
                else
                    ret = this;
                sibling = sibl;
                return ret;
        }
            
            
        
    }

    public class BinomialHeap
    {
        private BinomialHeapNode nodes;
        private int size;

        public int Size { get => size; set => size = value; }
        public BinomialHeapNode Nodes { get => nodes; set => nodes = value; }

        public BinomialHeap()
        {
            Nodes = null;
            Size = 0;
        }
        
        public bool IsEmpty()
        {
            return Nodes == null;
        }

        public void MakeEmpty()
        {
            Nodes = null;
            size = 0;
        }

        private void MergeHeapNodes(BinomialHeapNode binHeapNode)
        {
            BinomialHeapNode temp1 = Nodes;
            BinomialHeapNode temp2 = binHeapNode;

            while ((temp1 != null) && (temp2 != null))
            {
                if (temp1.degree == temp2.degree)
                {
                    BinomialHeapNode tmp = temp2;
                    temp2 = temp2.sibling;
                    tmp.sibling = temp1.sibling;
                    temp1.sibling = tmp;
                    temp1 = tmp.sibling;
                }

                else
                {
                    if (temp1.degree < temp2.degree)
                    {
                        if ((temp1.sibling == null) || (temp1.sibling.degree > temp2.degree))
                        {
                            BinomialHeapNode tmp = temp2;
                            temp2 = temp2.sibling;
                            tmp.sibling = temp1.sibling;
                            temp1.sibling = tmp;
                            temp1 = tmp.sibling;
                        }
                        else
                        {
                            temp1 = temp1.sibling;
                        }
                    }
                    else
                    {
                        BinomialHeapNode tmp = temp1;
                        temp1 = temp2;
                        temp2 = temp2.sibling;
                        temp1.sibling = tmp;
                        if (tmp == Nodes)
                        {
                            Nodes = temp1;
                        }
                        else
                        {

                        }
                    }
                }
            }
            if (temp1 == null)
            {
                temp1 = Nodes;
                while (temp1.sibling != null)
                {
                    temp1 = temp1.sibling;
                }
                temp1.sibling = temp2;
            }
            else
            {

            }
       
        }

        private void UnionNodes(BinomialHeapNode binHeap)
        {
            MergeHeapNodes(binHeap);

            BinomialHeapNode prevTemp = null, temp = Nodes, nextTemp = Nodes.sibling;

            while (nextTemp != null)
            {
                if ((temp.degree != nextTemp.degree) || ((nextTemp.sibling != null) && (nextTemp.sibling.degree == temp.degree)))
                {
                    prevTemp = temp;
                    temp = nextTemp;
                }
                else
                {
                    if (temp.key <= nextTemp.key)
                    {
                        temp.sibling = nextTemp.sibling;
                        nextTemp.parent = temp;
                        nextTemp.sibling = temp.child;
                        temp.child = nextTemp;
                        temp.degree++;
                    }
                    else
                    {
                        if (prevTemp == null)
                        {
                            Nodes = nextTemp;
                        }
                        else
                        {
                            prevTemp.sibling = nextTemp;
                        }
                        temp.parent = nextTemp;
                        temp.sibling = nextTemp.child;
                        nextTemp.child = temp;
                        nextTemp.degree++;
                        temp = nextTemp;
                    }
                }
                nextTemp = temp.sibling;
            }
        }

        public void Insert(int value)
        {
            if (value > 0)
            {
                BinomialHeapNode temp = new BinomialHeapNode(value);
                if (Nodes == null)
                {
                    Nodes = temp;
                    size++;
                }
                else
                {
                    UnionNodes(temp);
                    size++;
                }
            }
        }

        public int FindMinimum()
        {
            return Nodes.FindMinNode().key;
        }

        public void DecreaseKey(int old_value, int new_value)
        {
            try
            {
                BinomialHeapNode temp = Nodes.FindANodeWithKey(old_value);


                temp.key = new_value;
                BinomialHeapNode tempParent = temp.parent;

                while ((tempParent != null) && (temp.key < tempParent.key))
                {
                    int z = temp.key;
                    temp.key = tempParent.key;
                    tempParent.key = z;

                    temp = tempParent;
                    tempParent = tempParent.parent;
                }
            }
            catch
            {
                    return;
            }
        }

        public int ExtractMin()
        {
            if (Nodes == null)
                return -1;

            BinomialHeapNode temp = Nodes, prevTemp = null;
            BinomialHeapNode minNode = Nodes.FindMinNode();

            while (temp.key != minNode.key)
            {
                prevTemp = temp;
                temp = temp.sibling;
            }

            if (prevTemp == null)
            {
                Nodes = temp.sibling;
            }
            else
            {
                prevTemp.sibling = temp.sibling;
            }

            temp = temp.child;
            BinomialHeapNode fakeNode = temp;

            while (temp != null)
            {
                temp.parent = null;
                temp = temp.sibling;
            }

            if ((Nodes == null) && (fakeNode == null))
            {
                size = 0;
            }
            else
            {
                if ((Nodes == null) && (fakeNode != null))
                {
                    Nodes = fakeNode.Reverse(null);
                    size = Size;
                }
                else
                {
                    if ((Nodes != null) && (fakeNode == null))
                    {
                        size = Size;
                    }
                    else
                    {
                        UnionNodes(fakeNode.Reverse(null));
                        size = Size;
                    }
                }
            }

            return minNode.key;
        }

        public void DeleteNode(int value)
        {
            if ((Nodes != null) && (Nodes.FindANodeWithKey(value) != null))
            {
                DecreaseKey(value, FindMinimum() - 1);
                ExtractMin();
            }
        }

        private void DisplayHeap(BinomialHeapNode r)
        {
            if (r != null)
            {
                DisplayHeap(r.child);
                Console.Write(r.key + " ");
                DisplayHeap(r.sibling);
            }
        }


    }
}
