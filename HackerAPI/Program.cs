using HackerAPI.Services;
using HackerAPI.Services.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ResiliencySettings>(builder.Configuration.GetSection("Resiliency"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register IMemoryCache
builder.Services.AddMemoryCache();

// Register StoryService
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<StoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
