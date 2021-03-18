using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string email { get; set; }
        public string encrypted_password { get; set; }
        public string reset_password_token { get; set; }
        public DateTime? reset_password_sent_at { get; set; }
        public DateTime? remember_created_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool  superadmin_role  { get; set; }
        public bool employee_role { get; set; }
        public bool user_role { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
