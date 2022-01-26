using Infrastructure.DataAccess.EntityFramework.Concrete;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.DataAccess.Contexts;
using PatikaOdev3.Model.Entities;

namespace PatikaOdev3.DataAccess.Concrete.EntityFramework
{
    public class EfGenderRepository : EfBaseRepository<Gender, OdevDbContext>, IGenderDAL
    {
    }
}
