using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FreelancerHub.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Foreign key
        public int F_Id { get; set; } //freelancer id

        [JsonIgnore]
        public Freelancer Freelancer { get; set; }
    }
}
