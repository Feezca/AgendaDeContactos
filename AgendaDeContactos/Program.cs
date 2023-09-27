using AgendaDeContactos.Proyecto.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContactos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AgendaContext>(dbContextOptions => dbContextOptions.UseSqlite(
            builder.Configuration["ConnectionStrings:AgendaAPIDBConnectionString"]));
            //aca va a ir la url de la base de datos,
            //esta configuracion generalmente va en un archivo aparte,en este caso esta en el appsettings.json,
            //que es una instancia local, se pueden generar diferentes instancias.

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
        }
    }
}