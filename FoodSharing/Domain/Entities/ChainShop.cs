using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Entities
{
    public class ChainShop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Shop> Shops { get; set; } = new List<Shop>();
    }
}
