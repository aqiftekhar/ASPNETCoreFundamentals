using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFood.Core;
using CodeFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CodeFood.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IResturantData resturant;

        public string Message { get; set; }
        public string Copyright { get; set; }
        public IEnumerable<Resturant> Resturants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerms { get; set; }

        public ListModel(IConfiguration configuration, IResturantData resturant)
        {
            this.configuration = configuration;
            this.resturant = resturant;
        }
        public void OnGet()
        {
            //this.Message = "Hello World";
            this.Message = configuration["Message"];
            this.Copyright = configuration["Copyright"];
            this.Resturants = resturant.GetResturantsByName(SearchTerms);
        }
    }
}
