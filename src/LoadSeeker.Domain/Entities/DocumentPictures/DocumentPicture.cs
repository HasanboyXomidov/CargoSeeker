using LoadSeeker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Entities.DocumentPictures;

public class DocumentPicture: Auditable
{
    public string passport_image_path { get ; set; }
    public string driverLicence_Image_path { get ; set; }

}
