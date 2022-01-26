using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string TcKimlikNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public int? GenderId { get; set; }

        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public List<Article> Articles { get; set; }

        public User()
        {
            GenderId = 1;
        }
    }
}
