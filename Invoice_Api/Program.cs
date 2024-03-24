
using Invoice_Api.Repo;
using Invoice_Api.Repo.Modal;
using Invoice_Api.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<InvoiceService>();
builder.Services.AddDbContext < InvoiceDbContext > (o => o.UseSqlServer(builder.Configuration.GetConnectionString("InvoiceConn")));

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<Invoice>();
builder.Services.AddTransient<ItemService>();
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
