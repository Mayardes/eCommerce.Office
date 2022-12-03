using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Office
{
    public class eCommerceOfficeContext : DbContext
    {
        public eCommerceOfficeContext(DbContextOptions<eCommerceOfficeContext> options): base(options){}

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<ColaboradorSetor> ColaboradoresSetores { get; set;}
        public DbSet<Turma> Turmas { get; set;}
        public DbSet<Veiculo> Veiculos { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M3HIHDH\SQLEXPRESS; Database=eComerceOfficeDB; Integrated Security=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ColaboradorSetor
            /**
             * Muitos para Muitos usando 2 relacionamentos de Um para Muitos
             */

            modelBuilder.Entity<ColaboradorSetor>()
                .HasKey(x => new { x.SetorId, x.ColaboradorId});

            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(x => x.Colaborador)
                .WithMany(x => x.ColaboradoresSetores)
                .HasForeignKey(x => x.ColaboradorId);
            
            modelBuilder.Entity<ColaboradorSetor>()
                .HasOne(x => x.Setor)
                .WithMany(x => x.ColaboradoresSetores)
                .HasForeignKey(x => x.SetorId);

            //modelBuilder.Entity<Colaborador>().HasMany(x => x.ColaboradoresSetores).WithOne( x=> x.Colaborador).HasForeignKey(a => a.ColaboradorId);
            //modelBuilder.Entity<Setor>().HasMany(x => x.ColaboradoresSetores).WithOne(x => x.Setor).HasForeignKey(x => x.SetorId);

            #endregion

            #region Seeds
            modelBuilder.Entity<Colaborador>().HasData(
            new Colaborador(){ Id = 1, Nome = "José da Silva"}, 
            new Colaborador(){ Id = 2, Nome = "Maria"}, 
            new Colaborador(){ Id = 3, Nome = "Felipe"}, 
            new Colaborador(){ Id = 4, Nome = "Thiago"},
            new Colaborador(){ Id = 5, Nome = "Mariano"},
            new Colaborador(){ Id = 6, Nome = "Juliano"},
            new Colaborador(){ Id = 7, Nome = "Jessica"},
            new Colaborador(){ Id = 8, Nome = "Ricardo"});

            modelBuilder.Entity<Setor>().HasData(
            new Setor(){ Id = 1, Nome = "Logística"}, 
            new Setor(){ Id = 2, Nome = "Separação"}, 
            new Setor(){ Id = 3, Nome = "Financeiro"}, 
            new Setor(){ Id = 4, Nome = "Administrativo"});

            modelBuilder.Entity<ColaboradorSetor>().HasData(
            new ColaboradorSetor() { SetorId = 1, ColaboradorId = 1 , Criado = DateTimeOffset.UtcNow },
            new ColaboradorSetor() { SetorId = 1, ColaboradorId = 6 , Criado = DateTimeOffset.UtcNow },
            new ColaboradorSetor() { SetorId = 2, ColaboradorId = 5 , Criado = DateTimeOffset.UtcNow },
            new ColaboradorSetor() { SetorId = 2, ColaboradorId = 4 , Criado = DateTimeOffset.UtcNow },
            new ColaboradorSetor() { SetorId = 3, ColaboradorId = 7 , Criado = DateTimeOffset.UtcNow },
            new ColaboradorSetor() { SetorId = 4, ColaboradorId = 2 , Criado = DateTimeOffset.UtcNow },
            new ColaboradorSetor() { SetorId = 4, ColaboradorId = 3 , Criado = DateTimeOffset.UtcNow });

            #endregion
        }
    }
}
