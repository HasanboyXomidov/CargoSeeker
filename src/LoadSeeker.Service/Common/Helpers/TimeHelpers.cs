using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Common.Helpers
{
    public class TimeHelpers
    {
        public static DateTime GetDateTime()
        {
            var dTime = DateTime.UtcNow;
            //dTime.AddHours
            return dTime;

        }
    }
}
