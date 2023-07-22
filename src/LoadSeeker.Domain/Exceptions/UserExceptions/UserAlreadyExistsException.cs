using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions.UserExceptions;

public class UserAlreadyExistsException:AlreadyExistsExceptions
{
    public UserAlreadyExistsException()
    {
        this.TitleMessage = "User Already Exists!";
    }
    public UserAlreadyExistsException(string phone)
    {
        TitleMessage = "This phone is already REgistred !";
    }
}
