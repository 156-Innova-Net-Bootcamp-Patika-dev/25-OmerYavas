using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
