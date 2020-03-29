using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FietsAPI.Models;
using FietsAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FietsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class BikesController : ControllerBase
    {

        private readonly IBikeRepository _bikeRepository;

        public BikesController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
           
        }

        [HttpGet]
        public IEnumerable<BikeDTO> GetBikes()
        {
            return _bikeRepository.GetAll().Select(b =>
            {
                return new BikeDTO
                {
                    Name = b.Name,
                    Type = b.Type,
                    Parts = b.Parts.Select(p =>
                    {
                        PartDTO part = new PartDTO
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            Functionality = p.Functionality.ToString(),
                            IsOptional = p.IsOptional,
                            DominantParts = p.DominantParts.Select(dp => dp.DominantPart.Name).ToList(),
                            DependantParts = p.DependantParts.Select(dp => dp.DependantPart.Name).ToList()
                        };
                       
                        return part;
                    }).ToList()
                };
                
                
            }).ToList();
        }

    }
}