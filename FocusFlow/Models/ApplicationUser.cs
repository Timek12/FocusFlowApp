﻿using Microsoft.AspNetCore.Identity;

namespace FocusFlow.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
