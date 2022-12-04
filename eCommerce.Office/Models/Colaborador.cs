namespace eCommerce.Office.Models
{
    public class Colaborador
    {
        public int Id { get; set;}
        public string Nome { get; set;} 
        public ICollection<Veiculo> Veiculos { get; set;}
        public ICollection<ColaboradorVeiculo> ColaboradoresVeiculos { get; set;}
        public ICollection<ColaboradorSetor> ColaboradoresSetores { get; set; }
        public ICollection<Turma> Turmas { get; set;}
    }
}
