using App_Tareas.Util;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


// SqlConnectionStringBuilder connectionStringBuilder = new();

// connectionStringBuilder.ConnectionString = "Data Source=VASIEPC\\SQLEXPRESS; Initial Catalog=TareasDb;Trusted_Connection=True;Integrated Security=True; TrustServerCertificate=True";
// connectionStringBuilder.DataSource = ".";
// connectionStringBuilder.InitialCatalog = "TareasDb";
// connectionStringBuilder.IntegratedSecurity = true;

// var cs = connectionStringBuilder.ConnectionString;




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var mySqlConnectionString = new SqlServerConfiguration(builder.Configuration.GetConnectionString("cnTareas")!);


//builder.Services.AddSingleton(mySqlConnectionString);

builder.Services.AddSingleton(new SqlConnection(builder.Configuration.GetConnectionString("cnTareas")!));

builder.Services.AddScoped<IDBDatos, DBDatos>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors();

app.MapControllers();



app.Run();
