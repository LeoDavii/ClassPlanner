using System;

namespace ClassPlanner.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        protected Teacher()
        {
        }

        public Teacher(string name, string cpf)
        {
            Name = name;
            CPF = cpf;
            Active = true;
            CreationDate = DateTime.Now;
        }

        public void Update (string name, string cpf, bool active)
        {
            Name = name;
            CPF = cpf;
            Active = active;
            AlterationDate = DateTime.Now;
        }

        public string Name { get; protected set; }
        public string CPF { get; protected set; }
        public DateTime AlterationDate { get; protected set; }
        public DateTime CreationDate { get; protected set; }
    }
}
