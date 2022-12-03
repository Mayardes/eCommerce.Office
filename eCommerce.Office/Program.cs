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

#region Many-To-Many > 2x One-To-Many

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
