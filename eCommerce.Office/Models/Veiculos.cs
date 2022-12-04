namespace eCommerce.Office.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public ICollection<Colaborador> Colaboradores { get; set; }
        public ICollection<ColaboradorVeiculo> ColaboradoresVeiculos { get; set; }
    }
}
