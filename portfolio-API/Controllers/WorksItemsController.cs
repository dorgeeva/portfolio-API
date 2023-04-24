﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio_API.Models;

namespace portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksItemsController : ControllerBase
    {
        private readonly WorksContext _context;

        public WorksItemsController(WorksContext context)
        {
            _context = context;
        }

        // GET: api/WorksItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorksItem>>> GetWorksItems()
        {
          if (_context.WorksItems == null)
          {
              return NotFound();
          }
            return await _context.WorksItems.ToListAsync();
        }

        // GET: api/WorksItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorksItem>> GetWorksItem(long id)
        {
          if (_context.WorksItems == null)
          {
              return NotFound();
          }
            var worksItem = await _context.WorksItems.FindAsync(id);

            if (worksItem == null)
            {
                return NotFound();
            }

            return worksItem;
        }

        // PUT: api/WorksItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorksItem(long id, WorksItem worksItem)
        {
            if (id != worksItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(worksItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorksItemExists(id))
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

        // POST: api/WorksItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorksItem>> PostWorksItem(WorksItem worksItem)
        {
            _context.WorksItems.Add(worksItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWorksItem), new { id = worksItem.Id }, worksItem);
        }

        // DELETE: api/WorksItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorksItem(long id)
        {
            if (_context.WorksItems == null)
            {
                return NotFound();
            }
            var worksItem = await _context.WorksItems.FindAsync(id);
            if (worksItem == null)
            {
                return NotFound();
            }

            _context.WorksItems.Remove(worksItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorksItemExists(long id)
        {
            return (_context.WorksItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
