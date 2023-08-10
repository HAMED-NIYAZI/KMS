using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace KMSUI.VComponent
{
    [ViewComponent(Name = "MainSlider")]
    public class MainSliderComponent : ViewComponent
    {
        //private readonly ISliderService sliderService;
        //private readonly IMemoryCache memoryCache;

        //public MainSliderComponent(ISliderService sliderService, IMemoryCache memoryCache)
        //{
        //    this.sliderService = sliderService;
        //    this.memoryCache = memoryCache;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var cacheData = memoryCache.Get("MainSlider");
            //if (cacheData == null)
            //{
            //    var res = await sliderService.GetAll();
            //    cacheData = res;
            //    memoryCache.Set("MainSlider", res, TimeSpan.FromMinutes(1000));
            //}
            //else
            //{
            //}

            //return View("MainSlider", (List<SliderViewModel>?)cacheData);
             return await Task.FromResult<IViewComponentResult>(View("MainSlider"));


        }

    }
}
