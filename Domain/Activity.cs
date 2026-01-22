using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Activity
    {
        public string ActivityId { get; set; } = Guid.NewGuid().ToString();
        public required string Title { get; set; }
        public DateTime Date { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public bool IsCancelled { get; set; }

        public required string City { get; set; } 
        public required string Place { get; set; }
        public  double Latitude { get; set; }
        public  double Longitude { get; set; }

        //Foreign key
        public required string CreatedByUserId { get; set; }

        //Navigation property
        public User? CreatedBy {  get; set; }
    }
}
