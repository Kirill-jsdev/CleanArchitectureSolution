using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }

        //Navigation property
        public ICollection<Activity> CreatedActivities { get; set; } = [];

    }
}
