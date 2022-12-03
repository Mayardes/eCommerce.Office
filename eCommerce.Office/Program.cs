using eCommerce.Office;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddDbContext<eCommerceOfficeContext>();
    })
    .Build();


var db = new eCommerceOfficeContext();

foreach(var setor in db.Setores)
{
    Console.WriteLine($"Id setor é {setor.Id}, com seu nome {setor.Nome}");
}