using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    public class Movie : Controller
    {
        // Declare class properties
        private int Id { set; get; }
        private string Name { set; get; }
        private double Rating { set; get; }
        private bool InStore { set; get; }


    }
























    /*
    public interface IProduct
    {
        void Set(string description);

    }

    public class Desk : IProduct
    {
        private string Description;

        public void Set(string description)
        {
            Description = description;
        }

        public string GetD()
        {
            return Description;
        }
    }

    public class DeskController : Desk
    {
        // GET: api/<controller>
        [HttpGet("api/Desk/{description}")]
        public string Get(string description)
        {
            Set(description);
            return GetD();
        }
    }

    public class User
    {
        public int Id;
        public string UserName;
        public string Password;

        private void Set(int id, string userName, string password)
        {
            Id = id;
            Password = password;
            UserName = userName;
        }

        [HttpPost("api/User/Insert" +
                  "")]
        public void Insert(int id, [FromBody]string userName, [FromBody]string password)
        {
            Set(id, userName, password);
        }
    }


    [Route("api/Exercise")]
    public class ExerciseController : Controller 
    {
        // Declare class fields
        public int id = 1;
        public double price = 99.99;
        public bool isAvailable = true;
        public string description = "opis";
        public enum values { value1, value2, value3 }
        private static ArrayList list = new ArrayList();
        private static List<User> descriptions = new List<User>();
        private Hashtable Users = new Hashtable();

        // Set userName & password
        private void SetUser(string userName, string password)
        {
            Users.Add(userName, password);
        }

        // POST: api/<controller>
        [HttpPost("InsertUser")]
        public void InsertUser(string userName, string password)
        {
            SetUser(userName, password);
        }

        // GET: api/<controller>
        [HttpGet("getUserPassword")]
        public string GetUserPassword(string userName)
        {
            var Password = Users[userName] as string;

            if (Password == null)
            {
                return "error";
            }

            return Password;
        }

        // Set fields to the array list
        private void SetList()
        {
            list.Add(id);
            list.Add(price);
            list.Add(isAvailable);
            list.Add(description);
            list.Add(values.value1);
        }

        // GET: api/<controller>
        [HttpGet("getList")]
        public ArrayList GetList()
        {
            SetList();
            return list;
        }

        // GET: api/<controller>
        [HttpGet("getDescription")]
        public string GetDescription()
        {
            return description;
        }

        

    }
    */
}
