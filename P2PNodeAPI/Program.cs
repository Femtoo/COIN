
using P2PNodeServer;
using System;

namespace P2PNodeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Sending to {args[0]}");
            P2PInit.InitP2PServer();
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IP2PClient, P2PClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/hello/{nu}", async (string nu, HttpContext httpContext, IP2PClient p2pclient) =>
            {
                await p2pclient.ConnectToPeer(args[0], 5000, $"Hejka tu req {nu}");
                return "Hello World";
            })
            .WithName("HelloWorld")
            .WithOpenApi();

            app.Run();
        }
    }
}
