using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
