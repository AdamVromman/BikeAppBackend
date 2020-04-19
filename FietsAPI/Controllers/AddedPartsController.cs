using System;
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
    public class AddedPartsController : ControllerBase
    {

        private readonly IAddedPartRepository _addedPartRepository;
        private readonly IPartRepository _partRepository;
        private readonly IBUserRepository _bUserRepository;

        public AddedPartsController(IAddedPartRepository addedPartRepository, IPartRepository partRepository, IBUserRepository bUserRepository)
        {
            _addedPartRepository = addedPartRepository;
            _partRepository = partRepository;
            _bUserRepository = bUserRepository;
        }

        [HttpGet]
        public IEnumerable<addedPartDTO> GetAddedParts()
        {
            return _addedPartRepository.GetAll().Select(ap =>
            {
                return new addedPartDTO
                {
                    name = ap.Name,
                    brand = ap.Brand,
                    price = ap.Price,
                    email = ap.BUser.Email,
                    link = ap.Link,
                    partId = ap.Part.Id

                };
            }
            );
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<string> AddAddedPart([FromBody]addedPartDTO addedPartDTO)
        {
            
            try
            {
                BUser user = _bUserRepository.GetByEmail(addedPartDTO.email);
                Part part = _partRepository.GetById(addedPartDTO.partId);

                if (user != null && part != null)
                {
                    _addedPartRepository.AddAddedPart(new AddedPart 
                    {
                        Name = addedPartDTO.name,
                        Brand = addedPartDTO.brand,
                        Price = addedPartDTO.price,
                        BUser = user,
                        Part = part,
                        Link = addedPartDTO.link
                    });
                    _addedPartRepository.SaveChanges();
                    return Ok(addedPartDTO.name);
                }
                return NotFound("This email address isn't know");

            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
            
        }


    }
}