using KMS.Api.Extensions;
using KMS.API.RegisterService;
using KMS.Application.RegisterService;
using KMS.Data.RegisterService;

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
builder.Services.RegisterKMSAPIServices();

builder.Services.AddControllers();

//added for loops
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();

// Enable Cors
app.UseCors("MyPolicy");
//app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7235/"));

app.MapControllers();

app.Run();
