namespace RADicalAPI.Migrations
{
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
            // Here we'll seed two sample players for our game.
            context.Users.AddOrUpdate(u => u.UserName,
               new ApplicationUser
               {
                   UserName = "TestPlayer1"
               },

                new ApplicationUser
                {
                    UserName = "TestPlayer2"
                }
               );

            context.SaveChanges();
        }
    }
}