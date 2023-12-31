using Microsoft.EntityFrameworkCore;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.Mapping;
using ProjekatNaVezbama.Repositories;
using ProjekatNaVezbama.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(MapperConfig));
// Add services to the container.

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();



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
