using System;
using System.Collections.Generic;

namespace YP2_home
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int IdStatus { get; set; }
        public int IdDish { get; set; }
        public int IdUsers { get; set; }

        public virtual Dish IdDishNavigation { get; set; } = null!;
        public virtual Status IdStatusNavigation { get; set; } = null!;
        public virtual User IdUsersNavigation { get; set; } = null!;
    }
}
