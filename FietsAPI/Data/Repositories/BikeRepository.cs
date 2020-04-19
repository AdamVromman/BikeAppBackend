using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Bike> _bikes;

        public BikeRepository(ApplicationDbContext context)
        {
            _context = context;
            _bikes = context.Bikes;
        }

        public IEnumerable<Bike> GetAll()
        {
            return _bikes.OrderBy(b => b.Name)
                .Include(b => b.Parts)
                .ThenInclude(b => b.Part.DominantParts)
                .Include(b => b.Parts)
                .ThenInclude(p => p.Part.DependantParts)
                .ToList();
        }

        public Bike GetById(int id)
        {
            return _bikes.FirstOrDefault(b => b.Id == id);
                
        }

        public IEnumerable<Bike> GetByType(string type)
        {
            return _bikes.Where(b => b.Type.ToLower().Equals(type.ToLower()))
                .Include(b => b.Parts)
                .OrderBy(b => b.Name);
                
        }
    }
}
