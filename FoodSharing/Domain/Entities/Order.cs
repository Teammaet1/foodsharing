using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Second"), Column(Order = 0)]
        public int SecondId { get; set; }
        public string Status { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public Shop shop { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
