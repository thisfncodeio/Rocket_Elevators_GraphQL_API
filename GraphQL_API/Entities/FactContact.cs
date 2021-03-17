using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactContact
    {
        public long Id { get; set; }
        public int? contact_id { get; set; }
        public DateTime? creation_date { get; set; }
        public string company_name { get; set; }
        public string email { get; set; }
        public string project_name { get; set; }
    }
}
