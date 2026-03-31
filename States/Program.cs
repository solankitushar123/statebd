using Microsoft.EntityFrameworkCore;
using State.Endpoints;
using State.Persistence;
using State.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));
});

builder.Services.AddScoped<StateService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactCors", policy =>
    {
        policy.WithOrigins("http://localhost:5174")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


WebApplication app = builder.Build();


//  ENABLE CORS

app.UseCors("ReactCors");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.MapStateEndpoints();



RouteGroupBuilder apiGroup = app.MapGroup("api");
apiGroup.MapStateEndpoints();
app.Run();