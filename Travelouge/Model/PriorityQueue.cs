using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Travelouge.Model
{

    public class PriorityQueue<T>
    {
        private List<T> heap;
        Func<T, int> selector;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public PriorityQueue(Func<T, int> selector)
        {
            heap = new List<T>();
            this.selector = selector;
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            SiftUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Priority queue is empty");
            }

            T item = heap[0];
            int lastIdx = heap.Count - 1;
            heap[0] = heap[lastIdx];
            heap.RemoveAt(lastIdx);
            SiftDown(0);

            return item;
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        private void SiftUp(int index)
        {
            while (index > 0)
            {
                int parentIdx = (index - 1) / 2;
                if (selector(heap[index]) > selector(heap[parentIdx]))
                {
                    Swap(index, parentIdx);
                    index = parentIdx;
                }
                else
                {
                    break;
                }
            }
        }

        private void SiftDown(int index)
        {
            int size = heap.Count;
            while (index < size)
            {
                int leftChildIdx = 2 * index + 1;
                int rightChildIdx = 2 * index + 2;

                int largest = index;
                if (leftChildIdx < size && selector(heap[leftChildIdx]) > selector(heap[largest]))
                {
                    largest = leftChildIdx;
                }
                if (rightChildIdx < size && selector(heap[rightChildIdx]) > selector(heap[largest]))
                {
                    largest = rightChildIdx;
                }

                if (largest != index)
                {
                    Swap(index, largest);
                    index = largest;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }

}

