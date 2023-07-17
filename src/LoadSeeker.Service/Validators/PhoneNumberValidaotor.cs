using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Validators;

public class PhoneNumberValidaotor
{
    public static bool IsValid (string PhoneNumber)
    {
        if(PhoneNumber.Length!=13) return false;    
        if(PhoneNumber.StartsWith("+998")==false)return false;
        for(int i = 1; i < PhoneNumber.Length; i++)
        {
            if (char.IsDigit(PhoneNumber[i])) continue;
            else return false;
        }
        return true;
    }
}
