using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        //public static List<int> Values;
        public enum Names
        {
            Peter, Sally, John
        }

        // GET: api/<controller>
        [HttpGet("GetEnum")]
        // Return enum value
        public string GetEnum()
        {
            var name = (Names.John).ToString();
            return name;
        }

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
            //Values.Add(num);
        }

        // GET: api/<controller>
        [HttpGet("GetFor")]
        // Return modulo int from for loop
        public int GetFor()
        {
            int modulo = 0;

            for (int i = 1; i <= Num2; i++)
            {
                if (Num2 % i == 0)
                {
                    modulo = i;
                }
            }

            return modulo;
        }

        // GET: api/<controller>
        [HttpGet("GetArrList")]
        // Return count of elements in Array List
        public int GetArrList()
        {
            ArrayList List = new ArrayList();
            List.Add(Status);
            List.Add(Name);
            return List.Count;
        }

        // GET: api/<controller>
        [HttpGet("GetStack")]
        // Return true if number is in the stack
        public bool GetStack(int number)
        {
            Stack Numbers = new Stack();
            Numbers.Push(Num1);
            Numbers.Push(Num2);

            if (Numbers.Contains(number))
            {
                Status = true;
            }

            return Status;
        }

        // GET: api/<controller>
        [HttpGet("GetQueue")]
        // Return true if name is in Queue
        public bool GetQueue(string name)
        {
            Queue Names = new Queue();
            Names.Enqueue(Name);

            if (Names.Contains(name))
            {
                Status = true;
            }

            return Status;
        }

        // GET: api/<controller>
        [HttpGet("GetHashtable")]
        // Return true if value is in Hashtable
        public bool GetHashtable(string value)
        {
            Hashtable Users = new Hashtable();

            Users.Add(Num1, Name);

            if (Users.ContainsValue(value))
            {
                Status = true;
            }

            return Status;
        }

        // GET: api/<controller>
        [HttpGet("GetFile")]
        // Reading all from a file
        public string GetFile()
        {
            string path = @"C:\\Users\\bild99\\source\\repos\\data.txt";
            string data = null;

            if (System.IO.File.Exists(path))
            {
                data = System.IO.File.ReadAllText(path);
            }

            return data;
        }

        // GET: api/<controller>
        [HttpGet("GetStream")]
        // Reading all from a stream
        // While loop
        public string getStream()
        {
            string path = @"C:\\Users\\bild99\\source\\repos\\data.txt";
            string data = null;

            using (StreamReader sr = System.IO.File.OpenText(path))
            {
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    data = s;
                }

                return data;
            }
        }

        // Return bool 
        // GET: api/<controller>
        [HttpGet("GetS")]
        public bool GetS()
        {
            string path = @"C:\\Users\\bild99\\Desktop\\data.txt";

            Exercise exercise = new Exercise();

            if (System.IO.File.Exists(path))
            {
                string result = JsonConvert.SerializeObject(exercise);

                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(result.ToString());
                    sw.Close();
                }

                Status = true;
            }

            return Status;
        }
    }
}
