using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string DisplayORder { get; set; }
        public string ImageURL { get; set; }
        public string ImageTitle { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
