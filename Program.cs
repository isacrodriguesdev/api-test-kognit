using Infra;
using Microsoft.EntityFrameworkCore;
using Route;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// factories
SecurityFactory.Create(builder);
RepositoryFactory.Create(builder);
ServiceFactory.Create(builder);
ControllerFactory.Create(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

var userRoute = new UserRoute(app);
var walletRoute = new WalletRoute(app);

userRoute.Create("/user");
userRoute.Login("/login");

walletRoute.Get("/wallet/{userId}");
walletRoute.Create("/wallet");

app.UseHttpsRedirection();
app.Run();
