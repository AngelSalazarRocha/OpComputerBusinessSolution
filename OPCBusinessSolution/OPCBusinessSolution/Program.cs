using OPCBusinessSolution.Api;

var builder = WebApplication.CreateBuilder(args);

// Configuracion del api mediante HttpClient
builder.Services.AddHttpClient("ApiOPCBS", client =>
{
    client.BaseAddress = new Uri("https://api.opcbsolutionsexample.com/");
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

// mvc services
builder.Services.AddControllersWithViews();

// Registro del servicio de la clase Api
builder.Services.AddTransient<ApiService>();

var app = builder.Build();

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

app.Run();
