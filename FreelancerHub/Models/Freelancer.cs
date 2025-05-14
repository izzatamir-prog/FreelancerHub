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
        public ICollection<Skillset> Skillsets { get; set; }
        public ICollection<Hobby> Hobbies { get; set; }
        public bool IsArchive { get; set; }
    }
}
