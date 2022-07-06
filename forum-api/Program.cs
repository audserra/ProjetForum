using forum_api.DataAccess.DataObjects;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkMySql().AddDbContext<mangafilrouge_forumdbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("admin"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"),
        mySqlOptionsAction: mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure();
        });
});

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
