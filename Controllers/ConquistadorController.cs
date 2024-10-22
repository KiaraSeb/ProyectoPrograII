using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
    
[ApiController]
[Authorize]
[Route("api/Conquistadores")]
public class ConquistadorController : ControllerBase {

  private readonly IConquistadorService _ConquistadorService;

  public ConquistadorController(IConquistadorService ConquistadorService)
  {
    _ConquistadorService = ConquistadorService;
  }

 // [Authorize] hace que solo usuarios Conquistadorizados puedan acceder a los datos, al estar arriba del método aplica para todos los métodos desde este hasta el final del código
  [HttpGet]
  //[AllowAnonymous] es para que no se necesite Conquistadorización para acceder al método
  public ActionResult<List<Conquistador>> GetAllConquistadores(){

    return Ok(_ConquistadorService.GetAll());
  }
  
  [HttpGet("{id}/clubs")]
  [Authorize(Roles = "admin")] //puede acceder el usuario que este Conquistadorizado y que tenga el rol de usuario
  public ActionResult<List<Libro>> GetClubs(int id)
  {
    var a = _ConquistadorService.GetClubs(id);
    return Ok(a);

  }

  [HttpGet("{id}")]
  public ActionResult<Conquistador> GetById(int id)
  {
  Conquistador? a = _ConquistadorService.GetById(id);
  if(a == null)
  {
    return NotFound("Conquistador no Encotrado");
  }
  
    return Ok(a);

  }

  [HttpPost]
  public ActionResult<Conquistador> NuevoConquistador(ConquistadorDTO a){
    //Asigno el id al Conquistador nuevo buscando el maximo id en la lista actual de Conquistadores y sumando 1
    //a.Id = _ConquistadorService.GetAll().Max(m => m.Id) + 1;
    // Llamo al metodo Create del servicio de Conquistador para dar de alta el nuevo Conquistador
    Conquistador _a = _ConquistadorService.Create(a);
    //Devuelvo el resultado de llamar al metodo GetById pasando como parametro el Id del nuevo Conquistador
    return CreatedAtAction(nameof(GetById), new {id = _a.Id}, _a);
  }

  [HttpDelete("{id}")]
  public ActionResult Delete(int id)
  {
    var a = _ConquistadorService.GetById(id);

    if (a == null)
    { return NotFound("Conquistador no encontrado!!!");}

    _ConquistadorService.Delete(id);
    return NoContent();
  }

  [HttpPut("{id}")]
  public ActionResult<Conquistador> UpdateConquistador(int id, Conquistador updatedConquistador) {
    // Asegurarse de que el ID del Conquistador en la solicitud coincida con el ID del parámetro
    if (id != updatedConquistador.Id) {
      return BadRequest("El ID del Conquistador en la URL no coincide con el ID del Conquistador en el cuerpo de la solicitud.");
    }
    var Conquistador = _ConquistadorService.Update(id, updatedConquistador);

    if (Conquistador is null) {
      return NotFound(); // Si no se encontró el Conquistador, retorna 404 Not Found
    }
     return CreatedAtAction(nameof(GetById), new {id = Conquistador.Id}, Conquistador); // Retorna el recurso actualizado
  }

}

