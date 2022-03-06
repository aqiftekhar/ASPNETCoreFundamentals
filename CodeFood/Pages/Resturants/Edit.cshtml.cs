using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFood.Core;
using CodeFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Resturant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper)
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? resturantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (resturantId.HasValue)
            {
                Resturant = resturantData.GetResturantById(resturantId.Value);
            }
            else
            {
                Resturant = new Resturant();
            }
            

            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
            }

            if (Resturant.Id > 0)
            {
                resturantData.Update(Resturant);

            }
            else
            {
                resturantData.Add(Resturant);
            }


            resturantData.Commit();

            TempData["Message"] = "Resturant " + Resturant.Name + " Saved Successfully!";
            return RedirectToPage("./Details", new { resturantId = Resturant.Id });
        }
    }
}
