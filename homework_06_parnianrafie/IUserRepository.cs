using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6_parnianRafie
{
    public interface IUserRepository
    {
        string Register();
        void RegisterList();
        void Upgrade(int id);
        void Remove(int id);
        void showMenu();

    }
}
