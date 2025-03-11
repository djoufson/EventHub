using Event.Data;
using Event.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Event.Extensions
{
    public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                    SeedData(appContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{ex.Message}");
                    
                }
            }
        }

        return webApp;
    }

    private static void SeedData(ApplicationDbContext context)
    {
        if(!context.Events.Any())
        {
            context.Events.AddRange(
                new Eventt
                {
                    Category = "Online",
                    Description = "AI, the major break through",
                    Location = "Google Meet",
                    IsTicketed = false,
                    ImageUrl = "assets/ai.jpg",
                    SecondaryImageUrls =["assets/ai.jpg","assets/ai2.jpg"]
                },
                new Eventt
                {
                    Category = "Online",
                    Description = "Graphic design webinar",
                    Location = "Whatsapp",
                    IsTicketed = false,
                    ImageUrl = "assets/girl.jpeg",
                    SecondaryImageUrls =["assets/ai.jpg","assets/ai2.jpg"]
                },
                new Eventt
                {
                    Category = "Online",
                    Description = "Fashion stuffs and stuff",
                    Location = "Whatsapp",
                    IsTicketed = false,
                    ImageUrl = "assets/bamenda.jpeg",
                    SecondaryImageUrls =["assets/beignet.jpg","assets/service.jpeg"]
                },
                new Eventt
                {
                    Category = "Tech",
                    Description = "Backend with django",
                    Location = "UBa campus",
                    IsTicketed = false,
                    ImageUrl = "assets/conference.jpg",
                    SecondaryImageUrls =["assets/beignet.jpg","assets/tech 1.jpg"]
                }
            );
            if(!context.Users.Any())
            {
                var hasher = new PasswordHasher<AppUser>();
                var user = new AppUser{
                        Email = "admin@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        UserName = "Admin",
                        NormalizedUserName = "ADMIN",
                    };
                user.PasswordHash = hasher.HashPassword(user, "Admin1234");
                context.Users.Add(user);
            };
            context.SaveChanges();
        }
    }
}
}