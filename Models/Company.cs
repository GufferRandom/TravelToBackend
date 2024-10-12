﻿using System.ComponentModel.DataAnnotations;

namespace TravelToBackend.Models
{
    public class Company
    {
        [Key]
        public int Company_Id { get; set; }
        public string? Name { get; set; }
        public string? description { get; set; }
        public string? owner { get; set; }
        public string? img_name { get; set; }

        public ICollection<Turebi> Turebi { get; set; }

    }
}