using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                .Include(a => a.Image)
                .ToList();
        }

        public IEnumerable<AddedPart> GetByBUserEmail(string email)
        {
            return _AddedParts
                .Where(a => a.BUser.Email.ToLower().Equals(email.ToLower()))
                .Include(a => a.BUser)
                .Include(a => a.Part)
                .Include(a => a.Image)
                .ToList();
        }

        public AddedPart GetById(int id)
        {
            return _AddedParts
                .Include(a => a.BUser)
                .Include(a => a.Part)
                .Include(a => a.Image)
                .FirstOrDefault(a => a.Id == id);
                
        }

        public IEnumerable<AddedPart> GetByPartId(int id)
        {
            return _AddedParts
                .Where(a => a.Part.Id == id)
                .Include(a => a.BUser)
                .Include(a => a.Part)
                .Include(a => a.Image)
                .OrderBy(a => a.Id)
                .Reverse()
                .ToList();
        }

        public AddedPart GetMostRecentByPartIdAndEmail(int id, string email)
        {
            ICollection<AddedPart> parts = _AddedParts.Include(a => a.BUser)
                .Include(a => a.Part)
                .Include(a => a.Image).Where(a => a.Part.Id == id && a.BUser.Email.Equals(email)).ToList();
            return parts.ElementAt(parts.Count - 1);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
