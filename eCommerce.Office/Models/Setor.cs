namespace eCommerce.Office.Models
{
    public class Setor
    {
        public int Id { get; set;}
        public string Nome { get; set;}
        public ICollection<ColaboradorSetor> ColaboradoresSetores { get; set; }
    }
}
