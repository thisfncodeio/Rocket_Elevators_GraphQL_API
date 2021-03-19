using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Customers
    {
        public Customers(HashSet<Buildings> Buildings, HashSet<Leads> Leads)
        {
            Buildings = new HashSet<Buildings>();
            Leads = new HashSet<Leads>();
        }

        public long Id { get; set; }
        public DateTime? customers_creation_date { get; set; }
        public string company_name { get; set; }
        public string full_name_of_company_contact { get; set; }
        public string company_contact_phone { get; set; }
        public string email_of_company_contact { get; set; }
        public string company_description { get; set; }
        public string full_name_of_service_technical_authority { get; set; }
        public string technical_authority_phone_for_service_ { get; set; }
        public string technical_manager_email_for_service { get; set; }
        public long? user_id { get; set; }
        public long? address_id { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Buildings> Building { get; set; }
        public virtual ICollection<Leads> Lead { get; set; }

        public class Addresses
        {
            public object Customer { get; internal set; }
        }
    }
}

