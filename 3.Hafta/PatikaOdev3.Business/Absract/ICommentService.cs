using PatikaOdev3.Model.Entities;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Absract
{
    public interface ICommentService : IBaseService<Comment>
    {
        List<Comment> GetUndeletedCommentList();
    }
}
