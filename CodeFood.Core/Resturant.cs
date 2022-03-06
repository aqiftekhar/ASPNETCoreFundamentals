using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFood.Core
{
    public class Resturant
    {
        public int Id { get; set; }
        [Required, MaxLength(80)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
