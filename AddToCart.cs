using System;
using System.Collections.Generic;

#nullable disable

namespace BookWebAPI.Models
{
    public partial class AddToCart
    {
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
