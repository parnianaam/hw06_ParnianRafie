using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework6_parnianRafie;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace homework6_parnianRafie
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? BirthDate { get; set; }
        public string? RegisterDate { get; set; }
        public static List<User> usersList { get; set; }
        public User()
        {
            usersList = new List<User>();
        }
    }
}
