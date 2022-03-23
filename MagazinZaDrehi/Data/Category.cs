using System.Collections.Generic;

namespace MagazinZaDrehi.Data
{
    public class Category
    {
        public int Id { get; set; }    
        public string Categories { get; set; }
        public ICollection<Articuls> Articuls { get; set; }

    }
}
