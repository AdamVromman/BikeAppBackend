using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Repositories
{
    public class AddedPartRepository : IAddedPartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<AddedPart> _AddedParts;

        public AddedPartRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _AddedParts = context.AddedParts;
        }

        public void AddAddedPart(AddedPart part)
        {
            if (part != null)
            {
                _AddedParts.Add(part);
            }
        }

        public IEnumerable<AddedPart> GetAll()
        {
            return _AddedParts
                .Include(a => a.BUser)
                .Include(a => a.Part)
                .ToList();
        }

        public IEnumerable<AddedPart> GetByBUserEmail(string email)
        {
            return _AddedParts
                .Where(a => a.BUser.Email.ToLower().Equals(email.ToLower()))
                .Include(a => a.BUser)
                .Include(a => a.Part)
                .ToList();
        }

        public AddedPart GetById(int id)
        {
            return _AddedParts
                .FirstOrDefault(a => a.Id == id);
                
        }

        public IEnumerable<AddedPart> GetByPartId(int id)
        {
            return _AddedParts
                .Where(a => a.Part.Id == id)
                .Include(a => a.BUser)
                .Include(a => a.Part)
                .ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
