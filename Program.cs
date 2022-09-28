using Microsoft.EntityFrameworkCore;
using MovieProjectCo.Services;
using MovieProjectCo.Operations.Movies;
using MovieProjectCo.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieService, EFMovieService>();
//builder.Services.AddScoped<IMovieService,RawMovieService>();
builder.Services.AddScoped<ICategoryService, EFCategoryService>();
builder.Services.AddScoped<IMovieCategoryService,EFMovieCategoryService>();
builder.Services.AddScoped<IMovieCategoryService,RawMovieCategoryService>();
builder.Services.AddScoped<ValidateSaveMovie, ValidateSaveMovie>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
