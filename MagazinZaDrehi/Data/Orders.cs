using System;
using System.Collections.Generic;

namespace MagazinZaDrehi.Data
{
    public class Orders
    {
        public int Id { get; set; }
        public string ClienId   { get; set; }
        public string ArticulId     { get; set; }
        public ICollection<Articuls> Articuls { get; set; }
        public string Quantity  { get; set; }
        public DateTime OrderOn { get; set; }     
        public User User { get; set; }
       
    }
}
