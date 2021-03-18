using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GraphQL_API.Entities;


#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Building
    {
        public Building()
        {
            Batteries = new HashSet<Battery>();
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
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<BuildingsDetail> BuildingsDetails { get; set; }


    }
}
