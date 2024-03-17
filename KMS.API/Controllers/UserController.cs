
using KMS.Api.Controllers;
using KMS.Application.Services.UserService;
using KMS.Common.Tools.Resource;
using KMS.Domain.Dto.Account;
using KMS.Domain.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        /// <summary>
        ///  دریافت کاربر با کد کاربر
        /// </summary>
        /// <returns>A list of users.</returns>
        /// 
        [HttpGet("GetById")]
        public IActionResult GetById(string Id)
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

                        data.ImagePath = ImagePath.GetUserAvatarPath(configuration, data.ImagePath);

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




        /// <summary>
        ///  تغییر پسورد توسط کاربر 
        /// </summary>
        /// <returns>A list of users.</returns>
        /// 
        [HttpPost("ChangePasswordByUser")]
        public IActionResult ChangePasswordByUser(UserChangePasswordDto model)
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





        /// <summary>
        /// ویرایش پروفایل توسط کاربر
        /// </summary>
        /// <returns>A list of users.</returns>
        /// 
        [HttpPost("EditUserProfile")]
        public IActionResult EditUserProfile(UserEditProfileDto model)
        {
            try
            {
                var isIdValid = Guid.TryParse(model.Id.ToString(), out Guid userId);
                if (!isIdValid) throw new Exception("Id is not valid Guid");

                var res = userService.EditUserProfile(model);
                res.ImagePath = ImagePath.GetUserAvatarPath(configuration, res.ImagePath);


                cache.Remove("GetById" + res.UserId);

                return Ok(ApiResponse.Response(res));

            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }



        /// <summary>
        /// ویرایش عکس پروفایل توسط کاربر
        /// </summary>
        /// <returns>A list of users.</returns>
        /// 
         [AllowAnonymous]
         [HttpPost("EditUserProfileImage")]
        public async Task<IActionResult> EditUserProfileImage( IFormFile file, string Id)
        {

            try
            {

                if (!Guid.TryParse(Id, out Guid userId)) throw new Exception("Id is not valid Guid");



                // Check if the file is not null
                if (file == null || file.Length == 0) throw new Exception("Invalid file.");


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
                res.ImagePath = ImagePath.GetUserAvatarPath(configuration, res.ImagePath);

                cache.Remove("GetById" + Id);

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
