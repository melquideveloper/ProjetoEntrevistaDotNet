using ProjetoEntrevista.Data; //importando minha classe conexão da pasta data
using ProjetoEntrevista.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;  //passo para session, adicionar bliblioteca
using ProjetoEntrevista.helper;

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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //passo 2 para session, Essa service é configurda para dar suporte ao iniciar o projeto, para interface Isessao que esta na pasta /helper, responsável por gerir a sessão do projeto
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();//A services.AddScoped configura que toda vez que a IContatoRepositorio for chamada será feita "injeção de dependência" em  ContatoRepositorio.                     
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();//A services.AddScoped configura que toda vez que a IContatoRepositorio for chamada será feita "injeção de dependência" em  ContatoRepositorio.
            services.AddScoped<ISessao, Sessao>(); //passo 3 para session, A services.AddScoped configura que toda vez que a ISessao for chamada será feita "injeção de dependência" na classe  Sessao.
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); //Service nescessária para viablizar que o projeto seja alterado e atualizado em tempo de exceução, sem a nescessidade de stop no projeto e start novamente.
            services.AddScoped<IEmail, Email>(); //A services.AddScoped configura que toda vez que a IEmail for chamada será feita "injeção de dependência" na classe  Sessao.

            services.AddSession(o => //passo 4 para session, configurar serviço de cookie
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });
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

            app.UseSession(); //passo 5 para session, habilita a session no projeto já configurada primeiramente no ConfigureServices

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}"); //O {controller=Login} e {action=Index} será o a View exibida na execução do projeto

        }


    }
}
