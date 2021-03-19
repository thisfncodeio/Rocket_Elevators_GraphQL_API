using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Employees
    {
        public Employees(HashSet<Batteries> Batteries)
        {
            Batteries = new HashSet<Batteries>();
        }

        public long Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public long? user_id { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Batteries> Battery { get; set; }
    }
}
