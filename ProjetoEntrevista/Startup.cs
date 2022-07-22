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
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoDeDados>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase"))); //Adicionando serviço de banco de dados informando minha conexao na pasta Data. 
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

        }


    }
}
