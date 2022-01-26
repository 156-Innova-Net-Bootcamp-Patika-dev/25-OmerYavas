using Infrastructure.DataAccess.Abstract;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.DataAccess.Abstract
{
    public interface IArticleDAL : IBaseDAL<Article>
    {

    }
}
