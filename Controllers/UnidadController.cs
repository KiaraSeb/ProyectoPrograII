using Microsoft.AspNetCore.Mvc;
    
[ApiController]
[Route("api/Unidades")]
public class UnidadController : ControllerBase {

  private readonly IUnidadService _unidadService;

  public UnidadController(IUnidadService UnidadService)
  {
    _unidadService = UnidadService;
  }
  [HttpGet]
  public ActionResult<List<Unidad>> GetAllUnidades(){

    return Ok(_unidadService.GetAll());
  }
    
  [HttpGet("{id}")]
  public ActionResult<Unidad> GetById(int id)
  {
  Unidad? a = _unidadService.GetById(id);
  if(a == null)
  {
    return NotFound("Unidad no Encotrado");
  }
  
  return Ok(a);

  }

  [HttpPost]
  public ActionResult<Unidad> NuevoUnidad(UnidadDTO a){
    //Asigno el id al Unidad nuevo buscando el maximo id en la lista actual de Unidades y sumando 1
    //a.Id = _unidadService.GetAll().Max(m => m.Id) + 1;
    // Llamo al metodo Create del servicio de Unidad para dar de alta el nuevo Unidad
    Unidad _a = _unidadService.Create(a);
    //Devuelvo el resultado de llamar al metodo GetById pasando como parametro el Id del nuevo Unidad
    return CreatedAtAction(nameof(GetById), new {id = _a.Id}, _a);
  }

  [HttpDelete("{id}")]
  public ActionResult Delete(int id)
  {
    var a = _unidadService.GetById(id);

    if (a == null)
    { return NotFound("Unidad no encontrado!!!");}

    _unidadService.Delete(id);
    return NoContent();
  }

  [HttpPut("{id}")]
  public ActionResult<Unidad> UpdateUnidad(int id, UnidadDTO updatedUnidad) {
    
    var Unidad = _unidadService.Update(id, updatedUnidad);

    if (Unidad is null) {
      return NotFound(); // Si no se encontró el Unidad, retorna 404 Not Found
    }
    return CreatedAtAction(nameof(GetById), new {id = Unidad.Id}, Unidad);
  }

}
