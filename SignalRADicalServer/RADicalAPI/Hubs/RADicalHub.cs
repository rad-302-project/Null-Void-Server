using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RADicalAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace RADicalAPI.Hubs
{
    [HubName("RADicalHub")]
    public class RADicalHub : Hub
    {
        // Create a reference to the application user database.
        ApplicationDbContext appUserContext = new ApplicationDbContext();
        ApplicationUser _player1, _player2, _winningPlayer, _losingPlayer;

        PasswordHasher ps = new PasswordHasher();

        public void RegisterNewPlayer(string emailIn, string usernameIn, string pwordIn)
        {
            bool issueFound = false;            

            foreach (ApplicationUser player in appUserContext.Users)
            {
                if (player.Email == emailIn)
                {
                    Clients.Caller.ReceiveRegistrationMessage("Email Taken", emailIn); // Send an error back to the caller, since that email already has an account attached. 
                    issueFound = true;
                    break;
                }
                else if (player.UserName == usernameIn)
                {
                    Clients.Caller.ReceiveRegistrationMessage("Username Taken", usernameIn); // Send a similar error if the username's already been taken.
                    issueFound = true;
                    break;
                }
            }

            if (!issueFound)
            {
                appUserContext.Users.Add(
                 new ApplicationUser
                 {
                     Email = emailIn,
                     UserName = usernameIn,
                     PasswordHash = ps.HashPassword(pwordIn)
                 }
                 );
                appUserContext.SaveChanges();
                Clients.Caller.ReceiveRegistrationMessage("Success", usernameIn);
            }
        }

        public void PlayerLogin(string usernameIn, string pwordIn)
        {          
            ApplicationUser player = appUserContext.Users.Where(u => u.UserName == usernameIn).FirstOrDefault();

            if(player != null)
            {
                var result = ps.VerifyHashedPassword(player.PasswordHash, pwordIn);
                if (Convert.ToBoolean(result) == true)
                {
                    Clients.Caller.ReceiveLoginMessage("Password Valid", player.UserName, player.Wins, player.Losses);
                }
                else Clients.Caller.ReceiveLoginMessage("Password Invalid", player.UserName, player.Wins, player.Losses);
            }

            else Clients.Caller.ReceiveLoginMessage("Not Found", usernameIn, 0, 0);
        }

        // For now, this method assumes that this is a strictly two-player game.       
        public void UploadMatchResults(string p1Username, string p2Username, int p1Health, int p2Health)
        {
            // Find the two players who had participated.
            _player1 = DatabaseHelper.FindPlayer(p1Username);
            _player2 = DatabaseHelper.FindPlayer(p2Username);

            // If we've found both of them in the database...
            if (_player1 != null && _player2 != null)
            {
                DeterminePlayerStatus(p1Health, p2Health);

                appUserContext.Users.FirstOrDefault(p => p.UserName == _winningPlayer.UserName).Wins++;
                appUserContext.Users.FirstOrDefault(p => p.UserName == _losingPlayer.UserName).Losses++;

                // Save the changes to the database.
                appUserContext.SaveChanges();

                // Send the results back to the game.  
                Clients.All.ReceiveResults(
                    appUserContext.Users.FirstOrDefault(p => p.UserName == _winningPlayer.UserName),
                    appUserContext.Users.FirstOrDefault(p => p.UserName == _losingPlayer.UserName));
            }
        }

        public void SendMessage(string sender, string message)
        {
            if (DatabaseHelper.FindPlayer(sender) != null)
            {
                Clients.All.ReceiveMessage(sender, message);

                #region Save message to the DB - Not in use currently.
                //DatabaseHelper.AddPlayerMessage(new Models.PlayerMessage()
                //{
                //    Username = sender,
                //    MessageSent = message,
                //    DateSent = DateTime.UtcNow
                //});
                #endregion
            }
        }

        public void SendMessageToOthers(string sender, string message)
        {
            if (DatabaseHelper.FindPlayer(sender) != null)
            {
                Clients.Others.ReceiveMessage(sender, message);
                Clients.All.ReceiveMessage(sender, message);

                #region Save message to the DB - Not in use currently.
                //DatabaseHelper.AddPlayerMessage(new Models.PlayerMessage()
                //{
                //    Username = sender,
                //    MessageSent = message,
                //    DateSent = DateTime.UtcNow
                //});
                #endregion
            }
        }

        public void Join(string username)
        {
            if (DatabaseHelper.FindPlayer(username) != null)
            {
                Clients.Others.PlayerJoined(username);
            }
        }

        public void Leave(string username)
        {
            if (DatabaseHelper.FindPlayer(username) != null)
            {
                Clients.Others.PlayerLeft(username);
            }
        }

        // This method will determine who won the match.        
        private void DeterminePlayerStatus(int p1Health, int p2Health)
        {
            if (p1Health > p2Health)
            {
                _winningPlayer = _player1;
                _losingPlayer = _player2;
            }

            else if (p2Health > p1Health)
            {
                _winningPlayer = _player2;
                _losingPlayer = _player1;
            }
        }
    }
}