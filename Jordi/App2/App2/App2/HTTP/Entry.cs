using System;
using System.Collections.Generic;
using System.Text;

namespace App2.HTTP
{
    public class Entry
    {
        public int Id { get; set; }
        public int Ingredients { get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
    }
}
