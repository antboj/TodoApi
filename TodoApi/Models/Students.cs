using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Students
    {
        [Key]
        public int SId { get; set; }
        public string SName { get; set; }
    }
}
