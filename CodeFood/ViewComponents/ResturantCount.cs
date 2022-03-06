using CodeFood.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFood.ViewComponents
{
    public class ResturantCount : ViewComponent
    {
        private readonly IResturantData resturantData;

        public ResturantCount(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public IViewComponentResult Invoke()
        {
            var count = resturantData.GetCountOfResturants();
            return View(count);
        }
    }
}
