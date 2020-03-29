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
        public IEnumerable<AddedPart> GetAddedParts()
        {
            return _addedPartRepository.GetAll();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<string> AddAddedPart(string name, string brand, Decimal price, int partId, string bUserEmail)
        {
            AddedPart addedPart = null;
            try
            {
                BUser user = _bUserRepository.GetByEmail(bUserEmail);
                Part part = _partRepository.GetById(partId);

                if (user != null && part != null)
                {
                     addedPart = new AddedPart
                    {
                        Name = name,
                        Brand = brand,
                        Price = price,
                        Part = part,
                        BUser = user
                    };
                        
                    _addedPartRepository.AddAddedPart(addedPart);
                        
                }
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(addedPart.Name);
        }


    }
}