using Microsoft.AspNetCore.Mvc;

namespace KMSUI.VComponent
{
    [ViewComponent(Name = "Footer")]

    public class FooterComponent:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {

            // ViewData["Data"] = "fffffffffffffffffffffffffff";
             return await Task.FromResult<IViewComponentResult>(View("Footer"));

        }

    }
}
