using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Shared.Events
{
    public class BookCreatedEvent :IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Year { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
