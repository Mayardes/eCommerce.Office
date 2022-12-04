namespace eCommerce.Office.Models
{
    public class ColaboradorVeiculo
    {
        public int ColaboradorId { get; set;}
        public int VeiculoId { get; set;}
        public DateTimeOffset Criado { get; set;}
        public Colaborador Colaborador { get; set;}
        public Veiculo Veiculo { get; set;}
    }
}
