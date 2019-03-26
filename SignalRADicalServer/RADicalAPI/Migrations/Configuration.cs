namespace RADicalAPI.Migrations
{
    using Microsoft.AspNet.Identity;
    using RADicalAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            PasswordHasher ps = new PasswordHasher();

            // NOTE: Currently, we cannot sign in as these test players on the Azure hosted version of this web app.
            // Registering as a new user and logging in as that user (or any other created user) will work however.

            // Here we'll seed two sample players for our game.
            context.Users.AddOrUpdate(u => u.UserName,
               new ApplicationUser
               {
                   UserName = "TestPlayer1",
                   Email = "testp1@mail.itsligo.ie",
                   SecurityStamp = Guid.NewGuid().ToString(),
                   PasswordHash = ps.HashPassword("City-Hunter93"),
                   HighScore = 12
               },

                new ApplicationUser
                {
                    UserName = "TestPlayer2",
                    Email = "testp2@mail.itsligo.ie",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("Jo-Jo85"),
                    HighScore = 15
                }
               );
            context.SaveChanges();
        }
    }
}