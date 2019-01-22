using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/Exercise")]
    public class Exercise : Controller
    {
        // Declare class fields
        public string Name = "Peter";
        public int Num1 = 20;
        public int Num2 = 15;
        public bool Status = false;
        public static List<int> Values;

        // GET: api/<controller>
        [HttpGet("GetString")]
        // Return string
        public string GetString()
        {
            return Name;
        }

        // GET: api/<controller>
        [HttpGet("GetInt")]
        // Return int
        // If ststement
        public int GetInt()
        {
            if(Num1 > Num2)
            {
                return Num1;
            }
            else
            {
                return Num2;
            }
        }

        // GET: api/<controller>
        [HttpGet("GetBool")]
        // Return bool
        // Switch loop
        public bool GetBool()
        {
            int num = GetInt();
            switch (num)
            {
                case 20:
                    return true;
                    break;
                case 15:
                    return false;
                    break;
                default:
                    return false;
            }
        }

        // GET: api/<controller>
        [HttpGet("GetArr")]
        // Return int from array
        public int GetArr()
        {
            int[] Values;

            Values = new int[2];
            Values[0] = Num1;
            Values[1] = Num2;

            return Values[0];
        }

        // Add int element to the Values list
        private void SetList(int num)
        {
            Values.Add(num);
        }

        /*
        // GET: api/<controller>
        [HttpGet("GetList")]
        // Return int from list
        public int[] GetList()
        {
            Values.Add(Num1);
            Values.Add(Num2);

            int[] numbers;
            numbers = new int[2];

            for(var i=0; i<=Values.Count; i++)
            {
                numbers[i] = Values[i];
            }
            return numbers;
        }
        */

    }
}
