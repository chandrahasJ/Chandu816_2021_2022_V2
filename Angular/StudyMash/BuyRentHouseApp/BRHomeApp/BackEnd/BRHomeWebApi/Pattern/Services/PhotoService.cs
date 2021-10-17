using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRHomeWebApi.Pattern.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BRHomeWebApi.Pattern.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IConfiguration configuration;
        private readonly Cloudinary cloudinary;

        public PhotoService(IConfiguration configuration)
        {
            this.configuration = configuration;
            Account account = new Account(){
                ApiKey = configuration.GetSection("CloudinarySettings:CloudAPIKey").Value,
                ApiSecret = configuration.GetSection("CloudinarySettings:CloudSecret").Value,
                Cloud = configuration.GetSection("CloudinarySettings:CloudName").Value
            };
            cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo)
        {
            var uploadResult = new ImageUploadResult();
            if(photo.Length > 0){
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams(){
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(800)
                };
                uploadResult =await cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }
    }
}