using System.Text.Json.Serialization;

public class Club
{
  public int Id {get; set;}
  public string Nombre {get; set;}

  [JsonIgnore]
  public List<Club> Clubs {get; set;}   
}