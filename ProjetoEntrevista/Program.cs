using ProjetoEntrevista;

var builder = WebApplication.CreateBuilder(args); //Original do Program.cs  mantido
var startup = new Startup(builder.Configuration);//Instaciando classe StartUp que foi criada manualmente

startup.ConfigureServices(builder.Services); //Invocando método que subistitui o configureServices que agora não esta mais aqui no program.cs


// Add services to the container. -> Original do Program.cs Enviado para a classe startUP
//builder.Services.AddControllersWithViews();  <- Original do Program.cs Enviado para a classe startUP

var app = builder.Build(); //Original do Program.cs mantido


startup.Configure(app, app.Environment);  //Invocando método que subistitui o configureServices que agora não esta mais aqui no program.cs

// Configure the HTTP request pipeline. -> Original do Program.cs Enviado para a classe startUP /
/*if (!app.Environment.IsDevelopment()) 
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
    pattern: "{controller=Home}/{action=Index}/{id?}"); <- Original do Program.cs Enviado para a classe startUP */



app.Run();
