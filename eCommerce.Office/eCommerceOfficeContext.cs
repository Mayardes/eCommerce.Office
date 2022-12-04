using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Office
{
    public class eCommerceOfficeContext : DbContext
    {
        //public eCommerceOfficeContext(DbContextOptions<eCommerceOfficeContext> options): base(options){}

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<ColaboradorSetor> ColaboradoresSetores { get; set;}
        public DbSet<ColaboradorVeiculo> ColaboradorVeiculo { get; set;}
        public DbSet<Turma> Turmas { get; set;}
        public DbSet<Veiculo> Veiculos { get; set;}
        public DbSet<Setor> Setores { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M3HIHDH\SQLEXPRESS; Database=eComerceOfficeDB; Integrated Security=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapping: ColaboradorSetor
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

            //deixar explicito o mapeamento usando o EF Core > 5.0
            #region Mapping: ColaboradorTurma
            modelBuilder.Entity<Colaborador>().HasMany(x => x.Turmas).WithMany(x => x.Colaboradores);
            #endregion

            #region Mapping: ColaboradorVeiculo
            modelBuilder.Entity<Colaborador>()
                .HasMany(x => x.Veiculos)
                .WithMany(x => x.Colaboradores)
                .UsingEntity<ColaboradorVeiculo>(
                 q => q.HasOne(x => x.Veiculo).WithMany(x => x.ColaboradoresVeiculos).HasForeignKey(x => x.VeiculoId),
                 q => q.HasOne(x => x.Colaborador).WithMany(x => x.ColaboradoresVeiculos).HasForeignKey(x => x.ColaboradorId),
                 q => q.HasKey(x => new { x.VeiculoId, x.ColaboradorId}
                ));
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

            modelBuilder.Entity<Turma>().HasData(
            new Turma() { Id = 1, Nome = "Turma A1"},
            new Turma() { Id = 2, Nome = "Turma A2"},
            new Turma() { Id = 3, Nome = "Turma A3"},
            new Turma() { Id = 4, Nome = "Turma A4"},
            new Turma() { Id = 5, Nome = "Turma A5"});

            modelBuilder.Entity<Veiculo>().HasData(
            new Veiculo() { Id = 1, Nome = "Saveiro", Placa = "ABC-1235"},
            new Veiculo() { Id = 2, Nome = "Saveiro", Placa = "DEF-3453"},
            new Veiculo() { Id = 3, Nome = "Saveiro", Placa = "GHI-6783"},
            new Veiculo() { Id = 4, Nome = "Saveiro", Placa = "JLM-9101"},
            new Veiculo() { Id = 5, Nome = "Saveiro", Placa = "NOP-1122"});
            #endregion
        }
    }
}
