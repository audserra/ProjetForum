using forum_api.DataAccess.DataObjects;
using forum_api.Repositories;
using forum_api.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
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

//repositories
builder.Services.AddTransient<ITopicRepository, TopicRepository>();

//services
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<IWordFilterService, WordFilterService>();

// Manage CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EnableCORS");
app.UseAuthorization();

app.MapControllers();

app.Run();
