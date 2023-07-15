using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSeeker.Domain.Entities
{
    public abstract class Auditable : BaseEntity
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set;}
    }
}
