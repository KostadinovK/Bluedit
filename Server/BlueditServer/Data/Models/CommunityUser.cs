using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueditServer.Data.Models
{
    public class CommunityUser
    {
        public string CommunityId { get; set; }

        public Community Community { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public DateTime JoinedOn { get; set; }
    }
}
