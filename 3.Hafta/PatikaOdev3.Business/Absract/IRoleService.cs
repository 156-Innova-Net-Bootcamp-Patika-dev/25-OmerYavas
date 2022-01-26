using PatikaOdev3.Model.Entities;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Absract
{
    public interface IRoleService : IBaseService<Role>
    {
        List<Role> GetUndeletedRoleList();
        Role GetUnDeletedRole(string name);
    }
}
