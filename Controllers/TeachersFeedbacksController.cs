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
    public class TeachersFeedbacksController : ControllerBase
    {
        private readonly ProblemSolverUPTDatabaseContext _context;

        public TeachersFeedbacksController(ProblemSolverUPTDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TeachersFeedbacks
        [HttpGet("date")]
        public IEnumerable<TeachersFeedback> GetTeachersFeedbacksbyDate()
        {
            return _context.TeachersFeedbacks.OrderByDescending(t=>t.DataPostare).ThenByDescending(t=>t.Id);
        }

        [HttpGet("status")]
        public IEnumerable<TeachersFeedback> GetTeachersFeedbacksbyStatus()
        {
            return _context.TeachersFeedbacks.OrderBy(t => t.Status).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("upvotes")]
        public IEnumerable<TeachersFeedback> GetTeachersFeedbacksbyUpvotes()
        {
            return _context.TeachersFeedbacks.OrderByDescending(t => t.Upvotes).ThenByDescending(t => t.DataPostare);
        }

        [HttpGet("downvotes")]
        public IEnumerable<TeachersFeedback> GetTeachersFeedbacksbyDownvotes()
        {
            return _context.TeachersFeedbacks.OrderByDescending(t => t.Downvotes).ThenByDescending(t => t.DataPostare);
        }

        // GET: api/TeachersFeedbacks/5

        [HttpGet("{id}")]
        public TeachersFeedback GetTeachersFeedback(int id)
        {
            return _context.TeachersFeedbacks.FirstOrDefault(t => t.Id == id);
        }

        [HttpGet("{id}/upvotes")]
        public int GetTeachersFeedbackUpvotes(int id)
        {
            var teachersFeedback = _context.TeachersFeedbacks.FirstOrDefault(t => t.Id == id);
            return (int)teachersFeedback.Upvotes;
        }

        [HttpGet("{id}/downvotes")]
        public int GetTeachersFeedbackDownvotes(int id)
        {
            var teachersFeedback = _context.TeachersFeedbacks.FirstOrDefault(t => t.Id == id);
            return (int)teachersFeedback.Downvotes;
        }

        [HttpGet("{id}/status")]
        public string GetTeacherFeedbackStatus(int id)
        {
            var teachersFeedback = _context.TeachersFeedbacks.FirstOrDefault(t => t.Id == id);
            return (string)teachersFeedback.Status;
        }

        [HttpGet("{id}/comentariu")]
        public string GetTeacherFeedbackComment(int id)
        {
            var teachersFeedback = _context.TeachersFeedbacks.FirstOrDefault(t => t.Id == id);
            return (string)teachersFeedback.Comment;
        }

        // PUT: api/TeachersFeedbacks/5
        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutTeachersFeedbackStatus(TeachersFeedback tfeedback)
        {
            var tfeedbackupdate = _context.TeachersFeedbacks.FirstOrDefault(u => u.Id == tfeedback.Id);

            if (tfeedbackupdate.Id != tfeedback.Id)
            {
                return BadRequest();
            }

            tfeedbackupdate.Status = tfeedback.Status;
            _context.TeachersFeedbacks.Attach(tfeedbackupdate);
            _context.Entry(tfeedbackupdate).Property(x => x.Status).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersFeedbackExists(tfeedback.Id))
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
        //public async Task<IActionResult> PutTeachersFeedbackStatus(int id, string status)
        //{
        //    var teachersfeedback = await _context.TeachersFeedbacks.FindAsync(id);
        //    if (id != teachersfeedback.Id)
        //    {
        //        return BadRequest();
        //    }

        //    teachersfeedback.Status = status;
        //    _context.TeachersFeedbacks.Attach(teachersfeedback);
        //    _context.Entry(teachersfeedback).Property(x => x.Status).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeachersFeedbackExists(id))
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
        public async Task<IActionResult> PutTeachersFeedbackComentariu(TeachersFeedback tfeedback)
        {
            var tfeedbackupdate = _context.TeachersFeedbacks.FirstOrDefault(u => u.Id == tfeedback.Id);

            if (tfeedbackupdate.Id != tfeedback.Id)
            {
                return BadRequest();
            }

            tfeedbackupdate.Comment = tfeedback.Comment;
            _context.TeachersFeedbacks.Attach(tfeedbackupdate);
            _context.Entry(tfeedbackupdate).Property(x => x.Comment).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersFeedbackExists(tfeedback.Id))
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
        //public async Task<IActionResult> PutTeachersFeedbackComentariu(int id, string comentariu)
        //{
        //    var teachersfeedback = await _context.TeachersFeedbacks.FindAsync(id);
        //    if (id != teachersfeedback.Id)
        //    {
        //        return BadRequest();
        //    }

        //    teachersfeedback.Comment = comentariu;
        //    _context.TeachersFeedbacks.Attach(teachersfeedback);
        //    _context.Entry(teachersfeedback).Property(x => x.Comment).IsModified = true;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeachersFeedbackExists(id))
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
        public async Task<IActionResult> PutTeachersFeedbackUpvotes(TeachersFeedback tfeedback)
        {
            var tfeedbackupdate = _context.TeachersFeedbacks.FirstOrDefault(u => u.Id == tfeedback.Id);

            if (tfeedbackupdate.Id != tfeedback.Id)
            {
                return BadRequest();
            }

            tfeedbackupdate.Upvotes = tfeedback.Upvotes;
            _context.TeachersFeedbacks.Attach(tfeedbackupdate);
            _context.Entry(tfeedbackupdate).Property(x => x.Upvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersFeedbackExists(tfeedback.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var teachersfeedback = await _context.TeachersFeedbacks.FindAsync(id);
            //if (id != teachersfeedback.Id)
            //{
            //    return BadRequest();
            //}

            //teachersfeedback.Upvotes++;
            //_context.TeachersFeedbacks.Attach(teachersfeedback);
            //_context.Entry(teachersfeedback).Property(x => x.Upvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TeachersFeedbackExists(id))
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
        public async Task<IActionResult> PutTeachersFeedbackDownvotes(TeachersFeedback tfeedback)
        {
            var tfeedbackupdate = _context.TeachersFeedbacks.FirstOrDefault(u => u.Id == tfeedback.Id);

            if (tfeedbackupdate.Id != tfeedback.Id)
            {
                return BadRequest();
            }

            tfeedbackupdate.Downvotes = tfeedback.Downvotes;
            _context.TeachersFeedbacks.Attach(tfeedbackupdate);
            _context.Entry(tfeedbackupdate).Property(x => x.Downvotes).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersFeedbackExists(tfeedback.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //var teachersfeedback = await _context.TeachersFeedbacks.FindAsync(id);
            //if (id != teachersfeedback.Id)
            //{
            //    return BadRequest();
            //}

            //teachersfeedback.Downvotes++;
            //_context.TeachersFeedbacks.Attach(teachersfeedback);
            //_context.Entry(teachersfeedback).Property(x => x.Downvotes).IsModified = true;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TeachersFeedbackExists(id))
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

        // POST: api/TeachersFeedbacks
        [HttpPost]
        public async Task<ActionResult<TeachersFeedback>> PostTeachersFeedbacks(TeachersFeedback tfeedback)
        {
            _context.TeachersFeedbacks.Add(tfeedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeachersFeedback", new { id = tfeedback.Id }, tfeedback);
        }

        // DELETE: api/TeachersFeedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachersFeedback(int id)
        {
            var teachersFeedback = await _context.TeachersFeedbacks.FindAsync(id);
            if (teachersFeedback == null)
            {
                return NotFound();
            }

            _context.TeachersFeedbacks.Remove(teachersFeedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachersFeedbackExists(int id)
        {
            return _context.TeachersFeedbacks.Any(e => e.Id == id);
        }
    }
}
