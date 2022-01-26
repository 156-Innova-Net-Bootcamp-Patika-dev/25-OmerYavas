using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.DTOs.CommentDTOs
{
    public class CommentAddDTO
    {
        public string Content { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int ArticleId { get; set; }
    }
}
