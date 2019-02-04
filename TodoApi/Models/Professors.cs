using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Professors
    {
        [Key]
        public int PId { get; set; }
        public string PName { get; set; }

        public int CId { get; set; }

        [ForeignKey("CId")]
        public Students Student { get; set; }
    }
}
