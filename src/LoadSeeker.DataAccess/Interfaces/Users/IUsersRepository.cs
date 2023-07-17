using CargoSeeker.DataAccess.Commons.Interfaces;
using CargoSeeker.DataAccess.ViewModels.Users;
using CargoSeeker.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Interfaces.Users
{
    public interface IUsersRepository:IRepository<User , UserViewModel>        
    {
    }
}
