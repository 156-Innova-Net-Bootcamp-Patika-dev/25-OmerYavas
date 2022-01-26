using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.DTOs.ArticleDTOs
{
    public class ArticleListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public string ImageTitle { get; set; }
        public string CategoryName { get; set; }
    }
}
