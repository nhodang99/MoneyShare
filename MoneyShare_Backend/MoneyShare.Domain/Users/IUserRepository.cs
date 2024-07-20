using MoneyShare.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyShare.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        //public User GetUserWithBills(int id);
    }
}
