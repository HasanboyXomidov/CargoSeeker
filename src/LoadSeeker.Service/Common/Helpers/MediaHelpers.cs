using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Common.Helpers;

public class MediaHelpers
{
    public static string MakeImageName(string FileName)
    {
        FileInfo fileInfo = new FileInfo(FileName); 
        string Extencion = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid()+Extencion;
        return name;
    }
    public static string[] GetImageExtencions()
    {
        return new string[]
        {
             // JPG files
            ".jpg", ".jpeg",
            // Png files
            ".png",
            // Bmp files
            ".bmp",            
        };
    }
}
