using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Entities
{
    public class CountProduct
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
