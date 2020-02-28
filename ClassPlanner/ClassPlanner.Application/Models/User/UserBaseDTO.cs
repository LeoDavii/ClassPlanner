using ClassPlanner.Domain.Enums;
using System;

namespace ClassPlanner.Application.Models.User
{
    public class UserBaseDTO
    {
        public string Name { get; set; }
        public string EmailLogin { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime AlterationDate { get; set; }
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
