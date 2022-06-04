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
    public class FeedbackCantinaController : ControllerBase
    {
        private readonly ProblemSolverUPTDatabaseContext _context;

        public FeedbackCantinaController(ProblemSolverUPTDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackCantina

        [HttpGet("date")]
        public IEnumerable<FeedbackCantina> GetFeedbackCantinasbyDate()
        {
            return _context.FeedbackCantinas.OrderByDescending(t => t.DataPostare).ThenByDescending(t => t.Id);
        }

        [HttpGet("status")]
        public IEnumerable<FeedbackCantina> GetFeedbackCantinasbyStatus()
        {
            return _context.FeedbackCantinas.OrderBy(t => t.Status).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("upvotes")]
        public IEnumerable<FeedbackCantina> GetFeedbackCantinasbyUpvotes()
        {
            return _context.FeedbackCantinas.OrderByDescending(t => t.Upvotes).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("downvotes")]
        public IEnumerable<FeedbackCantina> GetFeedbackCantinasbyDownvotes()
        {
            return _context.FeedbackCantinas.OrderByDescending(t => t.Downvotes).ThenByDescending(t => t.DataPostare);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<FeedbackCantina>>> GetFeedbackCantinas()
        //{
        //    return await _context.FeedbackCantinas.ToListAsync();
        //}

        // GET: api/FeedbackCantina/5
        [HttpGet("{id}")]
        public FeedbackCantina GetFeedbackCantina(int id)
        {
            return _context.FeedbackCantinas.FirstOrDefault(x => x.Id == id);
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<FeedbackCantina>> GetFeedbackCantina(int id)
        //{
        //    var feedbackCantina = await _context.FeedbackCantinas.FindAsync(id);

        //    if (feedbackCantina == null)
        //    {
        //        return NotFound();
        //    }

        //    return feedbackCantina;
        //}

        [HttpGet("{id}/upvotes")]
        public int GetFeedbackCantinaUpvotes(int id)
        {
            var feedbackcantina = _context.FeedbackCantinas.FirstOrDefault(t => t.Id == id);
            return (int)feedbackcantina.Upvotes;
        }

        //[HttpGet("{id}/upvotes")]
        //public async Task<ActionResult<int>> GetFeedbackCantinaUpvotes(int id)
        //{
        //    var feedbackcantina = await _context.GeneralProblems.FindAsync(id);

        //    if (feedbackcantina == null)
        //    {
        //        return NotFound();
        //    }

        //    return feedbackcantina.Upvotes;
        //}

        [HttpGet("{id}/downvotes")]
        public int GetFeedbackCantinaDownvotes(int id)
        {
            var feedbackcantina = _context.FeedbackCantinas.FirstOrDefault(t => t.Id == id);
            return (int)feedbackcantina.Downvotes;
        }

        //[HttpGet("{id}/downvotes")]
        //public async Task<ActionResult<int>> GetFeedbackCantinaDownvotes(int id)
        //{
        //    var feedbackcantina = await _context.GeneralProblems.FindAsync(id);

        //    if (feedbackcantina == null)
        //    {
        //        return NotFound();
        //    }

        //    return feedbackcantina.Downvotes;
        //}

        [HttpGet("{id}/status")]
        public string GetFeedbackCantinaStatus(int id)
        {
            var fcantina = _context.FeedbackCantinas.FirstOrDefault(t => t.Id == id);
            return (string)fcantina.Status;
        }

        [HttpGet("{id}/comentariu")]
        public string GetFeedbackCantinaComentariu(int id)
        {
            var fcantina = _context.FeedbackCantinas.FirstOrDefault(t => t.Id == id);
            return (string)fcantina.Comment;
        }

        // PUT: api/FeedbackCantina/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutFeedbackCantinaStatus(FeedbackCantina fcantina)
        {
            var fcantinatoupdate = _context.FeedbackCantinas.FirstOrDefault(u => u.Id == fcantina.Id);

            if (fcantinatoupdate.Id != fcantina.Id)
            {
                return BadRequest();
            }

            fcantinatoupdate.Status = fcantina.Status;
            _context.FeedbackCantinas.Attach(fcantinatoupdate);
            _context.Entry(fcantinatoupdate).Property(x => x.Status).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCantinaExists(fcantina.Id))
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
        //public async Task<IActionResult> PutFeedbackCantinaStatus(int id, string status)
        //{
        //    var feedbackcantina = await _context.FeedbackCantinas.FindAsync(id);

        //    if (id != feedbackcantina.Id)
        //    {
        //        return BadRequest();
        //    }

        //    feedbackcantina.Status = status;
        //    _context.FeedbackCantinas.Attach(feedbackcantina);
        //    _context.Entry(feedbackcantina).Property(x => x.Status).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FeedbackCantinaExists(id))
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
        public async Task<IActionResult> PutFeedbackCantinaComentariu(FeedbackCantina fcantina)
        {
            var fcantinatoupdate = _context.FeedbackCantinas.FirstOrDefault(u => u.Id == fcantina.Id);

            if (fcantinatoupdate.Id != fcantina.Id)
            {
                return BadRequest();
            }

            fcantinatoupdate.Comment = fcantina.Comment;
            _context.FeedbackCantinas.Attach(fcantinatoupdate);
            _context.Entry(fcantinatoupdate).Property(x => x.Comment).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCantinaExists(fcantina.Id))
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
        //public async Task<IActionResult> PutFeedbackCantinaComentariu(int id, string comentariu)
        //{
        //    var feedbackcantina = await _context.FeedbackCantinas.FindAsync(id);

        //    if (id != feedbackcantina.Id)
        //    {
        //        return BadRequest();
        //    }

        //    feedbackcantina.Comment = comentariu;
        //    _context.FeedbackCantinas.Attach(feedbackcantina);
        //    _context.Entry(feedbackcantina).Property(x => x.Comment).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FeedbackCantinaExists(id))
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
        public async Task<IActionResult> PutFeedbackCantinaUpvotes(FeedbackCantina fcantina)
        {
            var fcantinatoupdate = _context.FeedbackCantinas.FirstOrDefault(u => u.Id == fcantina.Id);

            if (fcantinatoupdate.Id != fcantina.Id)
            {
                return BadRequest();
            }

            fcantinatoupdate.Upvotes = fcantina.Upvotes;
            _context.FeedbackCantinas.Attach(fcantinatoupdate);
            _context.Entry(fcantinatoupdate).Property(x => x.Upvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCantinaExists(fcantina.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var feedbackcantina = await _context.FeedbackCantinas.FindAsync(id);

            //if (id != feedbackcantina.Id)
            //{
            //    return BadRequest();
            //}

            //feedbackcantina.Upvotes++;
            //_context.FeedbackCantinas.Attach(feedbackcantina);
            //_context.Entry(feedbackcantina).Property(x => x.Upvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FeedbackCantinaExists(id))
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
        public async Task<IActionResult> PutFeedbackCantinaDownvotes(FeedbackCantina fcantina)
        {
            var fcantinatoupdate = _context.FeedbackCantinas.FirstOrDefault(u => u.Id == fcantina.Id);

            if (fcantinatoupdate.Id != fcantina.Id)
            {
                return BadRequest();
            }

            fcantinatoupdate.Downvotes = fcantina.Downvotes;
            _context.FeedbackCantinas.Attach(fcantinatoupdate);
            _context.Entry(fcantinatoupdate).Property(x => x.Downvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCantinaExists(fcantina.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var feedbackcantina = await _context.FeedbackCantinas.FindAsync(id);

            //if (id != feedbackcantina.Id)
            //{
            //    return BadRequest();
            //}

            //feedbackcantina.Downvotes++;
            //_context.FeedbackCantinas.Attach(feedbackcantina);
            //_context.Entry(feedbackcantina).Property(x => x.Downvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FeedbackCantinaExists(id))
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

        // POST: api/FeedbackCantina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackCantina>> PostFeedbackCantina(FeedbackCantina feedbackCantina)
        {
            _context.FeedbackCantinas.Add(feedbackCantina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbackCantina", new { id = feedbackCantina.Id }, feedbackCantina);
        }

        // DELETE: api/FeedbackCantina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackCantina(int id)
        {
            var feedbackCantina = await _context.FeedbackCantinas.FindAsync(id);
            if (feedbackCantina == null)
            {
                return NotFound();
            }

            _context.FeedbackCantinas.Remove(feedbackCantina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackCantinaExists(int id)
        {
            return _context.FeedbackCantinas.Any(e => e.Id == id);
        }
    }
}
