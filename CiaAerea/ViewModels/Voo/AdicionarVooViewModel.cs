using CiaAerea.Entities;

namespace CiaAerea.ViewModels.Voo;

public class AdicionarVooViewModel
{
    public AdicionarVooViewModel(string origem, string destino, DateTime dataHoraPartida, DateTime dataHoraChegada, int aeronaveId, int pilotoId, Entities.Aeronave aeronave, Entities.Piloto piloto, Cancelamento cancelamento)
    {
        Origem = origem;
        Destino = destino;
        DataHoraPartida = dataHoraPartida;
        DataHoraChegada = dataHoraChegada;
        AeronaveId = aeronaveId;
        PilotoId = pilotoId;
        Aeronave = aeronave;
        Piloto = piloto;
        Cancelamento = cancelamento;
    }

    public string Origem { get; set; }
    public string Destino { get; set; }
    public DateTime DataHoraPartida { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public int AeronaveId { get; set; }
    public int PilotoId { get; set; }
    public Entities.Aeronave Aeronave { get; set; }
    public Entities.Piloto Piloto { get; set; }
    public Cancelamento Cancelamento { get; set; }
    
}