﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactIntervention
    {
        [Key]
        public long Id { get; set; }
        public int? employee_id { get; set; }
        public long? building_id { get; set; }
        public int? battery_id { get; set; }




        public int? column_id { get; set; }
        public int? elevator_id { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string result { get; set; }
        public string report { get; set; }
        public string status { get; set; }
    }
}
