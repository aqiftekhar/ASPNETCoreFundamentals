using CodeFood.Core;
using CodeFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantsController : ControllerBase
    {
        private readonly CodeToFoodDbContext context;

        public ResturantsController(CodeToFoodDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ResturantsController>
        [HttpGet]
        public IEnumerable<Resturant> GetResturants()
        {
            return context.Resturants;
        }

        // GET api/<ResturantsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResturants([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resturant = await context.Resturants.FindAsync(id);
            if (resturant == null)
            {
                return NotFound();
            }
            return Ok(resturant);
        }

        // POST api/<ResturantsController>
        [HttpPost]
        public async Task<IActionResult> PostResturant([FromBody] Resturant resturant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Resturants.Add(resturant);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = resturant.Id }, resturant);
        }

        // PUT api/<ResturantsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant([FromRoute] int id, [FromBody] Resturant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<ResturantsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await context.Resturants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            context.Resturants.Remove(restaurant);
            await context.SaveChangesAsync();

            return Ok(restaurant);
        }
        private bool RestaurantExists(int id)
        {
            return context.Resturants.Any(e => e.Id == id);
        }
    }
}
