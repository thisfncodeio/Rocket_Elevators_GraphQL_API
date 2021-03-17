using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Column
    {
        public Column()
        {
            Elevators = new HashSet<Elevator>();
        }

        public long Id { get; set; }
        public string building_type { get; set; }
        public int? number_of_floors_served { get; set; }
        public string status { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public long? battery_id { get; set; }

        public virtual Battery Battery { get; set; }
        public virtual ICollection<Elevator> Elevators { get; set; }
    }
}
