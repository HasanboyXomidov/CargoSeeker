using CargoSeeker.Domain.Enums.UserEnums;
using LoadSeeker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Entities.Users;

public class User : Auditable
{
    public string first_name { get; set; } = string.Empty;        
    public string second_name { get; set; }=string.Empty;
    public string country { get ; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public UserStatus status { get; set; }  
    public int rating { get; set; }
    public double lattitude { get; set; }   
    public double longtitude { get; set; }
    //public long review_id { get; set; }
    //public long documentpicture_id { get; set; }
    public string userPhotoPath { get; set; }= string.Empty;
    public string tel_number { get; set; } = string.Empty;    
    public bool tel_number_confirmed { get; set; } = false;
    public DateTime last_activity { get; set; } 
    public string passwordHash { get; set; } = string.Empty;
    public string salt { get; set; } = string.Empty;                                
}
