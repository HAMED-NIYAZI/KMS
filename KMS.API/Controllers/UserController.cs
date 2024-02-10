
using KMS.Api.Controllers;
using KMS.Application.Services.UserService;
using KMS.Domain.Dto.Account;
using KMS.Domain.Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace KMS.API.Controllers
{

    public class UserController : KmsBaseController
    {

        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;
        private readonly double cacheTimeOut;
        private readonly IUserService userService;
        public UserController(IMemoryCache cache, IConfiguration configuration, IUserService userService)
        {
            this.cache = cache;
            this.configuration = configuration;
            this.userService = userService;
            cacheTimeOut = int.Parse(this.configuration["CacheTimeOut"] ?? "60");

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






    }
}
