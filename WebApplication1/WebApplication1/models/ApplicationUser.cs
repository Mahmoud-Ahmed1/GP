﻿using Microsoft.AspNetCore.Identity;

namespace WebApplication1.models
{
    public class ApplicationUser : IdentityUser

    {
        public string fname { get; set; }
        public string lname { get; set; }
        public DateTime Birthdate { get; set; }


        public string? BIO { get; set; }
        public DateTime barthday { get; set; }
        public string? ginder { get; set; }



    }
}
