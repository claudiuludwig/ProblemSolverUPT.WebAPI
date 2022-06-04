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
    public class FeedbackCamineController : ControllerBase
    {
        private readonly ProblemSolverUPTDatabaseContext _context;

        public FeedbackCamineController(ProblemSolverUPTDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackCamine

        [HttpGet("date")]
        public IEnumerable<FeedbackCamine> GetFeedbackCaminesbyDate()
        {
            return _context.FeedbackCamines.OrderByDescending(t => t.DataPostare).ThenByDescending(t => t.Id);
        }

        [HttpGet("status")]
        public IEnumerable<FeedbackCamine> GetFeedbackCaminesbyStatus()
        {
            return _context.FeedbackCamines.OrderBy(t => t.Status).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("upvotes")]
        public IEnumerable<FeedbackCamine> GetFeedbackCaminesbyUpvotes()
        {
            return _context.FeedbackCamines.OrderByDescending(t => t.Upvotes).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("downvotes")]
        public IEnumerable<FeedbackCamine> GetFeedbackCaminesbyDownvotes()
        {
            return _context.FeedbackCamines.OrderByDescending(t => t.Downvotes).ThenByDescending(t => t.DataPostare);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<FeedbackCamine>>> GetFeedbackCamines()
        //{
        //    return await _context.FeedbackCamines.ToListAsync();
        //}

        // GET: api/FeedbackCamine/5

        [HttpGet("{id}")]
        public FeedbackCamine GetFeedbackCamine(int id)
        {
            return _context.FeedbackCamines.FirstOrDefault(x => x.Id == id);
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<FeedbackCamine>> GetFeedbackCamine(int id)
        //{
        //    var feedbackCamine = await _context.FeedbackCamines.FindAsync(id);

        //    if (feedbackCamine == null)
        //    {
        //        return NotFound();
        //    }

        //    return feedbackCamine;
        //}

        [HttpGet("{id}/upvotes")]
        public int GetFeedbackCamineUpvotes(int id)
        {
            var feedbackcamine = _context.FeedbackCamines.FirstOrDefault(t => t.Id == id);
            return (int)feedbackcamine.Upvotes;
        }

        //[HttpGet("{id}/upvotes")]
        //public async Task<ActionResult<int>> GetFeedbackCamineUpvotes(int id)
        //{
        //    var feedbackcamine = await _context.GeneralProblems.FindAsync(id);

        //    if (feedbackcamine == null)
        //    {
        //        return NotFound();
        //    }

        //    return feedbackcamine.Upvotes;
        //}

        [HttpGet("{id}/downvotes")]
        public int GetFeedbackCamineDownvotes(int id)
        {
            var feedbackcamine = _context.FeedbackCamines.FirstOrDefault(t => t.Id == id);
            return (int)feedbackcamine.Downvotes;
        }

        //[HttpGet("{id}/downvotes")]
        //public async Task<ActionResult<int>> GetFeedbackCamineDownvotes(int id)
        //{
        //    var feedbackcamine = await _context.GeneralProblems.FindAsync(id);

        //    if (feedbackcamine == null)
        //    {
        //        return NotFound();
        //    }

        //    return (int)(feedbackcamine.Downvotes);
        //}

        [HttpGet("{id}/status")]
        public string GetFeedbackCamineStatus(int id)
        {
            var fcamine = _context.FeedbackCamines.FirstOrDefault(t => t.Id == id);
            return (string)fcamine.Status;
        }

        [HttpGet("{id}/comentariu")]
        public string GetFeedbackCamineComentariu(int id)
        {
            var fcamine = _context.FeedbackCamines.FirstOrDefault(t => t.Id == id);
            return (string)fcamine.Comment;
        }

        // PUT: api/FeedbackCamine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutFeedbackCamineStatus(FeedbackCamine fcamine)
        {
            var fcaminetoupdate = _context.FeedbackCamines.FirstOrDefault(u => u.Id == fcamine.Id);

            if (fcaminetoupdate.Id != fcamine.Id)
            {
                return BadRequest();
            }

            fcaminetoupdate.Status = fcamine.Status;
            _context.FeedbackCamines.Attach(fcaminetoupdate);
            _context.Entry(fcaminetoupdate).Property(x => x.Status).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCamineExists(fcamine.Id))
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
        //public async Task<IActionResult> PutFeedbackCamineStatus(int id, string status)
        //{
        //    var feedbackcamine = await _context.FeedbackCamines.FindAsync(id);
        //    if (id != feedbackcamine.Id)
        //    {
        //        return BadRequest();
        //    }
        //    feedbackcamine.Status = status;
        //    _context.FeedbackCamines.Attach(feedbackcamine);
        //    _context.Entry(feedbackcamine).Property(x => x.Status).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FeedbackCamineExists(id))
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
        public async Task<IActionResult> PutFeedbackCamineComentariu(FeedbackCamine fcamine)
        {
            var fcaminetoupdate = _context.FeedbackCamines.FirstOrDefault(u => u.Id == fcamine.Id);

            if (fcaminetoupdate.Id != fcamine.Id)
            {
                return BadRequest();
            }

            fcaminetoupdate.Comment = fcamine.Comment;
            _context.FeedbackCamines.Attach(fcaminetoupdate);
            _context.Entry(fcaminetoupdate).Property(x => x.Comment).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCamineExists(fcamine.Id))
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
        //public async Task<IActionResult> PutFeedbackCamineComentariu(int id, string comentariu)
        //{
        //    var feedbackcamine = await _context.FeedbackCamines.FindAsync(id);
        //    if (id != feedbackcamine.Id)
        //    {
        //        return BadRequest();
        //    }
        //    feedbackcamine.Comment = comentariu;
        //    _context.FeedbackCamines.Attach(feedbackcamine);
        //    _context.Entry(feedbackcamine).Property(x => x.Comment).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FeedbackCamineExists(id))
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
        public async Task<IActionResult> PutFeedbackCamineUpvotes(FeedbackCamine fcamine)
        {
            var fcaminetoupdate = _context.FeedbackCamines.FirstOrDefault(u => u.Id == fcamine.Id);

            if (fcaminetoupdate.Id != fcamine.Id)
            {
                return BadRequest();
            }

            fcaminetoupdate.Upvotes = fcamine.Upvotes;
            _context.FeedbackCamines.Attach(fcaminetoupdate);
            _context.Entry(fcaminetoupdate).Property(x => x.Upvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCamineExists(fcamine.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var feedbackcamine = await _context.FeedbackCamines.FindAsync(id);
            //if (id != feedbackcamine.Id)
            //{
            //    return BadRequest();
            //}
            //feedbackcamine.Upvotes++;
            //_context.FeedbackCamines.Attach(feedbackcamine);
            //_context.Entry(feedbackcamine).Property(x => x.Upvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FeedbackCamineExists(id))
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
        public async Task<IActionResult> PutFeedbackCamineDownvotes(FeedbackCamine fcamine)
        {
            var fcaminetoupdate = _context.FeedbackCamines.FirstOrDefault(u => u.Id == fcamine.Id);

            if (fcaminetoupdate.Id != fcamine.Id)
            {
                return BadRequest();
            }

            fcaminetoupdate.Downvotes = fcamine.Downvotes;
            _context.FeedbackCamines.Attach(fcaminetoupdate);
            _context.Entry(fcaminetoupdate).Property(x => x.Downvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCamineExists(fcamine.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var feedbackcamine = await _context.FeedbackCamines.FindAsync(id);
            //if (id != feedbackcamine.Id)
            //{
            //    return BadRequest();
            //}
            //feedbackcamine.Downvotes++;
            //_context.FeedbackCamines.Attach(feedbackcamine);
            //_context.Entry(feedbackcamine).Property(x => x.Downvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FeedbackCamineExists(id))
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

        // POST: api/FeedbackCamine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackCamine>> PostFeedbackCamine(FeedbackCamine feedbackCamine)
        {
            _context.FeedbackCamines.Add(feedbackCamine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbackCamine", new { id = feedbackCamine.Id }, feedbackCamine);
        }

        // DELETE: api/FeedbackCamine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackCamine(int id)
        {
            var feedbackCamine = await _context.FeedbackCamines.FindAsync(id);
            if (feedbackCamine == null)
            {
                return NotFound();
            }

            _context.FeedbackCamines.Remove(feedbackCamine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackCamineExists(int id)
        {
            return _context.FeedbackCamines.Any(e => e.Id == id);
        }
    }
}
