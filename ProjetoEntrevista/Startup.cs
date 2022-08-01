using ProjetoEntrevista.Data; //importando minha classe conexão da pasta data
using ProjetoEntrevista.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ProjetoEntrevista
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();            
            services.AddEntityFrameworkSqlServer() //Adicionando na inicialização do projeto o service 'Entity' que será responsável por ativar o ambinte de banco dadados no projeto
                .AddDbContext<BancoDeDados>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase"))); //AddDbContext<BancoDeDados> faz referência da minha classe que esta na pasta DATA... Configuration.GetConnectionString acessa e colhe os dados (server, user, database etc... ) no indice "DataBase" json em appsettings.json (conhecido como .env) 
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();//A services.AddScoped configura que toda vez que a IContatoRepositorio for chamada será feita "injeção de dependência" em  ContatoRepositorio.                     
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();//A services.AddScoped configura que toda vez que a IContatoRepositorio for chamada será feita "injeção de dependência" em  ContatoRepositorio.
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); //Service nescessária para viablizar que o projeto seja alterado e atualizado em tempo de exceução, sem a nescessidade de recompilação.
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}"); //O {controller=Login} e {action=Index} será o a View exibida na execução do projeto

        }


    }
}
