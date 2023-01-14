using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6_parnianRafie
{
    public static class Desirialize
    {



        public static List<User> userList()
        {
            List<User> users = new List<User>();
            string DataStorageFile = File.ReadAllText(@"C:\Users\hufu\Desktop\homework_06_parnianrafie\DataStorage.csv");
            string[] DataStorageFileArray = DataStorageFile.Split("\n");
            foreach (var fileLine in DataStorageFileArray)
            {
                var DataStorageObject = JsonConvert.DeserializeObject<User>(fileLine);
                if (DataStorageObject != null)
                {
                    users.Add(DataStorageObject);
                }

            }
            return users;
        }

    }
}
