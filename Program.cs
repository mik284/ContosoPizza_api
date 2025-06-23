var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "ContosoPizza",
            Version = "v1",
            Description = "A simple example ASP.NET Core Web API",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Mike Kamau",
                Email = "mikeykamau222@gmail.com",
                Url = new Uri("https://github.com/mik284/ContosoPizza.git")
            },
            License = new Microsoft.OpenApi.Models.OpenApiLicense
            {
                Name = "Use this license",
                Url = new Uri("https://github.com/mik284/ContosoPizza/blob/main/LICENSE")
            }
        });
    }
);

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
