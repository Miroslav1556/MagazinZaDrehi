using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MagazinZaDrehi.Data
{
    public class User:IdentityUser
    {
        public string  Name { get; set; }
        public string Familily { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
