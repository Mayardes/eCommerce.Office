using eCommerce.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddDbContext<eCommerceOfficeContext>();
    })
    .Build();


var db = new eCommerceOfficeContext();

#region Many-To-Many > 2x One-To-Many for EF Core <= 3.1

var resultado = db.Setores?.Include(x => x.ColaboradoresSetores).ThenInclude(x => x.Colaborador);
foreach(var setor in resultado)
{
    Console.WriteLine($"Setor: {setor.Nome}");

    foreach(var colabSetor in setor.ColaboradoresSetores)
    {
        Console.WriteLine($"SetorId: {colabSetor.SetorId} - colaboradorId : {colabSetor.ColaboradorId}");
        Console.WriteLine($"SetorId: {colabSetor.SetorId} - Nome : {colabSetor.Colaborador.Nome}");
    }
}
//Sendo a única opção em um relacionamento N:N usando o EF Core com versão < 5.0
#endregion

#region Many-To-Many for EF Core > 3.1

Console.WriteLine("____________Many-To-Many for EF Core > 5.0 ________________");
var resultadoTurma = db.Colaboradores!.Include(x => x.Turmas);

foreach(var colab in resultadoTurma)
{
    Console.WriteLine($"{colab.Nome}");

    foreach(var turma in colab.Turmas)
    {
        Console.WriteLine($"-{turma.Nome}");
    }
}
#endregion

#region Many-To-Many for EF Core > 5.0 para uso de uma tabela temporária quando necessitamos de atributo dessa relação

Console.WriteLine("____________Many-To-Many for EF Core > 5.0 ________________");

var colaboradorVeiculos = db.ColaboradorVeiculo
    .Include(x => x.Colaborador)
    .ThenInclude(x => x.ColaboradoresVeiculos)
    .ThenInclude(x => x.Veiculo);

foreach(var colab in colaboradorVeiculos)
{
    Console.WriteLine($"{colab.Colaborador.Nome}");
    foreach(var veiculo in colab.Colaborador.ColaboradoresVeiculos)
    {
        Console.WriteLine($"Nome: {veiculo.Veiculo.Nome}, Placa: {veiculo.Veiculo.Placa}");
    }
}
#endregion