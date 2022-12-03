using eCommerce.Office;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddDbContext<eCommerceOfficeContext>();
    })
    .Build();
