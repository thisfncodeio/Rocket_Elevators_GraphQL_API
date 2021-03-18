using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Quote
    {
        public long Id { get; set; }
        public string company_name { get; set; }
        public string building_type { get; set; }
        public int? num_of_apartments { get; set; }
        public int? num_of_floors { get; set; }
        public int? num_of_basements { get; set; }
        public int? num_of_parking_spots { get; set; }
        public int? num_of_elevator_cages { get; set; }
        public int? num_of_distinct_businesses { get; set; }
        public int? num_of_occupants_per_Floor { get; set; }
        public int? num_of_activity_hours_per_day { get; set; }
        public int? required_shafts { get; set; }
        public int? total { get; set; }
        public string email { get; set; }
        public DateTime? created_at { get; set; }
    }
}
