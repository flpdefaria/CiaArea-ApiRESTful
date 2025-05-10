namespace CiaArea.Entities;

public class Aeronave
{
    public Aeronave(string fabricante, string modelo, string codigo)
    {
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }
    
    public int Id { get; set; }

    public string Fabricante { get; set; }

    public string Modelo { get; set; }

    public string Codigo { get; set; }
}