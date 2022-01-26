using PatikaOdev3.Model.Entities;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Absract
{
    public interface IUserService : IBaseService<User>
    {
        List<User> GetUndeletedUserList();
        User GetUnDeletedUserWithUserName(string userName);
    }
}
