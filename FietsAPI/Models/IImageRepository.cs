using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public interface IImageRepository
    {

        public IEnumerable<Image> GetAll();
        public Image GetById(int id);
        public Image GetByAddedPartId(int id);
        public void addImage(Image image);
        public void saveChanges();

    }
}
