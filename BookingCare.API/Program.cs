using BookingCare.API.Contexts;
using BookingCare.API.Services.PasswordHashingService;
using BookingCare.API.Services.TokenService;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookingCare.API.Profiles;
using BookingCare.API.Services.DatabaseService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPasswordHashingService, NoHashPasswordHashingService>();
builder.Services.AddSingleton<ITokenService, RealTokenService>();
builder.Services.AddScoped<IDatabaseService, RealDatabaseService>();

// Add authentication service
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	o.TokenValidationParameters = new TokenValidationParameters
	{
		IssuerSigningKey = new SymmetricSecurityKey
		(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value!)),
		ValidateLifetime = false,
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateIssuerSigningKey = true,
	};
});
builder.Services.AddAuthorization();
builder.Services.AddCors(p =>
{
	p.AddPolicy(name: MyAllowSpecificOrigins, build =>
	{
		build.WithOrigins("https://localhost:7112", "http://localhost:5172")

			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

// Add automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database service configuration
builder.Services.AddDbContext<DatabaseContext>(options =>
{
	//options.EnableSensitiveDataLogging();
	options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
