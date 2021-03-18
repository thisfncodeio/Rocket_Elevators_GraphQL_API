using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactQuote
    {
        public long Id { get; set; }
        public int? quote_id { get; set; }
        public DateTime? creation_date { get; set; }
        public string company_name { get; set; }
        public string email { get; set; }
        public int? num_elevators { get; set; }
    }
}
