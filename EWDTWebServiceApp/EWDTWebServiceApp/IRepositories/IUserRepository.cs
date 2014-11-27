using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWDTWebServiceApp.Models
{
    interface IUserRepository
    {
        IEnumerable<UserClass> GetAll();
        UserClass GetByUser(string Username);
        UserClass Add(UserClass item);
        void Remove(string User);
        bool Update(UserClass item);
    }
}
