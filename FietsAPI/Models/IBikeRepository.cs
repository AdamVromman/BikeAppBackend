using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public interface IBikeRepository
    {

        public IEnumerable<Bike> GetAll();
        public Bike GetById(int id);
        public IEnumerable<Bike> GetByType(string type);

    }
}
