using Microsoft.AspNetCore.Authentication.Cookies;
using SimpleStore.Web.Data;
using SimpleStore.Web.Repositories;
using SimpleStore.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

// Configuração do Entity Framework Core com MySQL
builder.Services.AddMySqlDbContext(builder.Configuration);

// Configuração do Dapper
builder.Services.AddDapper(builder.Configuration);

// Adicionar o MySqlContext como um serviço

builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<CadastroClienteRepository>();
builder.Services.AddScoped<CadastroClienteService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<LoginClienteRepository>();
builder.Services.AddScoped<LoginClienteService>();
builder.Services.AddScoped<PerfilService>();
builder.Services.AddScoped<PerfilRepository>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/LoginCliente/AccessDenied";
        options.LoginPath = "/LoginCliente/";
    });

var app = builder.Build();

// Configuração do pipeline do aplicativo
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produto}/{action=Index}/{id?}");

app.Run();
