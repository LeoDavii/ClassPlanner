using ClassPlanner.Domain.Enums;
using System;

namespace ClassPlanner.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User()
        {
        }

        public User(string name, string emailLogin,
                    string password, int role)
        {
            Name = name;
            EmailLogin = emailLogin;
            Password = password;
            Role = (Roles)role;
            CreationDate = DateTime.Today;
            Active = true;
        }

        public void Update(string name, string emailLogin,
                   string password, int role, bool active)
        {
            Name = name;
            EmailLogin = emailLogin;
            Password = password;
            Role = (Roles)role;
            AlterationDate = DateTime.Today;
            Active = active;
        }

        public string Name{ get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public string EmailLogin { get; protected set; }
        public Roles Role { get; protected set; }
        public DateTime AlterationDate { get; protected set; }
        public DateTime CreationDate { get; protected set; }
    }
}
