using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using CBTSWE2_TP01.Negocio;
using CBTSWE2_TP01.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace CBTSWE2_TP01
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);

            builder.MapRoute("", MenuPrincipal);
            builder.MapRoute("livro/Nomelivro", NomeLivro);
            builder.MapRoute("livro/Autores", GetAuthorNames);
            builder.MapRoute("livro/Descricaolivro", ToStringLivro);
            builder.MapRoute("livro/Apresentarlivro", ApresentarLivro);
            builder.MapRoute("livro/Apresentarlivro/{id}", ApresentarLivro);

            var rotas = builder.Build();

            app.UseRouter(rotas);
        }
        public Task MenuPrincipal(HttpContext context)
        {
            string html = @"
                <!DOCTYPE html>
                <html lang='pt-BR'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Navegação - Atividade CBTSWE2</title>
                    <style>
                        body {
                            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                            background-color: #f4f7f6;
                            color: #333;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            height: 100vh;
                            margin: 0;
                        }
                        .container {
                            background-color: #ffffff;
                            padding: 40px;
                            border-radius: 10px;
                            box-shadow: 0 8px 16px rgba(0,0,0,0.1);
                            text-align: center;
                            width: 100%;
                            max-width: 400px;
                        }
                        h1 {
                            font-size: 24px;
                            color: #2c3e50;
                            margin-top: 0;
                            margin-bottom: 10px;
                        }
                        p {
                            color: #7f8c8d;
                            margin-bottom: 30px;
                        }
                        a.btn {
                            display: block;
                            background-color: #3498db;
                            color: #ffffff;
                            padding: 15px 20px;
                            margin: 10px 0;
                            border-radius: 6px;
                            text-decoration: none;
                            font-size: 16px;
                            font-weight: bold;
                            transition: background-color 0.3s ease, transform 0.1s ease;
                        }
                        a.btn:hover {
                            background-color: #2980b9;
                            transform: translateY(-2px);
                        }
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h1>Menu de Testes</h1>
                        <p>Atividade TP01 - CBTSWE2</p>
            
                        <a class='btn' href='/livro/Nomelivro' target='_blank'>B1 - Nome do Livro</a>
                        <a class='btn' href='/livro/Descricaolivro' target='_blank'>B2 - Descrição (ToString)</a>
                        <a class='btn' href='/livro/Autores' target='_blank'>B3 - Autores</a>
                        <a class='btn' href='/livro/Apresentarlivro' target='_blank'>B4 - HTML Apresentar Livro</a>
                    </div>
                </body>
            </html>";

            context.Response.ContentType = "text/html; charset=utf-8";
            return context.Response.WriteAsync(html);
        }
        public Task NomeLivro(HttpContext context)
        {
            var repo = new BookRepositoryCSV();
            var livro = repo.BuscarPorId(14);

            if (livro == null)
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("Livro não encontrado.");
            }

            context.Response.ContentType = "text/html; charset=utf-8";

            return context.Response.WriteAsync($"<pre>{livro.getName()}</pre>");
        }

        public Task GetAuthorNames(HttpContext context)
        {
            var repo = new BookRepositoryCSV();
            var livro = repo.BuscarPorId(14);

            if (livro == null)
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("Livro não encontrado.");
            }

            context.Response.ContentType = "text/html; charset=utf-8";

            return context.Response.WriteAsync($"<pre>{livro.GetAuthorNames()}</pre>");
        }

        public Task ToStringLivro(HttpContext context)
        {
            var repo = new BookRepositoryCSV();
            var livro = repo.BuscarPorId(14);

            if (livro == null)
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("Livro não encontrado.");
            }

            context.Response.ContentType = "text/html; charset=utf-8";

            return context.Response.WriteAsync($"<pre>{livro.ToString()}</pre>");
        }

        public Task ApresentarLivro(HttpContext context)
        {
            var repo = new BookRepositoryCSV();
            var idRoute = context.GetRouteValue("id");
            Book livro;
            if (idRoute != null)
            {
                int id = Convert.ToInt32(idRoute);
                livro = repo.BuscarPorId(id);
            }
            else
            {
                livro = repo.BuscarPorId(14);
            }

            if (livro == null)
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("Livro não encontrado.");
            }

            string html = "<html>";
            html += "<head>";
            html += "<meta charset='UTF-8'>";
            html += "<title>Livro</title>";
            html += "</head>";
            html += "<body>";
            html += $"<h1>{livro.getName()}</h1>";
            html += "<h2>Autores</h2>";
            html += "<ul>";

            foreach (var autor in livro.getAuthors())
            {
                html += $"<li>{autor.Name}</li>";
            }

            html += "</ul>";
            html += "</body>";
            html += "</html>";

            context.Response.ContentType = "text/html; charset=utf-8";
            return context.Response.WriteAsync(html);
        }
    }
}
