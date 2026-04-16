using HelpDeskAPI.Data;
using HelpDeskAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔗 Connexion SQL Server
builder.Services.AddDbContext<HelpDeskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 📦 Controllers
builder.Services.AddControllers();

// 📘 Swagger
builder.Services.AddSwaggerGen();

// ✅ FIX ONLY THIS (service missing)
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();