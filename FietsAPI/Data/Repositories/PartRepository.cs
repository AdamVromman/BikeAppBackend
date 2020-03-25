﻿using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FietsAPI.Data.Repositories
{
    public class PartRepository : IPartRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<Part> _Parts;

        public PartRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _Parts = _applicationDbContext.Parts;
        }

        public IEnumerable<Part> GetAll()
        {
            return _Parts
                .Include(p => p.DependantParts)
                .ToList();
        }

        public IEnumerable<Part> GetByFunctionality(Functionality Functionality)
        {
            return _Parts.Where(o => o.Functionality == Functionality)
                .Include(p => p.DependantParts)
                .ToList();
        }

        public Part GetById(int id)
        {
            return _Parts
                .Include(p => p.DependantParts)
                .FirstOrDefault(o => o.Id == id);
        }
    }
}