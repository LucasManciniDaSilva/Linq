using System;
using Linq.Entities;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Linq
{
    class Program
    {

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {

            string FullPath = @"/Users/lucasmancini/in.txt";
            Console.WriteLine("Enter the full file path: " + FullPath);

            List<Product> list = new List<Product>();

            using (StreamReader sr = File.OpenText(FullPath))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1]);
                    list.Add(new Product(name, price));
                }

            }


            var avg = list.Select(p => p.Price).Average();
            Console.WriteLine("Average: " + avg);
            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }




        }
    }
}
