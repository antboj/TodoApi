using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController<T> : Controller where T : User
    {
        [HttpGet("Compare/{param1}/{param2}")]
        public virtual bool Compare(T param1, T param2)
        {
            var rip = false;
            return param1.Equals(param2);
        }

        [HttpGet("Add")]
        public virtual List<T> Add(T param)
        {
            List<T> list = new List<T>();
            list.Add(param);
            return list;
        }
    }
}
