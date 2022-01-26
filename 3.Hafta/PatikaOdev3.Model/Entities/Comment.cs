using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
