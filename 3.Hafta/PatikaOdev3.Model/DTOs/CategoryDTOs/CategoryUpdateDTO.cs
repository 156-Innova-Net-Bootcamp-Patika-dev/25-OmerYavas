using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.DTOs.CategoryDTOs
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
