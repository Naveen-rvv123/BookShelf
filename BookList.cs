using System;
using System.Collections.Generic;

#nullable disable

namespace BookWebAPI.Models
{
    public partial class BookList
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int? Quantity { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }
    }
}
