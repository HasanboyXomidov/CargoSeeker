using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.Verifications;

public class VerificationDto
{
    public int Code { get; set; }
    public int Attempt { get; set; }
    public DateTime CreatedAt { get; set; }

}
