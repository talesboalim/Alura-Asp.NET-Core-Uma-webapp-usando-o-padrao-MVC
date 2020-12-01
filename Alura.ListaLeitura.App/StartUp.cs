using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("livros/paraler", LivrosLogica.LivrosParaLer);
            routeBuilder.MapRoute("livros/lendo", LivrosLogica.LivrosLendo);
            routeBuilder.MapRoute("livros/lidos", LivrosLogica.LivrosLidos);
            routeBuilder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.ExibeDetalhes);
            routeBuilder.MapRoute("cadastro/novolivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);            
            routeBuilder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            routeBuilder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);
            var rotas = routeBuilder.Build();

            app.UseRouter(rotas);
        }

        /*
        public static Task Roteamento(HttpContext context)
        {
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                { "/Livros/ParaLer", LivrosParaLer },
                { "/Livros/Lendo", LivrosLendo },
                { "/Livros/Lidos", LivrosLidos }
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente.");
        }
        */

    }
}