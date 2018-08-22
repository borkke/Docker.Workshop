using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notes.Data;
using Notes.Model;
using Notes.Services;

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
	    private readonly ILogger<NotesController> _logger;
	    private readonly NotesContext _context;
	    private readonly UserApiClient _userApiClient;

	    public NotesController(ILogger<NotesController> logger, NotesContext context, UserApiClient userApiClient)
	    {
		    _logger = logger;
		    _context = context;
		    _userApiClient = userApiClient;
		    _context.Database.EnsureCreated();

	    }

        // GET api/notes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
	        try
	        {
		        _logger.LogInformation("Getting Notes");
		        var notes = await _context.Notes.ToListAsync();
		        return Ok(notes);
	        }
	        catch (Exception e)
	        {
				_logger.LogError(e, "Failed to get Notes");
		        return BadRequest();
	        }
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
			try
			{
				_logger.LogInformation($"Getting Notes by id {id}");

				var note = await _context.Notes.FirstOrDefaultAsync(a => a.Id.Equals(id));
				var owner = await _userApiClient.GetById(note.OwnerId);

				var noteWithUser = new NotesWithUser(note)
				{
					FirstName = owner.FirstName,
					LastName = owner.LastName
				};
				return Ok(noteWithUser);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Failed to get Note by id {id}");
				return BadRequest();
			}
		}

        // POST api/notes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Note model)
        {
			try
			{
				_logger.LogInformation($"Creating Note {model.Text}");
				await _context.Notes.AddAsync(model);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Failed to create Note");
				return BadRequest();
			}
		}

        // PUT api/notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Note model)
        {
	        try
	        {
		        _logger.LogInformation($"Updating Note by id {id}");
		        _context.Notes.Update(model);
		        await _context.SaveChangesAsync();
				return Ok();
	        }
	        catch (Exception e)
	        {
		        _logger.LogError(e, $"Failed to update Note by id {id}");
				return BadRequest();
	        }
		}

        // DELETE api/notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
	        try
	        {
		        _logger.LogInformation($"Deleting Note by id {id}");
		        var note = await _context.Notes.FirstOrDefaultAsync(a => a.Id.Equals(id));
		        _context.Notes.Remove(note);
		        await _context.SaveChangesAsync();
				return Ok();
	        }
	        catch (Exception e)
	        {
		        _logger.LogError(e, $"Failed to delete Note by id {id}");
				return BadRequest();
	        }
		}
    }
}
