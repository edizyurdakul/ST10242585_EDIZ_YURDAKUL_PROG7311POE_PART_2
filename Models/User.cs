﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime StartDate { get; set; }
        public int RoleId { get; set; }
    }
}