using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class DimCustomer
    {
        public long Id { get; set; }
        public DateTime? creation_date { get; set; }
        public string company_name { get; set; }
        public string company_contact { get; set; }
        public string company_email { get; set; }
        public int? nb_elevators { get; set; }
        public string customer_city { get; set; }
    }
}
