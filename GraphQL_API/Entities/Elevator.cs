using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Elevator
    {
        public long Id { get; set; }
        public string serial_number { get; set; }
        public string model { get; set; }
        public string building_type { get; set; }
        public string status { get; set; }
        public DateTime? date_of_commissioning { get; set; }
        public DateTime? date_of_last_inspection { get; set; }
        public string certificate_of_inspection { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public long? column_id { get; set; }

        public virtual Column Column { get; set; }
    }
}
