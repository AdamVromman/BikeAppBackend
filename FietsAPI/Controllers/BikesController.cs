using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FietsAPI.Models;
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
        public IEnumerable<Bike> GetBikes()
        {
            return _bikeRepository.GetAll();
        }

    }
}