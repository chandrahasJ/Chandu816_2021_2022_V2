using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BRHomeWebApi.Dtos;
using BRHomeWebApi.Models;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRHomeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;

        public PropertyController(IUnitOfWork uow, IMapper mapper, IPhotoService photoService)
        {
            this.photoService = photoService;
            this._uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetProperties(int sellRent)
        {
            var properties = await _uow.propertyRepository.GetProperties(sellRent);
            var propertiesDto = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertiesDto);
        }

        [HttpGet("details/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetPropertyDetails(int id)
        {
            var property = await _uow.propertyRepository.GetPropertyDetails(id);
            var propertyDetailsDto = mapper.Map<PropertyDetailsDto>(property);
            return Ok(propertyDetailsDto);
        }

        [HttpPost("add/")]
        [Authorize]
        public async Task<ActionResult> AddPropertyDetails(PropertyDto propertyDto)
        {
            Property property = mapper.Map<Property>(propertyDto);
            var userid = GetUserId();
            property.PostedBy = userid;
            property.PostedOn = DateTime.Now;
            property.LastUpdatedBy = userid;
            _uow.propertyRepository.AddProperty(property);
            await _uow.SaveAsync();

            return StatusCode(201);
        }

        [HttpPost("add/photo/{id}")]
        [Authorize]
        public async Task<ActionResult> AddPropertyPhoto(IFormFile formFile, int id)
        {
            var result = await photoService.UploadPhotoAsync(formFile);
            if(result.Error != null)
                return BadRequest(result.Error.Message);

            var property = await _uow.propertyRepository.GetPropertyDetailsById(id);

            var photo = new Photo(){
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            if (property.Photos.Count == 0){
                photo.IsPrimary = true;
            }

            property.Photos.Add(photo);
            await _uow.SaveAsync();

            return StatusCode(201);
        }

        [HttpPost("set-primary-photo/photo/{id}/{publicPhotoId}")]
        [Authorize]
        public async Task<ActionResult> SetPrimaryPhoto(int id, string publicPhotoId)
        {
             var userId = GetUserId();

            var property = await _uow.propertyRepository.GetPropertyDetailsById(id);

            if(property == null)
                return BadRequest("No such property or photo exists.");

            if(property.PostedBy != userId)
                return BadRequest("You are not authorized to change the photo.");

            var photo = property.Photos.FirstOrDefault(p => p.PublicId == publicPhotoId);

            if(photo == null) return BadRequest("No such property exists.");

            if(photo.IsPrimary) return BadRequest("This photo is already primary");

            var currentPrimary = property.Photos.FirstOrDefault(p => p.IsPrimary);
            if(currentPrimary != null) currentPrimary.IsPrimary = false;
            photo.IsPrimary = true;

            if(await _uow.SaveAsync()) return NoContent();  

            return StatusCode(201);
        }
    }
}