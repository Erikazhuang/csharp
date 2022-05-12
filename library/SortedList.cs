using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
    {
 
        static void Main(string[] args)
        {
           
  
            SortedList<int, string> numberNames = new SortedList<int, string>();
            numberNames.Add(3, "Three");
            numberNames.Add(1, "One");
            numberNames.Add(2, "Two");
            numberNames.Add(4, null);
            numberNames.Add(1, "One");

            SortedList<int, string> numberNames2 = new SortedList<int, string>(); 
            numberNames2.Add(10, "Ten");
            numberNames2.Add(1, "One");
            numberNames2.Add(2, "Two");
            numberNames2.Add(5, "Five");

            foreach(var kvp in numberNames2){
                if (!numberNames.Contains(kvp))
                    numberNames.Add(kvp.Key,kvp.Value);
            }

            foreach(KeyValuePair<int,string> kvp in numberNames)
                System.Console.WriteLine("key: {0}, value: {1}.", kvp.Key,kvp.Value);

        }