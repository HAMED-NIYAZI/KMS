﻿
using KMS.Api.Controllers;
using KMS.Application.Services.UserService;
using KMS.Domain.Dto.Account;
using KMS.Domain.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace KMS.API.Controllers
{
    [Authorize]
    public class UserController : KmsBaseController
    {

        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;
        private readonly double cacheTimeOut;
        private readonly IUserService userService;
        private readonly IWebHostEnvironment hostingEnvironment;
        public UserController(IMemoryCache cache, IConfiguration configuration, IUserService userService, IWebHostEnvironment hostingEnvironment)
        {
            this.cache = cache;
            this.configuration = configuration;
            this.userService = userService;
            cacheTimeOut = int.Parse(this.configuration["CacheTimeOut"] ?? "60");
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
                var isIdValid = Guid.TryParse(Id, out Guid userId);
                if (!isIdValid) throw new Exception("Id is not valid Guid");

                string cacheKey = "GetById" + Id;
                if (!cache.TryGetValue(cacheKey, out UserProfileDto data))
                {
                    data = userService.GetById(userId);
                    if (data != null)
                    {
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheTimeOut));

                        data.ImagePath = (data.ImagePath == string.Empty || data.ImagePath == null) ? string.Empty : configuration["UserAvatar"] + data.ImagePath;

                        cache.Set(cacheKey, data, cacheEntryOptions);
                    }
                }
                return Ok(ApiResponse.Response(data));

            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }

        }


        [HttpPost("ChangePasswordByUser")]
        public async Task<IActionResult> ChangePasswordByUser(UserChangePasswordDto model)
        {
            try
            {
                var isIdValid = Guid.TryParse(model.Id.ToString(), out Guid userId);
                if (!isIdValid) throw new Exception("Id is not valid Guid");

                var res = userService.ChangePasswordByUser(model);

                return Ok(ApiResponse.Response(res));

            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }

        }


        [HttpPost("EditUserProfile")]
        public async Task<IActionResult> EditUserProfile(UserEditProfileDto model)
        {
            try
            {
                var isIdValid = Guid.TryParse(model.Id.ToString(), out Guid userId);
                if (!isIdValid) throw new Exception("Id is not valid Guid");


                var res = userService.EditUserProfile(model);
                return Ok(ApiResponse.Response(res));

            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        [HttpPost("EditUserProfileImage/{Id}")]
        public async Task<IActionResult> Post(IFormFile file, string Id)
        {
            try
            {
                if (!Guid.TryParse(Id, out Guid userId))
                {
                    throw new Exception("Id is not valid Guid");
                }

                // Check if the file is not null
                if (file == null || file.Length == 0)
                {
                    throw new Exception("Invalid file.");
                }

                // Define the path where the file will be saved
                string folderName = Path.Combine("Src/Img/User/Avatar");
                string webRootPath = hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);

                // Ensure the directory exists
                Directory.CreateDirectory(newPath);

                // Generate a unique file name
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(newPath, fileName);

                // Save the file to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var res = userService.EditUserProfileImage(userId, fileName);


                // Return a success message
                return Ok(ApiResponse.Response(res));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }
    }
}
