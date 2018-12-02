using System;

namespace SportStore.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsNew { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        public string GetInfo()
        {
            return $"[{Id}] {Name} - ({Category}): {Price}";
        }
    }
}
