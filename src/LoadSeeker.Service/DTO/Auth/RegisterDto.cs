using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.Auth;

public class RegisterDto
{
    public string first_name { get ; set; } = string.Empty; 
    public string tel_number { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;    

}
