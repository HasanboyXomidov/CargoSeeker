using CargoSeeker.Domain.Enums.UserEnums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.Users;

public class UserCreateDto
{
    public string first_name { get; set; } = string.Empty;
    public string second_name { get; set; } = string.Empty;
    public string country { get; set; } = string.Empty;
    public string tel_number { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string passwordHash { get; set; } = string.Empty;
    public string salt { get; set; } = string.Empty;
    public IFormFile userPhotoPath { get; set; } = default!;
    //public long DocumentPicture_id { get; set; }
    public UserStatus status { get; set; }    
    public int rating { get; set; }    
    public double lattitude { get; set; }
    public double longtitude { get; set; }
}
