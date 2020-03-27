using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public interface IBUserRepository
    {

        public IEnumerable<BUser> GetAll();
        public BUser GetByEmail(string email);
        public void Add(BUser user);
        public void SaveChanges();
        

    }
}
