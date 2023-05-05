﻿using Microsoft.AspNetCore.Identity;

namespace MicroForum.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Rating { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime MemberSince { get; set; }
        public bool isActive { get; set; }
    }
}