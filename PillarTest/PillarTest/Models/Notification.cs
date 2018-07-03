using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillarTest.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Expired { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
