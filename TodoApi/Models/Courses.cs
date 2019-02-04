using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Courses
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
    }
}
