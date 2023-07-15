using CargoSeeker.Domain.Enums.UserEnums;
using LoadSeeker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Entities.Users;

public class User:Auditable
{
    public string first_name { get; set; }
    public string second_name { get; set; }
    public string country { get; set; }
    public string province { get; set; }
    public string tel_number { get; set; }
    public string email { get; set; }
    public string passwordHash { get; set; }
    public string salt { get; set; }
    public string userPhotoPath { get; set; }
    public long DocumentPicture_id { get; set; }
    public UserStatus status { get; set; }
    public DateTime last_activity { get; set; }
    public int rating { get; set; }
    public long Review_id { get; set; }
    public double lattitude { get; set; }
    public double longtitude { get; set; }
}
