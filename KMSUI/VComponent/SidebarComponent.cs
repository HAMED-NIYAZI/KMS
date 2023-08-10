using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace KMSUI.VComponent
{
    [ViewComponent(Name = "Sidebar")]

    public class SidebarComponent : ViewComponent
    {
        
        //private readonly ISocialMediaService _socialMediaService;
        //private readonly IMemoryCache _memoryCache;

        //public CopyrightComponent(ISocialMediaService socialMediaService, IMemoryCache memoryCache)
        //{
        //    _socialMediaService = socialMediaService;
        //    _memoryCache = memoryCache;
        //}

        

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var cacheData = _memoryCache.Get("SocialMedia");
            //if (cacheData == null)
            //{
            //    var res = await _socialMediaService.GetAll();
            //    TempData["SocialMedia"] = res;
            //    _memoryCache.Set("SocialMedia", res, TimeSpan.FromMinutes(1000));
            //}
            //else
            //{
            //    TempData["SocialMedia"] = (List<SocialMediaViewModel>)cacheData;
            //}

            return await Task.FromResult<IViewComponentResult>(View("Sidebar"));


         }

    }
}
