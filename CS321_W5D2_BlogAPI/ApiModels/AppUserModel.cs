﻿using System;
namespace CS321_W5D2_BlogAPI.ApiModels
{
    public class AppUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string FullName { get { return FirstName + " " + LastName; } }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
