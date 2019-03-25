using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADicalAPI.Models
{
    public class PlayerViewModel
    {
        public string UserName { get; set; }
        public int HighScore { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}