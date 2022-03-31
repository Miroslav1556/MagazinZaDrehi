using System;
using System.Collections.Generic;

namespace MagazinZaDrehi.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId   { get; set; }
        public User User { get; set; }
        public string ArticulId     { get; set; }
        public Articul Articul { get; set; }
        public string Quantity  { get; set; }
        public DateTime OrderOn { get; set; }     

       
    }
}
