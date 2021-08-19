using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;


namespace Proyecto.Controllers
{
    [Route("Api")]
    public class UserController : Controller
    {
        private readonly Service _context;

        public UserController(Service context)
        {
            this._context = context;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUserById (int id)
        {
            var user = await _context.GetUserById(id);
            return user;
        }

        [HttpPost("Create")]
        public async Task<User> Create(User user)
        {
            var newUser = await _context.CreateAsync(user);
            await _context.SaveChangesAsync();
            return newUser;
        }

        [HttpGet("List")]
        public async Task<IEnumerable<User>> ToListAsync()
        {
            var userList = await _context.ListUsers();
            return userList;
        }
    }

}

