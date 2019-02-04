using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class StudentCourse
    {
        public int SId { get; set; }
        public Students Student { get; set; }
        
        public int CId { get; set; }
        public Courses Course { get; set; }
    }
}
