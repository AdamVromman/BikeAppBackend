using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Repositories
{
    public class BUserRepository : IBUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<BUser> _bUsers;

        public BUserRepository(ApplicationDbContext context)
        {
            _context = context;
            _bUsers = _context.BUsers;
        }


        public void Add(BUser bUser)
        {
            _bUsers.Add(bUser);
        }

        public IEnumerable<BUser> GetAll()
        {
            return _bUsers.OrderBy(u => u.LastName).ToList();
        }

        public BUser GetById(int id)
        {
            return _bUsers.FirstOrDefault(u => u.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
