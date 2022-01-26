using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaOdev3.Model.Common
{
    public class EntityResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
