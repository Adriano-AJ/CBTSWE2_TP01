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

            builder.MapRoute("livro/Nomelivro", NomeLivro);
            builder.MapRoute("livro/Autores", GetAuthorNames);
            builder.MapRoute("livro/Descricaolivro", ToStringLivro);
            builder.MapRoute("livro/Apresentarlivro", ApresentarLivro);
            builder.MapRoute("livro/Apresentarlivro/{id}", ApresentarLivro);

            var rotas = builder.Build();

            app.UseRouter(rotas);
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

            context.Response.ContentType = "text/plain; charset=utf-8";

            return context.Response.WriteAsync(livro.getName());
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

            context.Response.ContentType = "text/plain; charset=utf-8";

            return context.Response.WriteAsync(livro.GetAuthorNames());
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

            context.Response.ContentType = "text/plain; charset=utf-8";

            return context.Response.WriteAsync(livro.ToString());
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
