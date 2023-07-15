using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions.UserExceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException()
    {
        this.TitleMessage = "User Not Found !";
    }
}
