using ModelValidationsExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//app.MapGet("/", () => "Hello World!");




app.MapControllers();



app.Run();
