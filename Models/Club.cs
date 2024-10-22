public class Club
{
  public int Id { get; set; }
  public string Nombre{ get; set; }

  public Conquistador conquistador { get; set; }
  public int? ConquistadorId {get; set;}

  public int? Miembros {get; set;} 
  public int? Ano {get; set;}
  public List<Unidad> Unidades {get; set;}
  
}