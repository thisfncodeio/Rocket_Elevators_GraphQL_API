using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Columns
    {
        public Columns(HashSet<Elevators> Elevators)
        {
            Elevators = new HashSet<Elevators>();
        }

        public long Id { get; set; }
        public string building_type { get; set; }
        public int? number_of_floors_served { get; set; }
        public string status { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public long? battery_id { get; set; }

        public virtual Batteries Battery { get; set; }
        public virtual ICollection<Elevators> Elevator { get; set; }
    }
}

