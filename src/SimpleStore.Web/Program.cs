using SimpleStore.Web.Data;
using SimpleStore.Web.Repositories;
using SimpleStore.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Adicionar o MySqlContext como um serviço
builder.Services.AddSingleton<MySqlContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<CadastroClienteRepository>();
builder.Services.AddScoped<CadastroClienteService>();
builder.Services.AddScoped<ProdutoService>();

var app = builder.Build();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produto}/{action=Index}/{id?}");

app.Run();
