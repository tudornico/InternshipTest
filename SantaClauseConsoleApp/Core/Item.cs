using System;
using System.Threading;

namespace SantaClauseConsoleApp
{
    public class Item
    {
        public String name { get; set; }
        public int id;

        public static int globalid;
        

        public Item(string name)
        {
            this.name = name;
            this.id = Interlocked.Increment(ref globalid); // auto incremented ID
        }
    }
}
