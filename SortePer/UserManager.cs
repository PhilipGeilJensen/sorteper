using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class UserManager
    {
        public User CreateUser(string name)
        {
            return new User(name);
        }
        public User CreateUser(string name, bool player)
        {
            return new User(name, player);
        }
    }
}
