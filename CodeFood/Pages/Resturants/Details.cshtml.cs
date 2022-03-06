using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeFood.Core;
using CodeFood.Data;

namespace CodeFood.Pages.Resturants
{
    public class DetailsModel : PageModel
    {
        public Resturant resturants { get; set; }
        public IResturantData Resturant { get; }
        [TempData]
        public string Message { get; set; }
        public DetailsModel(IResturantData resturant)
        {
            Resturant = resturant;
        }
        public IActionResult OnGet(int resturantId)
        {
            resturants = Resturant.GetResturantById(resturantId);
            if (resturants==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
