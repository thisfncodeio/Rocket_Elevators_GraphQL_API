using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Lead
    {
        public long Id { get; set; }
        public string full_name_of_contact { get; set; }
        public string company_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string project_name { get; set; }
        public string project_description { get; set; }
        public string department_in_charge_of_elevators { get; set; }
        public string message { get; set; }
        public byte[] attachment { get; set; }
        public DateTime? CreateAt { get; set; }
        public long? CustomerId { get; set; }
        public string NameAttachedFile { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
