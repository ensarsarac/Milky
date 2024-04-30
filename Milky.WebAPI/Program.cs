using Milky.BusinessLayer.Abstract;
using Milky.BusinessLayer.Concrete;
using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Concrete;
using Milky.BusinessLayer.Container;
using Milky.DataAccessLayer.EntityFramework;
using Milky.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MilkyContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MilkyContext>().AddDefaultTokenProviders();
builder.Services.AddDepencies();
builder.Services.AddControllers();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
