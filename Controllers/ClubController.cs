
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Clubs")]
public class ClubController : ControllerBase
{
    private readonly IClubService _clubService;
    private readonly IConquistadorService _conquistadorService;

    public ClubController(IClubService _clubService, IConquistadorService conquistadorService)
    {
      _clubService = clubService;
      _conquistadorService = conquistadorService;
    }

    [HttpGet]
    public ActionResult<List<Club>> GetAll()
    {
      try
      {
        return Ok(_clubService.GetAll());
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.Message);
        return Problem(detail: e.Message, statusCode: 500);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Club> GetById(int id)
    {
      Club? Club = _clubService.GetById(id);
      if ( Club is null ) return NotFound();
      return Ok(Club);
    }

    [HttpPost]
    public ActionResult<Club> NuevoClub(ClubDTO l)
    {
      Club Club = _clubService.Create(l);
      return CreatedAtAction(nameof(GetById), new { id = Club.Id}, Club);
    }

    [HttpPut("{id}")]
    public ActionResult<Club> Update(int id, ClubDTO l)
    {
      try
      {
        Club Club = _clubService.Update(id, l);
        if ( Club is null ) return NotFound(new {Message = $"No se pudo actualizar el Club con id: {id}"});
        return CreatedAtAction(nameof(GetById), new { id = Club.Id}, Club);
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.Message);
        return Problem(detail: e.Message, statusCode: 500);
      }
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
      bool deleted = _clubService.Delete(id);
      if (deleted) return NoContent();
      return NotFound();
    }
}