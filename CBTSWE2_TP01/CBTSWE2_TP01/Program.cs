/*
 * Integrantes:
 * 
 * ADRIANO JÚNIOR DE SOUZA ALMEIDA - CB3030644
 * ARTHUR LANZILOTTI FARJANES - CB3031306
 */

using CBTSWE2_TP01;
using CBTSWE2_TP01.Repositorio;
using CBTSWE2_TP01.Testes;
using Microsoft.AspNetCore.Hosting;

// Executa a classe de testes
 BooktTest.Executar();

 Console.ReadLine();

var _repo = new BookRepositoryCSV();

IWebHost host = new WebHostBuilder()
    .UseKestrel()
    .UseStartup<Startup>()
    .Build();

host.Run();
