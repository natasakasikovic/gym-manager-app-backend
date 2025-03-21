﻿using GymManagerApp.Domain.Common;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities.User
{
    public abstract class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
