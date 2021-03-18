using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class BuildingsDetail
    {
        public long Id { get; set; }
        public string information_key { get; set; }
        public string value { get; set; }
        public long? building_id { get; set; }

        public virtual Building Building { get; set; }
    }
}
