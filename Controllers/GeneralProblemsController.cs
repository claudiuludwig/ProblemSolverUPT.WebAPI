using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProblemSolverUPT.WebAPI.Models;

namespace ProblemSolverUPT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralProblemsController : ControllerBase
    {
        private readonly ProblemSolverUPTDatabaseContext _context;

        public GeneralProblemsController(ProblemSolverUPTDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/GeneralProblems
        [HttpGet("date")]
        public IEnumerable<GeneralProblem> GetGeneralProblemsbyDate()
        {
            return _context.GeneralProblems.OrderByDescending(t => t.DataPostare).ThenByDescending(t => t.Id);
        }

        [HttpGet("status")]
        public IEnumerable<GeneralProblem> GetGeneralProblemsbyStatus()
        {
            return _context.GeneralProblems.OrderBy(t => t.Status).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("upvotes")]
        public IEnumerable<GeneralProblem> GetGeneralProblemsbyUpvotes()
        {
            return _context.GeneralProblems.OrderByDescending(t => t.Upvotes).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("downvotes")]
        public IEnumerable<GeneralProblem> GetGeneralProblemsbyDownvotes()
        {
            return _context.GeneralProblems.OrderByDescending(t => t.Downvotes).ThenByDescending(t => t.DataPostare);
        }


        // GET: api/GeneralProblems/5
        [HttpGet("{id}")]
        public GeneralProblem GetGeneralProblem(int id)
        {
            return _context.GeneralProblems.FirstOrDefault(g => g.Id == id);
        }

        [HttpGet("{id}/upvotes")]
        public int GetGeneralProblemUpvotes(int id)
        {
            var generalProblem = _context.GeneralProblems.FirstOrDefault(t => t.Id == id);
            return (int)generalProblem.Upvotes;
        }

        [HttpGet("{id}/downvotes")]
        public int GetGeneralProblemDownvotes(int id)
        {
            var generalProblem = _context.GeneralProblems.FirstOrDefault(t => t.Id == id);
            return (int)generalProblem.Downvotes;
        }

        [HttpGet("{id}/status")]
        public string GetGeneralProblemStatus(int id)
        {
            var gproblem = _context.GeneralProblems.FirstOrDefault(t => t.Id == id);
            return (string)gproblem.Status;
        }

        [HttpGet("{id}/comentariu")]
        public string GetGeneralProblemComment(int id)
        {
            var gproblem = _context.GeneralProblems.FirstOrDefault(t => t.Id == id);
            return (string)gproblem.Comment;
        }

        // PUT: api/GeneralProblems/5

        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutGeneralProblemStatus(GeneralProblem gproblem)
        {
            var gproblemtoupdate = _context.GeneralProblems.FirstOrDefault(u => u.Id == gproblem.Id);

            if (gproblemtoupdate.Id != gproblem.Id)
            {
                return BadRequest();
            }

            gproblemtoupdate.Status = gproblem.Status;
            _context.GeneralProblems.Attach(gproblemtoupdate);
            _context.Entry(gproblemtoupdate).Property(x => x.Status).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralProblemExists(gproblem.Id))
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

        //[HttpPut("{id}/status")]
        //public async Task<IActionResult> PutGeneralProblemStatus(int id, string status)
        //{
        //    var generalProblem = await _context.GeneralProblems.FindAsync(id);

        //    if (id != generalProblem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    generalProblem.Status = status;
        //    _context.GeneralProblems.Attach(generalProblem);
        //    _context.Entry(generalProblem).Property(x => x.Status).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GeneralProblemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpPut("{id}/comentariu")]
        public async Task<IActionResult> PutGeneralProblemComentariu(GeneralProblem gproblem)
        {
            var gproblemtoupdate = _context.GeneralProblems.FirstOrDefault(u => u.Id == gproblem.Id);

            if (gproblemtoupdate.Id != gproblem.Id)
            {
                return BadRequest();
            }

            gproblemtoupdate.Comment = gproblem.Comment;
            _context.GeneralProblems.Attach(gproblemtoupdate);
            _context.Entry(gproblemtoupdate).Property(x => x.Comment).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralProblemExists(gproblem.Id))
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

        //[HttpPut("{id}/comentariu")]
        //public async Task<IActionResult> PutGeneralProblemComentariu(int id, string comentariu)
        //{
        //    var generalProblem = await _context.GeneralProblems.FindAsync(id);

        //    if (id != generalProblem.Id)
        //    {
        //        return BadRequest();
        //    }
        //    generalProblem.Comment=comentariu;
        //    _context.GeneralProblems.Attach(generalProblem);
        //    _context.Entry(generalProblem).Property(x => x.Comment).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GeneralProblemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpPut("{id}/upvotes")]
        public async Task<IActionResult> PutGeneralProblemUpvotes(GeneralProblem gproblem)
        {
            var gproblemtoupdate = _context.GeneralProblems.FirstOrDefault(u => u.Id == gproblem.Id);

            if (gproblemtoupdate.Id != gproblem.Id)
            {
                return BadRequest();
            }

            gproblemtoupdate.Upvotes = gproblem.Upvotes;
            _context.GeneralProblems.Attach(gproblemtoupdate);
            _context.Entry(gproblemtoupdate).Property(x => x.Upvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralProblemExists(gproblem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var generalProblem = await _context.GeneralProblems.FindAsync(id);

            //if (id != generalProblem.Id)
            //{
            //    return BadRequest();
            //}
            //generalProblem.Upvotes++;
            //_context.GeneralProblems.Attach(generalProblem);
            //_context.Entry(generalProblem).Property(x => x.Upvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GeneralProblemExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        [HttpPut("{id}/downvotes")]
        public async Task<IActionResult> PutGeneralProblemDownvotes(GeneralProblem gproblem)
        {
            var gproblemtoupdate = _context.GeneralProblems.FirstOrDefault(u => u.Id == gproblem.Id);

            if (gproblemtoupdate.Id != gproblem.Id)
            {
                return BadRequest();
            }

            gproblemtoupdate.Downvotes = gproblem.Downvotes;
            _context.GeneralProblems.Attach(gproblemtoupdate);
            _context.Entry(gproblemtoupdate).Property(x => x.Downvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralProblemExists(gproblem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var generalProblem = await _context.GeneralProblems.FindAsync(id);

            //if (id != generalProblem.Id)
            //{
            //    return BadRequest();
            //}
            //generalProblem.Downvotes++;
            //_context.GeneralProblems.Attach(generalProblem);
            //_context.Entry(generalProblem).Property(x => x.Downvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GeneralProblemExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/GeneralProblems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneralProblem>> PostGeneralProblem(GeneralProblem generalProblem)
        {
            _context.GeneralProblems.Add(generalProblem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralProblem", new { id = generalProblem.Id }, generalProblem);
        }

        // DELETE: api/GeneralProblems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralProblem(int id)
        {
            var generalProblem = await _context.GeneralProblems.FindAsync(id);
            if (generalProblem == null)
            {
                return NotFound();
            }

            _context.GeneralProblems.Remove(generalProblem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneralProblemExists(int id)
        {
            return _context.GeneralProblems.Any(e => e.Id == id);
        }
    }
}
