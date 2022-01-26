using Infrastructure.DataAccess.EntityFramework.Concrete;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.DataAccess.Contexts;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.DataAccess.Concrete.EntityFramework
{
    public class EfUserRepository : EfBaseRepository<User, OdevDbContext>, IUserDAL
    {

    }
}
