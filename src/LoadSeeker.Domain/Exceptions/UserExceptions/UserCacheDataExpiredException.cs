using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions.UserExceptions;

public class UserCacheDataExpiredException: ExpiredException
{
    public UserCacheDataExpiredException()
    {
        this.TitleMessage = "User Data has Expired";
    }
}
