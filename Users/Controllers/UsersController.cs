using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Users.Data;
using Users.Model;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
	{
		private readonly ILogger<UsersController> _logger;
		private readonly UsersContext _context;

		public UsersController(ILogger<UsersController> logger, UsersContext context)
		{
			_logger = logger;
			_context = context;
			_context.Database.EnsureCreated();
		}

        // GET api/Users
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				_logger.LogInformation("Getting Users");
				var users = await _context.Users.ToListAsync();
				return Ok(users);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Failed to get Users");
				return BadRequest();
			}
		}

		// GET api/Users/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				_logger.LogInformation($"Getting Users by id {id}");
				var user = await _context.Users.FirstOrDefaultAsync(a => a.Id.Equals(id));
				return Ok(user);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Failed to get Users by id {id}");
				return BadRequest();
			}
		}

		// POST api/Users
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] User model)
		{
			try
			{
				_logger.LogInformation($"Creating Users {model.FirstName}");
				await _context.Users.AddAsync(model);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Failed to create Users");
				return BadRequest();
			}
		}

		// PUT api/Users/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] User model)
		{
			try
			{
				_logger.LogInformation($"Updating Users by id {id}");
				_context.Users.Update(model);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Failed to update Users by id {id}");
				return BadRequest();
			}
		}

		// DELETE api/Users/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				_logger.LogInformation($"Deleting Users by id {id}");
				var Users = await _context.Users.FirstOrDefaultAsync(a => a.Id.Equals(id));
				_context.Users.Remove(Users);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Failed to delete Users by id {id}");
				return BadRequest();
			}
		}
	}
}
