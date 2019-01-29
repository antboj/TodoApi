using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;


namespace TodoApi.Models
{
    public class Job
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
    }
}
