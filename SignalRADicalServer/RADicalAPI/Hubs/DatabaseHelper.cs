using RADicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADicalAPI.Hubs
{
    public static class DatabaseHelper
    {
        public static ApplicationDbContext CreateAppContext()
        {
            return new ApplicationDbContext();
        }

        public static ApplicationUser FindPlayer(string username)
        {
            using (var appContext = CreateAppContext())
            {
                // Find player and return the result.
                return appContext.Users.Where(u => u.UserName == username).FirstOrDefault();
            }
        }

        public static bool PlayersFound(string player1Username, string player2Username)
        {
            ApplicationUser player1, player2;

            using (var appContext = CreateAppContext())
            {
                // Find the first player.
                player1 = appContext.Users.Find(player1Username);
                // Find the second player.
                player2 = appContext.Users.Find(player2Username);

                if (player1 != null && player2 != null) return true;
                else return false;
            }
        }

        #region Player message methods. Not in use at the moment.
        //public static List<PlayerMessage> FindAllPlayerMessages(string username)
        //{
        //    using (var context = CreateAppContext())
        //    {
        //        // Find player and return the result.
        //        return context.Messages.Where(m => m.Username == username).ToList();
        //    }
        //}

        //public static void AddPlayerMessage(PlayerMessage message)
        //{
        //    if (message != null)
        //    {
        //        using (var context = CreateAppContext())
        //        {
        //            context.Messages.Add(message);
        //            context.SaveChanges();
        //        }
        //    }
        //}
        #endregion
    }
}