using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactElevator
    {
        public long Id { get; set; }
        public string serial_number { get; set; }
        public DateTime? commission_date { get; set; }
        public string building_id { get; set; }
        public string customer_id { get; set; }
        public string building_city { get; set; }
    }
}
