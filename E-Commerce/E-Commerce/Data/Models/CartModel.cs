using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Car Cars { get; set; } = null!;
    }
}
