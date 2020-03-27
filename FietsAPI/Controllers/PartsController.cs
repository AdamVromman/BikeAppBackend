using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FietsAPI.Models;
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
        public IEnumerable<Part> GetParts()
        {
            return _partRepository.GetAll();
        }
        /// <summary>
        /// geeft één Part terug, aan de hand van Id
        /// </summary>
        /// <param name="id">het Id van de Part</param>
        /// <returns>Eén Part</returns>
        [HttpGet("{id}")]
        public ActionResult<Part> GetById(int id)
        {
            Part part = _partRepository.GetById(id);
            if (part == null)
            {
                return NotFound();
            }
            return Ok(part);
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public void AddPart(string name, string? description, Functionality? functionality, bool? isOptional, int[] dependantPartsId)
        {

        }

    }
}