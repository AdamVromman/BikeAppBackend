using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data
{
    public class BikeDataInitializer
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public BikeDataInitializer(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public void InitializeData()
        {
            _applicationDbContext.Database.EnsureCreated();
        }

    }
}
