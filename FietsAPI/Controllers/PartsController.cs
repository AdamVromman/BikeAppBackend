﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FietsAPI.Models;
using FietsAPI.Models.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FietsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PartsController : ControllerBase
    {

        private readonly IPartRepository _partRepository;

        public PartsController(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        /// <summary>
        /// geeft alle Parts terug
        /// </summary>
        /// <returns>een lijst van alle Parts</returns>
        [HttpGet]
        public IEnumerable<PartDTO> GetParts()
        {
            return _partRepository.GetAll().Select(p =>
            {
                return new PartDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Functionality = p.Functionality.ToString(),
                    IsOptional = p.IsOptional,
                    DominantParts = p.DominantParts.Select(dp => dp.DominantPart.Name).ToList(),
                    DependantParts = p.DependantParts.Select(dp => dp.DependantPart.Name).ToList(),
                    BikeId = p.BikeParts.Select(b => b.BikeId).ToList()
                };
            });
        }
        /// <summary>
        /// geeft één Part terug, aan de hand van Id
        /// </summary>
        /// <param name="id">het Id van de Part</param>
        /// <returns>Eén Part</returns>
        [HttpGet("{id}")]
        public ActionResult<PartDTO> GetById(int id)
        {
            Part p = _partRepository.GetById(id);
            if (p == null)
            {
                return NotFound();
            }

            PartDTO partDTO = new PartDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Functionality = p.Functionality.ToString(),
                IsOptional = p.IsOptional,
                DominantParts = p.DominantParts.Select(dp => dp.DominantPart.Name).ToList(),
                DependantParts = p.DependantParts.Select(dp => dp.DependantPart.Name).ToList(),
                BikeId = p.BikeParts.Select(b => b.BikeId).ToList()
            };

            return Ok(partDTO);
            
        }

    }
}