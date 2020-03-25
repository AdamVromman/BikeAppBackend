using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    interface IUserRepository
    {

        public IEnumerable<User> GetAll();
        public User GetById();
        public void Add(User user);
        public void SaveChanges();
        

    }
}
