using System;
using System.Collections.Generic;


#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Batteries
    {
        public Batteries(HashSet<Columns> Columns)
        {
            Columns = new HashSet<Columns>();
        }


        public long Id { get; set; }            
        public string building_type { get; set; }
        public string status { get; set; }
        public DateTime? date_of_commissioning { get; set; }
        public DateTime? date_of_last_inspection { get; set; }
        public string certificate_of_operations { get; set; }
        public string information { get; set; }
        public string notes { get; set; }

        public long? building_id { get; set; }  
        public long? employee_id { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual ICollection<Columns> Column { get; set; }
    }
}