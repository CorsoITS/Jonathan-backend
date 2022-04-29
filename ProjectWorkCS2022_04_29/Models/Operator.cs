namespace _7_WebApi.Models;
// id, ruolo, nome, cognome, usurname, password, sede_id
public class Operator
{
    public int? Id { get; set; }
    public string? Role { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public int? Site_id { get; set; }

}