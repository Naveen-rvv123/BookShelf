using System;
using System.Collections.Generic;

#nullable disable

namespace BookWebAPI.Models
{
    public partial class Login
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int? Mobile { get; set; }
        public string Address { get; set; }
    }
}
