using PatikaOdev3.Model.Entities;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Absract
{
    public interface ICategoryService : IBaseService<Category>
    {
        List<Category> GetUndeletedCategoryList();
        Category GetUnDeletedCategory(string name);
    }
}
