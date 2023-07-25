using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Common.Helpers;

public class CodeGenerator
{
    public static int GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(10000,99999);   
    }
}
