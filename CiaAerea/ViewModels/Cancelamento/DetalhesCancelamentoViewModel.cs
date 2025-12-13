namespace CiaAerea.ViewModels.Cancelamento;

public class DetalhesCancelamentoViewModel
{
    public DetalhesCancelamentoViewModel(int id, DateTime dataHoraNotificacao, string motivo, int vooId)
    {
        Id = id;
        DataHoraNotificacao = dataHoraNotificacao;
        Motivo = motivo;
        VooId = vooId;
    }

    public int Id { get; set; }
    public string Motivo { get; set; }
    public DateTime DataHoraNotificacao { get; set; }
    public int VooId { get; set; }
}