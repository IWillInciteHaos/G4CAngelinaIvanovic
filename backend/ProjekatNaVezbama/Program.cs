using Microsoft.EntityFrameworkCore;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connecitonString = "Server=DESKTOP-5HUTBE9\\SQLEXPRESS;Database=PostItDB;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<DBPostItContext>(options =>{
        options.UseSqlServer(connecitonString);
    }
);


var app = builder.Build();

//ovde proveri


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
