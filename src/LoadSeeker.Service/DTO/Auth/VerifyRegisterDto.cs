using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.Auth;

public class VerifyRegisterDto
{
    public string PhoneNumber { get; set; } = string.Empty; 
    public int Code { get; set; }
}
