using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework6_parnianRafie;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Data;

namespace homework6_parnianRafie
{
    public class UserRepository : IUserRepository
    {
        int id = 1;
        public string Register()
        {

            StreamWriter DataStorageFileWrite = File.AppendText(@"C:\Users\hufu\Desktop\homework_06_parnianrafie\DataStorage.csv");
            User user = new User();
            Console.WriteLine("enter FullName:  \n Mobile:  \n BirthDate:  \n ");
            user.Id = id;
            user.Name = Console.ReadLine();
            var mobile = Console.ReadLine();
            while (!(mobile.Length >= 10 && mobile.Substring(mobile.Length - 10).All(char.IsDigit)))
            {
                Console.WriteLine("your mobileNumber is not valid, please enter valid numbers");
                mobile = Console.ReadLine();
            }
            user.Mobile = "(+98)" + mobile.Substring(mobile.Length - 10);
            try
            {
                user.BirthDate = Console.ReadLine();
                var birthDateIran = DateTime.Parse(user.BirthDate, new CultureInfo("fa-IR"));
                var birthDateGreg = birthDateIran.ToUniversalTime();
                var result = DateTime.Compare(birthDateGreg, DateTime.Now);
                while (result > 0)
                {
                    Console.WriteLine("your dateBirth is not valid, please enter your BirthDate:  ");
                    user.BirthDate = Console.ReadLine();
                    birthDateIran = DateTime.Parse(user.BirthDate, new CultureInfo("fa-IR"));
                    birthDateGreg = birthDateIran.ToUniversalTime();
                    result = DateTime.Compare(birthDateGreg, DateTime.Now);

                }

            }
            catch (FormatException)
            {
                Console.WriteLine("your format of dateBirth is not valid it should be like yyyy/MM/dd:    ");
                user.BirthDate = Console.ReadLine();
                var birthDateIran = DateTime.Parse(user.BirthDate, new CultureInfo("fa-IR"));
                var birthDateGreg = birthDateIran.ToUniversalTime();
                var result = DateTime.Compare(birthDateGreg, DateTime.Now);
                while (result > 0)
                {
                    Console.WriteLine("your dateBirth is not valid, please enter your BirthDate:  ");
                    user.BirthDate = Console.ReadLine();
                    birthDateIran = DateTime.Parse(user.BirthDate, new CultureInfo("fa-IR"));
                    birthDateGreg = birthDateIran.ToUniversalTime();
                    result = DateTime.Compare(birthDateGreg, DateTime.Now);

                }

            }
           

            var registerDate = DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
            user.RegisterDate = registerDate;
            var userJson = JsonConvert.SerializeObject(user);
            DataStorageFileWrite.WriteLine(userJson);
            DataStorageFileWrite.Close();
            if (id <= 30)
            {
                id += 1;
                return "you have been registered";
            }
            else
            {
                return "we have full member";
            }

        }


        public void RegisterList()
        {

            foreach (var fileLine in Desirialize.userList())
            {
                var fileLineJson = JsonConvert.SerializeObject(fileLine);
                Console.WriteLine(fileLineJson);
            }

        }

        public void Remove(int id)
        {
            List<User> removeList = new List<User>();
            var lists = Desirialize.userList();
            foreach (var user_ in lists)
            {
                if (user_.Id != id)
                {
                    removeList.Add(user_);
                }
            }
            var removeObject = File.CreateText(@"C:\Users\hufu\Desktop\homework_06_parnianrafie\DataStorage.csv");
            foreach (var user in removeList)
            {
                var userJson = JsonConvert.SerializeObject(user);
                removeObject.WriteLine(userJson);

            }
            removeObject.Close();

        }

        public void Upgrade(int id_)
        {
            int s = id;
            Remove(id_);
            id= id_;
            Register();
            id = s;

        }
        public void showMenu()
        {
            Console.WriteLine("1-Register \n 2-RegisterList \n 3-UpdateUser \n 4-RemoveUser");
        }
    }
}
