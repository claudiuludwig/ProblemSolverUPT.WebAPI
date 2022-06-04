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
    public class UserController : ControllerBase
    {
        private readonly ProblemSolverUPTDatabaseContext _context;

        public UserController(ProblemSolverUPTDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.EmailAddress == id);
        }

        [HttpGet("{id}/role")]
        public string GetUserRole(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.EmailAddress == id);
            return user.Role;
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(string id, string password)
        //{
        //    var user = new User() { EmailAddress = id, Password = password };

        //    if (id != user.EmailAddress)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Users.Attach(user);
        //    _context.Entry(user).Property(x => x.Password).IsModified = true;


        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
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

        [HttpPut("{id}/password")]
        public async Task<IActionResult> PutUser(User user)
        {
            var usertoupdate = _context.Users.FirstOrDefault(u => u.EmailAddress == user.EmailAddress);

            if (!usertoupdate.EmailAddress.Contains(user.EmailAddress))
            {
                return BadRequest();
            }

            usertoupdate.Password = user.Password;
            _context.Users.Attach(usertoupdate);
            _context.Entry(usertoupdate).Property(x => x.Password).IsModified = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.EmailAddress))
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

        //[HttpPut("{id}/role")]
        //public async Task<IActionResult> PutUserRole(string id, string role)
        //{
        //    var user = new User() { EmailAddress = id, Role = role };

        //    if (id != user.EmailAddress)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Users.Attach(user);
        //    _context.Entry(user).Property(x => x.Role).IsModified = true;


        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
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

        [HttpPut("{id}/role")]
        public async Task<IActionResult> PutUserRole(User user)
        {
            var usertoupdate = _context.Users.FirstOrDefault(u => u.EmailAddress == user.EmailAddress);

            if (!usertoupdate.EmailAddress.Contains(user.EmailAddress))
            {
                return BadRequest();
            }

            usertoupdate.Role = user.Role;
            _context.Users.Attach(usertoupdate);
            _context.Entry(usertoupdate).Property(x => x.Role).IsModified = true;              

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.EmailAddress))
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

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.EmailAddress))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.EmailAddress }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.EmailAddress == id);
        }
    }
}
