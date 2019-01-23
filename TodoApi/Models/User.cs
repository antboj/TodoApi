using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class User
    {

        public static List<User> Users
        {
            get
            {
                var jsonString = File.ReadAllText("data.json");
                var list = JsonConvert.DeserializeObject<List<User>>(jsonString);
                return list;
            }
        }

        /*public static List<User> GetUsers()
        {
            var jsonString = File.ReadAllText("data.json");
            var list = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return list;
        }*/

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Email { get; set; }
    }
}