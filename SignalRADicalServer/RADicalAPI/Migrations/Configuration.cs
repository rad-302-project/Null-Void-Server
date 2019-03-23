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

            // Here we'll seed two sample players for our game.
            context.Users.AddOrUpdate(u => u.UserName,
               new ApplicationUser
               {
                   UserName = "TestPlayer1",
                   Email = "testp1@mail.itsligo.ie",
                   PasswordHash = ps.HashPassword("Pau-Pau93")
               },

                new ApplicationUser
                {
                    UserName = "TestPlayer2",
                    Email = "testp2@mail.itsligo.ie",
                    PasswordHash = ps.HashPassword("Jo-Jo85")
                }
               );
            context.SaveChanges();
        }
    }
}