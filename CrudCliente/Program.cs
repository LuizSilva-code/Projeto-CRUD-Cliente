using CrudCliente.Applications.Facade.Cliente.Cadastrar;
using CrudCliente.Applications.Mappings;
using CrudCliente.Applications.Strategy;
using CrudCliente.Applications.Strategy.Validators;
using CrudCliente.Infra.Config;
using CrudCliente.Infra.Repository.Cliente;
using CrudCliente.Infra.Repository.Cliente.Cartao;
using CrudCliente.Infra.Repository.Cliente.Endereco;
using CrudCliente.Infra.Repository.Cliente.Telefone;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(ClienteProfile).Assembly);
builder.Services.AddScoped<CriptografarSenhaStrategy>();
builder.Services.AddScoped<ValidarCPFStrategy>();
builder.Services.AddScoped<IClienteFacade, ClienteFacade>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICartaoRepository, CartaoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<ICartaoRepository, CartaoRepository>();
builder.Services.AddScoped<ICartaoFacade, CartaoFacade>();
builder.Services.AddScoped<IEnderecoFacade, EnderecoFacade>();
builder.Services.AddScoped<ITelefoneRepository, TelefoneRepository>();
builder.Services.AddScoped<AtribuirNumeroRankingStrategy>();
builder.Services.AddScoped<ValidarSenhaForteStrategy>();
builder.Services.AddScoped<ValidarExistenciaClienteStrategy>();
builder.Services.AddScoped<ValidarEnderecosStrategy>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseCors("AllowAll");

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
