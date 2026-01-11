var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: myAllowSpecificOrigins, policy =>
    {
        //Endereço do FrontEnd para a autorização
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});


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


app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
