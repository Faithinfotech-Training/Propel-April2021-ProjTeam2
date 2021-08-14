using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iLearn.Models;

namespace iLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly MainProjectContext _context;

        public CourseController(MainProjectContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public IEnumerable<Coursemain> GetCoursemain()
        {
            return _context.Coursemain;
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoursemain([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coursemain = await _context.Coursemain.FindAsync(id);

            if (coursemain == null)
            {
                return NotFound();
            }

            return Ok(coursemain);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoursemain([FromRoute] int id, [FromBody] Coursemain coursemain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coursemain.Courseid)
            {
                return BadRequest();
            }

            _context.Entry(coursemain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursemainExists(id))
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

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> PostCoursemain([FromBody] Coursemain coursemain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coursemain.Add(coursemain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoursemain", new { id = coursemain.Courseid }, coursemain);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoursemain([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coursemain = await _context.Coursemain.FindAsync(id);
            if (coursemain == null)
            {
                return NotFound();
            }

            _context.Coursemain.Remove(coursemain);
            await _context.SaveChangesAsync();

            return Ok(coursemain);
        }

        private bool CoursemainExists(int id)
        {
            return _context.Coursemain.Any(e => e.Courseid == id);
        }
    }
}