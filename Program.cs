using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Text : ");
            char[] text = Console.ReadLine().ToCharArray();

            Console.WriteLine("Enter Keyword : ");
            char[] keyword = Console.ReadLine().ToCharArray();

            Logic.findKeywords(keyword, text);
           
            Console.ReadLine();

        }
    }
}
