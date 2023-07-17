using LoadSeeker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Entities.Reviews
{
    public class Review:Auditable
    {
        public long userId { get ; set; }
        public string review { get ; set; }
        public bool isEdited { get; set; }
    }
}
