using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebApi.Interfaces
{
    public interface IUserRepsitory
    {
        User GetUserByEmail(string email);
        void Add(User user);
    }
}
