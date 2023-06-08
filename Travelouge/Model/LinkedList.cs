using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelouge.Model
{

    /**
     * Standard linked list, with some validation to verify that no 2 elements are the same
     * cuz there can't be 2 locations with the same name
     * 
     *@param <T> the type of the elements in the list
     *             
     */
    public class LinkedList<T>
    {
        private class Node
        {
            public T Data { get; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public int Count => count;

        public void AddFirst(T data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void AddLast(T data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            count++;
        }

        public bool Remove(T data)
        {
            if (head == null)
            {
                return false;
            }

            if (head.Data.Equals(data))
            {
                head = head.Next;
                count--;
                return true;
            }

            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}

