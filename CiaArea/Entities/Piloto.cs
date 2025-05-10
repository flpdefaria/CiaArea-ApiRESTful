namespace CiaArea.Entities;

public class Piloto
{
    public Piloto(string nome, string matricula)
    {
        Nome = nome;
        Matricula = matricula;
    }
    
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Matricula { get; set; }
}