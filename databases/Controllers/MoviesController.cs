using Microsoft.AspNetCore.Mvc;
using databases.Data;
using Microsoft.EntityFrameworkCore;
using databases.Entities;
using databases.Dtos;
namespace databases.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<MoviesController> _logger;

    public MoviesController(
        ILogger<MoviesController> logger,
        AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Movies.ToListAsync());
    }

 
    [HttpPost]
    public async Task<IActionResult> Create ([FromForm]Dtos.DtosMovie movie)
    {
        var entity = new Movie()
        {
            Id = Guid.NewGuid(),
            Title = movie.Title,
            ReleaseData = movie.ReleaseData,
            Genre = movie.Genre switch
            {
                Dtos.DtosEGenre.Action => EGenre.Action,
                Dtos.DtosEGenre.Horror => EGenre.Horror,
                Dtos.DtosEGenre.Comedy => EGenre.Comedy,
                Dtos.DtosEGenre.Thriller => EGenre.Thriller,
                Dtos.DtosEGenre.Romance => EGenre.Romance,
                Dtos.DtosEGenre.History => EGenre.History,
                Dtos.DtosEGenre.SiFi => EGenre.SiFi,
            },
            Description = movie.Description,
            Imdb = movie.Imdb,
            };

        await _context.Movies.AddAsync(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Create),movie);
    }
   
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        return Ok(await _context.Movies.FirstOrDefaultAsync(s => s.Id == id));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] Guid id)
    {
        var entity = await _context.Movies.FindAsync(id);
        if (entity is null)
            return NotFound();

        _context.Movies.Remove(entity);
        await _context.SaveChangesAsync();

        return Ok();
    }
}




