using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// built in class
            //LinkedList<int> intlist = new LinkedList<int>();
            //intlist.AddFirst(30);

            LList myList = new LList();

            Console.WriteLine("List of availible houses:");
            Console.WriteLine("");
            myList.AddFirst(123, " Wish st.");
            myList.AddFirst(456, " Carl ave");
            myList.AddFirst(789, " Dunkirk ave");
            myList.AddFirst(101, " Verdun ave");
            myList.Display();
            Console.WriteLine("");
            Console.Write("Enter the house number to search for location: ");
            
            int houseNum = int.Parse(Console.ReadLine());
            string address;
            string result = myList.Search(houseNum, out address, out int index);


            if (!string.IsNullOrEmpty(address))
            {
                Console.WriteLine();
                Console.WriteLine($"The house number entered was found to be located on{address}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(result);
            }
        }


    }
}
