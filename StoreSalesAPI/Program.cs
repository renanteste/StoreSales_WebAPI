using Microsoft.EntityFrameworkCore;
using StoreSalesAPI.Data;
using StoreSalesAPI.Services.Branchess;
using StoreSalesAPI.Services.Customers;
using StoreSalesAPI.Services.Products;
using StoreSalesAPI.Services.SaleItems;
using StoreSalesAPI.Services.Saless;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configurar a conexão com o banco de dados (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 Adicionar serviços da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<ISalesInterface, SalesService>();
builder.Services.AddScoped<ICustomerInterface, CustomerService>();
builder.Services.AddScoped<IBranchInterface, BranchService>();
builder.Services.AddScoped<ISaleItemInterface, SaleItemService>();





// 🔹 Habilitar CORS (se necessário)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// 🔹 Configurar o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll"); // Ativar CORS

app.MapControllers();

app.Run();
