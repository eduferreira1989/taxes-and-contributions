using TAC.Common.MongoDB;
using TAC.Person.Domains;
using TAC.Person.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMongo()
                .AddMongoRepository<TAC.Person.Models.Person>("person");

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ISalaryService, SalaryService>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<IContributionService, ContributionService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
