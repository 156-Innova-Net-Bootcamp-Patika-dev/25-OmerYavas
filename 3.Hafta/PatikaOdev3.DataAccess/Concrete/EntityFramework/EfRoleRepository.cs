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
    // Rol ile ilgili veritabanı işlemleri yapmak için kullanılacaktır.
    public class EfRoleRepository : EfBaseRepository<Role, OdevDbContext>,IRoleDAL
    {
        //Role ile ilgili özel işlemler burada tanımlanacak.
    }
}
