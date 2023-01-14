// See https:/aka.ms/new-console-template for more information
using homework6_parnianRafie;

Console.WriteLine("Hello, World!");
UserRepository repository= new UserRepository();
var result = "";
do
{
    try
    {

  
    repository.showMenu();
    Console.WriteLine("select your option:  ");
   
        var select = Console.ReadLine();
        switch (select)
        {
            case "register":
                repository.Register();
                Console.WriteLine("if you want to quit,type quit......");
                result = Console.ReadLine();
                break;
            case "registerlist":
                repository.RegisterList();
                Console.WriteLine("if you want to quit,type quit......");
                result = Console.ReadLine();
                break;
            case "updateuser":
                repository.RegisterList();
                Console.WriteLine("enter the id of user you wanted to upgrade:  ");
                int id = Convert.ToInt32(Console.ReadLine());
                repository.Upgrade(id);
                Console.WriteLine("if you want to quit,type quit......");
                result = Console.ReadLine();
                break;
            case "removeuser":
                repository.RegisterList();
                Console.WriteLine("enter the id of user you wanted to remove:  ");
                int id_ = Convert.ToInt32(Console.ReadLine());
                repository.Upgrade(id_);
                Console.WriteLine("if you want to quit,type quit......");
                result = Console.ReadLine();
                break;
        }
    }
    catch (IOException)
    {
        Console.WriteLine("you opened this program, close it & try again:  ");
    }


} while (result!= "quit");
