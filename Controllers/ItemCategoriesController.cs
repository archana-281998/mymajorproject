using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFashion.Web.Data;
using EFashion.Web.Models;
using Microsoft.Extensions.Logging;

namespace EFashion.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ItemCategoriesController> _logger;

        public ItemCategoriesController(
            ApplicationDbContext context,
            ILogger<ItemCategoriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Categories
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        // {
        //      return await _context.Categories.ToListAsync();
        // }
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _context.ItemCategories.ToListAsync();

                if (categories == null)
                {
                    _logger.LogWarning("No Categories were found in the database");
                    return NotFound();
                }
                _logger.LogInformation("Extracted all the Categories from database");
                return Ok(categories);
            }
            catch
            {
                _logger.LogError("There was an attempt to retrieve information from the database");
                return BadRequest();
            }
        }


        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var category = await _context.ItemCategories.FindAsync(id);
                //var category = await _context.Categories
                //                             .Include(c => c.Books)
                //                             .SingleOrDefaultAsync(c => c.CategoryId == id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }



        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, ItemCategory category)
        {
            if (id != category.ItemCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostCategory(ItemCategory category)
        {
            // NOTE: NO LONGER NEEDED.  Refer to the <remarks> in the top of this Controller Class
            //if (! ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            try
            {
                _context.ItemCategories.Add(category);

                int countAffected = await _context.SaveChangesAsync();
                if (countAffected > 0)
                {
                    // Return the link to the newly inserted row 
                    var result = CreatedAtAction("GetCategory", new { id = category.ItemCategoryId }, category);
                    return Ok(result);

                    // NOTE: Return the HTTP RESPONSE CODE 201 "Created"
                    // Uri url;
                    // System.Uri.TryCreate($"~/api/Categories/{category.CategoryId}", UriKind.Relative, out url); 
                    // return Created(url, result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception exp)
            {
                ModelState.AddModelError("Post", exp.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            try
            {
                var category = await _context.ItemCategories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                _context.ItemCategories.Remove(category);
                await _context.SaveChangesAsync();

                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }


        private bool ItemCategoryExists(int id)
        {
            return _context.ItemCategories.Any(e => e.ItemCategoryId == id);
        }
    }
}
