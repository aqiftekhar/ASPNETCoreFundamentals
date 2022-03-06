using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFood.Core;
using CodeFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeFood.Pages.Resturants
{
    public class DeleteModel : PageModel
    {
        private readonly IResturantData resturantData;

        public Resturant Resturant { get; set; }

        public DeleteModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturantData.GetResturantById(resturantId);
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int resturantId)
        {
            var resturant = resturantData.Delete(resturantId);
            resturantData.Commit();

            if (resturant == null)
            {
                RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{resturant.Name} deleted successfully!";
            return RedirectToPage("./List");
        }
    }
}
