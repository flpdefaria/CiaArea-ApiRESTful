namespace CiaAerea.Entities;

public class Voo
{
    public Voo(string origem, string destino, DateTime dataHoraChegada, DateTime dataHoraPartida, int aeronaveId, int pilotoId)
    {
        Destino = destino;
        Origem = origem;
        DataHoraChegada = dataHoraChegada;
        DataHoraPartida = dataHoraPartida;
        AeronaveId = aeronaveId;
        PilotoId = pilotoId;
    }
    
    public int Id { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }
    public DateTime DataHoraPartida { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public int AeronaveId { get; set; }
    public int PilotoId { get; set; }
    public Aeronave Aeronave { get; set; } = null!;
    public Piloto Piloto { get; set; } = null!;
    public Cancelamento? Cancelamento { get; set; }

}