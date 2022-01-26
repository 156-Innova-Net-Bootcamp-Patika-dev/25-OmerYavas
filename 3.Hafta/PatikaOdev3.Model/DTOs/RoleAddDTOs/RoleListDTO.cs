using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.DTOs.RoleAddDTOs
{
    public class RoleListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }


    }
}
