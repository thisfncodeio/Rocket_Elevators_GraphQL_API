using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Addresses
    {
        public Addresses(HashSet<Customers> Customers, HashSet<Buildings> Buildings)
        {
            Buildings = new HashSet<Buildings>();
            Customers = new HashSet<Customers>();
        }

        public long Id { get; set; }
        public string type_of_Address { get; set; }
        public string status { get; set; }
        public string entity { get; set; }
        public string number_and_street { get; set; }
        public string suite_and_apartment { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string notes { get; set; }
        public float? lat { get; set; }
        public float? lng { get; set; }

        public virtual ICollection<Buildings> Building { get; set; }
        public virtual ICollection<Customers> Customer { get; set; }
        public object Addresses1 { get; internal set; }
    }
}
