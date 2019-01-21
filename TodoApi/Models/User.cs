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

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string birth_place { get; set; }
        public string email { get; set; }
    }
}