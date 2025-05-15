    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace FreelancerHub.Models
    {
        public class Skillset
        {
            public int Id { get; set; }
            public string Name { get; set; }

            //Foreign key
            public int F_Id { get; set; } //freelancer id
            public Freelancer Freelancer { get; set; }
        }
    }
