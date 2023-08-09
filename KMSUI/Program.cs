using KMS.Api.Extensions;
using KMS.Data.Configs;
using KMS.Application.Configs;

var builder = WebApplication.CreateBuilder(args);


// Add Cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
//builder.Services.AddCors();
// End Of Add Cors

// Add services to the container.
 builder.Services.AddApplicationService(builder.Configuration);

builder.Services.RegisterDataLayerServices();
builder.Services.RegisterApplicationLayerServices();

builder.Services.AddControllers();


builder.Services.AddControllersWithViews();

////added for loops
//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


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

// Enable Cors
app.UseCors("MyPolicy");
//app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7235/"));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();


app.Run();


 