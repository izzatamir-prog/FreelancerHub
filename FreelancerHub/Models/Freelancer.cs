using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerHub.Models
{
    public class Freelancer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string PhoneNo { get; set; }
        public string Skillsets { get; set; }
        public string Hobbies { get; set; }
    }
}
