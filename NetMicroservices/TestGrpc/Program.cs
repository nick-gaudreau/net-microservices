using TestGrpc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


// app.MapControllers();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGrpcService<GrpcPlatformService>();

    // just an endpoint to return the contract - optional
    // https://localhost:7206/protos/platform
    endpoints.MapGet("/protos/platform", async ctx =>
    {
        await ctx.Response.WriteAsync(System.IO.File.ReadAllText("platforms.proto"));
    });
});

app.Run();
