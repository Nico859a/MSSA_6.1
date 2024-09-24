using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDemo
{
    class Node
    {
        public int HouseNumber;
        public string Address; // these have to be passed in public Node below
        public Node next;// pointer: memory address of next node

        public Node(int houseNum, string address, Node next)
        {
            this.HouseNumber = houseNum;
            this.Address = address;
            this.next = next;
        }
    }

    class LList
    {

        private Node head;
        private Node tail;
        private int size; //counter to keep track if number of nodes
        public int Length
        {
            get { return this.size; }
        }
        public LList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }
        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public void AddFirst(int houseNum, string address)
        {
            Node newest = new Node(houseNum, address, null);

            if (IsEmpty())
            {
                this.head = newest;
                this.tail = newest;
            }
            else
            {
                newest.next = this.head;
                this.head = newest;
            }
            size++;
        }

        public void AddLast(int houseNum, string address)
        {
            Node newest = new Node(houseNum, address, null);

            if (IsEmpty())
            {
                this.head = newest;

            }
            else
            {
                this.tail.next = newest; // current last node will point to the newest

            }
            this.tail = newest; // adding node at last should update the tail
            size++;
        }

        public void Display()
        {
            Node temp = this.head;

            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                while (temp != null)
                {
                    if (temp.next != null)
                    {
                        Console.Write(temp.HouseNumber + temp.Address + " -----> ");

                    }
                    else
                    {
                        Console.Write(temp.HouseNumber + temp.Address);
                    }
                    temp = temp.next;
                }
            }
            Console.WriteLine("");
        }

        public int RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return -1;
            }
            else
            {
                int data = head.HouseNumber; //return the removed element
                head = head.next;
                size--;

                if (IsEmpty()) //if there was only 1 node in the list
                {
                    tail = null;
                }
                return data;
            }
        }

        public int RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return -1;
            }

            if (this.head == this.tail) //only 1 node
            {
                int val = head.HouseNumber;
                this.head = null;
                this.tail = null;
                size--;
                return val;
            }

            Node temp = this.head;
            int i = 1;

            while (i < size - 1) //go till second last node
            {
                temp = temp.next;
                i++;
            }
            tail = temp; //update the tail

            //to return data
            temp = temp.next; //go to last node
            int data = temp.HouseNumber;
            tail.next = null;
            size--;
            return data;
        }

        public string Search(int houseNum, out string address, out int index)
        {
            Node temp = this.head;
            int i = 1;
            address = null;

            while (temp != null)
            {
                if (temp.HouseNumber == houseNum)
                {
                    address = temp.Address;
                    index = i;
                    return $"House Number: {houseNum}, Address: {address}, Index: {index}";
                }
                temp = temp.next;
                i++;
            }
            index = 0; //we have not found the element
            return "House not found";
        }

        public void AddAnywhere(int houseNum, string address, int position)
        {
            if (position <= 0 || position > size + 1)
            {
                Console.WriteLine("Invalid position");
                return;
            }
            if (position == 1)
            {
                AddFirst(houseNum, address);
                return;
            }
            if (position == size + 1)
            {
                AddLast(houseNum, address);
                return;
            }

            Node newest = new Node(houseNum, address, null);
            int i = 1;
            Node temp = this.head;

            while (i < position - 1) //go to position that is 1 less than required
            {
                temp = temp.next;
                i++;
            }
            //update the next pointers
            newest.next = temp.next;
            temp.next = newest;
            size++;
        }

        public int RemoveAnywhere(int data, int houseNum, string address, int position)
        {
            if (position <= 0 || position > size)
            {
                Console.WriteLine("Invalid position");
                return -1;
            }
            if (position == 1)
            {
                return RemoveFirst();
            }
            if (position == size)
            {
                return RemoveLast();
            }

            Node temp = this.head;
            int i = 1;

            while (i < position - 1)
            {
                temp = temp.next;
                i++;
            }
            int val = temp.next.HouseNumber; //value that is to be removed
            temp.next = temp.next.next; //skipping the node at the position
            return val;
        }
    }
}
