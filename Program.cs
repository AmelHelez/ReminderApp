using Microsoft.EntityFrameworkCore;
using ReminderApp.Data;
using ReminderApp.Services;

namespace ReminderApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ReminderDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("RemindersDb")));

            builder.Services.AddScoped<IReminderService, ReminderService>();
            builder.Services.AddHostedService<ReminderDeliveryService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ReminderDbContext>();
                context.Database.EnsureCreated();
            }

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
