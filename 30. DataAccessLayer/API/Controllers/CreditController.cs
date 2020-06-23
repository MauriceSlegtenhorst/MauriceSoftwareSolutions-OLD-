﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.APILibrary;
using MTS.DataAcces.AccountAPI.Data;

namespace MTS.DataAcces.AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly MTSDataAccesAccountAPIContext _context;

        public CreditController(MTSDataAccesAccountAPIContext context)
        {
            _context = context;
        }

        // GET: api/Credit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credit>>> GetCredit()
        {
            return await _context.Credit.ToListAsync();
        }

        // GET: api/Credit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credit>> GetCredit(int id)
        {
            var credit = await _context.Credit.FindAsync(id);

            if (credit == null)
            {
                return NotFound();
            }

            return credit;
        }

        // PUT: api/Credit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredit(int id, Credit credit)
        {
            if (id != credit.Id)
            {
                return BadRequest();
            }

            _context.Entry(credit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditExists(id))
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

        // POST: api/Credit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Credit>> PostCredit(Credit credit)
        {
            _context.Credit.Add(credit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredit", new { id = credit.Id }, credit);
        }

        // DELETE: api/Credit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Credit>> DeleteCredit(int id)
        {
            var credit = await _context.Credit.FindAsync(id);
            if (credit == null)
            {
                return NotFound();
            }

            _context.Credit.Remove(credit);
            await _context.SaveChangesAsync();

            return credit;
        }

        private bool CreditExists(int id)
        {
            return _context.Credit.Any(e => e.Id == id);
        }
    }
}
