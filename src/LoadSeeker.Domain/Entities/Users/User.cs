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
    public string second_name { get; set; } = string.Empty;
    public string country { get; set; } = string.Empty;    
    public string tel_number { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string passwordHash { get; set; } = string.Empty;
    public string salt { get; set; } = string.Empty;
    public string userPhotoPath { get; set; } = string.Empty;
    public long DocumentPicture_id { get; set; }
    public UserStatus status { get; set; }
    public DateTime last_activity { get; set; }
    public int rating { get; set; }
    public long Review_id { get; set; }
    public double lattitude { get; set; }
    public double longtitude { get; set; }
}
