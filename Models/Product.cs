using System.ComponentModel.DataAnnotations;

namespace SimpleWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, Range(0.0, 10000000.0)]
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
