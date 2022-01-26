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
    //Article ile ilgili veritabanı işlemlerini gerçekleştirir.
    public class EfArticleRepository : EfBaseRepository<Article, OdevDbContext>, IArticleDAL
    {
        //Article özel tanımlanacak yapılar burada oluşturulacaktır.
    }
}
