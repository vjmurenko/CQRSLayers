using System.Collections.Generic;

namespace Entities
{
    public class Order : Entity
    {
        public string Email { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}