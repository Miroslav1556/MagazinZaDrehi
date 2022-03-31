using MagazinZaDrehi.Data.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinZaDrehi.Data
{
    public class Articul
    {
        public Articul()
        {
            OrderDate = DateTime.Now; 
        }
        public int Id { get; set; }
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category{ get; set; }
        public string Size { get; set; }
        public string Description { get; set; } 
        public Sex Sex  { get; set; }
        public string Age   { get; set; }
        public string Photo     { get; set; }
       [Column(TypeName="decimal(18,2)")]
        public decimal Price    { get; set; }
        public DateTime OrderDate { get; set; }
       
        public ICollection<Order> Orders { get; set; }


    }
}
