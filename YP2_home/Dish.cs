using System;
using System.Collections.Generic;

namespace YP2_home
{
    public partial class Dish
    {
        public Dish()
        {
            Orders = new HashSet<Order>();
        }

        public int IdDish { get; set; }
        public string NameDish { get; set; } = null!;
        public decimal Price { get; set; }
        public string TimeDish { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
