﻿using FietsAPI.Models;
using FietsAPI.Models.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FietsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddedPartsController : ControllerBase
    {

        private readonly IAddedPartRepository _addedPartRepository;
        private readonly IPartRepository _partRepository;
        private readonly IBUserRepository _bUserRepository;
        private readonly IImageRepository _imageRepository;
        
        public AddedPartsController(IAddedPartRepository addedPartRepository, IPartRepository partRepository, IBUserRepository bUserRepository, IImageRepository imageRepository)
        {
            _addedPartRepository = addedPartRepository;
            _partRepository = partRepository;
            _bUserRepository = bUserRepository;
            _imageRepository = imageRepository;
        }
        /// <summary>
        /// geeft al de AddedParts terug
        /// </summary>
        /// <returns>all AddedParts</returns>
        [HttpGet]
        public IEnumerable<addedPartDTO> GetAddedParts()
        {
            return _addedPartRepository.GetAll().Select(ap =>
            {
                return new addedPartDTO
                {
                    id = ap.Id,
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
        /// <summary>
        /// voegt een addedPart toe, moet geauthorizeerd zijn daarvoor
        /// </summary>
        /// <param name="addedPartDTO">een AddedPartDTO</param>
        /// <returns>specifiek errorbericht</returns>
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
                   AddedPart addedPart =  _addedPartRepository.GetMostRecentByPartIdAndEmail(addedPartDTO.partId, addedPartDTO.email);
                    addedPartDTO.id = addedPart.Id;
                    return Ok(addedPartDTO);
                }
                return NotFound("This email address isn't know");

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Voegt een afbeelding toe aan een bestaande AddedPart. Wordt in de frontend automatisch gecalled na AddAddedPart. Kon niet op hetzelfde moment gebeuren omdat die Id pas gegenereerd wordt bij het opslaan in de databank.
        /// </summary>
        /// <param name="id">id van de part</param>
        /// <returns></returns>
        [HttpPost("addImage/{id}")]
        [AllowAnonymous]
        
        public ActionResult<String> AddImage(int id)
        {
            IFormFile files = Request.Form.Files[0];
            AddedPart part = _addedPartRepository.GetById(id);

            if (files != null)
            {
                MemoryStream ms = new MemoryStream();
                files.CopyTo(ms);
                Image image = new Image
                {
                    
                    ImageData = ms.ToArray(),
                    PartId = part.Id

                };
                _imageRepository.addImage(image);
                _imageRepository.saveChanges();
                   
                return Ok();
            }
            return BadRequest();

        }
        /// <summary>
        /// één afbeelding ophalen, via id van AddedPart
        /// </summary>
        /// <param name="id">id van AddedPart</param>
        /// <returns>één image</returns>
        [HttpGet("getImage/{id}")]
        [AllowAnonymous]
        public ActionResult<Image> GetImage(int id)
        {
            //Console.WriteLine(id);
            try
            {
                Image image = _imageRepository.GetById(id);
                ImageDTO imageDTO = new ImageDTO
                {
                    ImageData = image.ImageData,
                    PartId = image.PartId
                };
                return Ok(imageDTO);
            }
            catch
            {
                return Ok(null);
            }
           

            
        }
        /// <summary>
        /// geeft lijst van AddedParts terug, gefilterd op id van Part
        /// </summary>
        /// <param name="id">id van Part</param>
        /// <returns>Lijst van AdddedParts</returns>
        [HttpGet("getByPart/{id}")]
        [AllowAnonymous]
        public IEnumerable<addedPartDTO> getByPartId(int id)
        {
            try
            {
                return _addedPartRepository.GetByPartId(id).Select(ap =>
                {
                    addedPartDTO added = new addedPartDTO
                    {
                        id = ap.Id,
                        name = ap.Name,
                        brand = ap.Brand,
                        price = ap.Price,
                        email = ap.BUser.Email,
                        link = ap.Link,
                        partId = ap.Part.Id

                    };
                    return added;
                }

                    );
            }
            catch
            {
                return null;
            }
        }




    }
}