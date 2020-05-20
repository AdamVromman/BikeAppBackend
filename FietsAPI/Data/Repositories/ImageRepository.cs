using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Image> _images;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
            _images = context.Images;
        }

        public void addImage(Image image)
        {
            _images.Add(image);
        }

        public IEnumerable<Image> GetAll()
        {
            return _images;
        }

        public Image GetByAddedPartId(int id)
        {
            return _images.Include(i => i.Part).FirstOrDefault(i => i.Id == id);
        }

        public Image GetById(int id)
        {
            return _images.Include(i => i.Part).FirstOrDefault(i => i.PartId == id);
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
    }
}
