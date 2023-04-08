using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
/*
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();



app.UseAuthorization();
*/
app.UseRouting();
app.UseStaticFiles();
app.UseHttpsRedirection();

// получение данных
//app.MapGet("/", (ApplicationContext db) => db.objects.ToList());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run(async (context) => await context.Response.WriteAsync("<h1>asdasdasdA</h1> "));
/*app.Run(async (context) =>
{
    string str = context.Request.Path;
    //context.Response.ContentType = "text/html";
    context.Response.WriteAsync(str);
}
);*/
app.Run();
