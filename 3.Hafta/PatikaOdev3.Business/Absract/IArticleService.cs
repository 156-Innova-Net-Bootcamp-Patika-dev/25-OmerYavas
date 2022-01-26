using PatikaOdev3.Model.Entities;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Absract
{
    public interface IArticleService : IBaseService<Article>
    {
        List<Article> GetUndeletedArticleList();
        List<Article> GetUndeletedArticleWithTitle(string title);
    }
}
