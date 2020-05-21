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
        /// <summary>
        /// geeft alle Bikes terug
        /// </summary>
        /// <returns>all Bikes</returns>
        [HttpGet]
        public IEnumerable<BikeDTO> GetBikes()
        {
            return _bikeRepository.GetAll().Select(b =>
            {
                return new BikeDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Type = b.Type,
                    Parts = b.Parts.Select(p =>
                    {
                        PartDTO part = new PartDTO
                        {
                            Id = p.Part.Id,
                            Name = p.Part.Name,
                            Description = p.Part.Description,
                            Functionality = p.Part.Functionality.ToString(),
                            IsOptional = p.Part.IsOptional,
                            DominantParts = p.Part.DominantParts.Select(dp => dp.DominantPart.Name).ToList(),
                            DependantParts = p.Part.DependantParts.Select(dp => dp.DependantPart.Name).ToList(),
                            BikeId = p.Part.BikeParts.Select(b => b.BikeId).ToList()
                        };

                        return part;
                    }).OrderBy(p => p.Name).ToList()
                };


            }).ToList();
        }
        /// <summary>
        /// Geeft een Bike terug, gefilterd op naam
        /// </summary>
        /// <param name="name">De naam van de Bike</param>
        /// <returns>1 Bike</returns>
        [HttpGet("{name}")]
        public ActionResult<BikeDTO> GetBikeByName(string name)
        {
            try
            {
                Bike bike = _bikeRepository.GetByName(name);
                BikeDTO bikeDTO = new BikeDTO
                {
                    Id = bike.Id,
                    Name = bike.Name,
                    Parts = bike.Parts.Select(p =>
                    {
                        PartDTO part = new PartDTO
                        {
                            Id = p.Part.Id,
                            Name = p.Part.Name,
                            Description = p.Part.Description,
                            Functionality = p.Part.Functionality.ToString(),
                            IsOptional = p.Part.IsOptional,
                            DominantParts = p.Part.DominantParts.Select(dp => dp.DominantPart.Name).ToList(),
                            DependantParts = p.Part.DependantParts.Select(dp => dp.DependantPart.Name).ToList(),
                            BikeId = p.Part.BikeParts.Select(b => b.BikeId).ToList()
                        };

                        return part;
                    }).OrderBy(p => p.Name).ToList(),
                    Type = bike.Type

                };
                return Ok(bikeDTO);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
           
        }

    }
}