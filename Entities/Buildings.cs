using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GraphQL_API.Entities;


#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Buildings
    {
        public Buildings(HashSet<Batteries> Batteries)
        {
            Batteries = new HashSet<Batteries>();
            // BuildingsDetails = new HashSet<BuildingsDetail>();
        }
        
        public long Id { get; set; }                  
        public string full_name_of_the_building_administrator { get; set; }
        public string email_of_the_administrator_of_the_building { get; set; }
        public string phone_number_of_the_building_administrator { get; set; }
        public string full_name_of_the_technical_contact_for_the_building { get; set; }
        public string technical_contact_email_for_the_building { get; set; }
        public string technical_contact_phone_for_the_building { get; set; }
        public long? customer_id { get; set; }
        public long? address_id { get; set; }
        public virtual Addresses Address { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<Batteries> Battery { get; set; }
        public virtual ICollection<BuildingsDetails> BuildingsDetail { get; set; }

        public class Addresses
        {
            internal object Id;

            public object Buildings { get; internal set; }
            public object Building { get; internal set; }
        }
    }
}
