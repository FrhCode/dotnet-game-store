using GameStore.Api;
using GameStore.Api.Authorization;
using GameStore.Api.Cors;
using GameStore.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRepositories(builder.Configuration);


builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(options => options.AuthorizationCallback());

builder.Services.AddCors(options => options.ConfigureCorsHandler(builder.Configuration));

var app = builder.Build();

app.UseCors();

app.UseExceptionHandler(handler => handler.ConfigureExceptionHandler());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

