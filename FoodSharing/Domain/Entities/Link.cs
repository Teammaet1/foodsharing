using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Domain.Entities
{
    public class Link
    {
        public Guid Id { get; set; }
        public string LinkStr { get; set; }
        public string Type { get; set; }
    }
}
