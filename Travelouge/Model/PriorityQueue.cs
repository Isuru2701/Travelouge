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
        private IComparer<T> comparer;

        public PriorityQueue()
        {
            heap = new List<T>();
            comparer = Comparer<T>.Default;
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            heap = new List<T>();
            this.comparer = comparer;
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
                if (comparer.Compare(heap[index], heap[parentIdx]) > 0)
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
                if (leftChildIdx < size && comparer.Compare(heap[leftChildIdx], heap[largest]) > 0)
                {
                    largest = leftChildIdx;
                }
                if (rightChildIdx < size && comparer.Compare(heap[rightChildIdx], heap[largest]) > 0)
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

