using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    interface IBUserRepository
    {

        public IEnumerable<BUser> GetAll();
        public BUser GetById(int id);
        public void Add(BUser user);
        public void SaveChanges();
        

    }
}
