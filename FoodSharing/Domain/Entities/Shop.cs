using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Entities
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
