using System;
using System.Collections.Generic;
using System.Text;

namespace App2.HTTP
{
    public class Page
    {
        public int? Next { get; set; }

        public IEnumerable<Entry> Items { get; set; }
    }
}
