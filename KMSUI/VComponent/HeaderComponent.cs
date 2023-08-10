using Microsoft.AspNetCore.Mvc;

namespace KMSUI.VComponent
{
    [ViewComponent(Name = "Header")]
    public class HeaderComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {

             return await Task.FromResult<IViewComponentResult>(View("Header"));

        }

    }
}
