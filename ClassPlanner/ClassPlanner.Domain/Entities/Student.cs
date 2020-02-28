using System;

namespace ClassPlanner.Domain.Entities
{
    public class Student : BaseEntity
    {
        protected Student()
        {
        }

        public Student(string name, bool privateStudent, string address, string contact, string cpf)
        {
            Name = name;
            CPF = cpf;
            Address = address;
            Contact = contact;
            PrivateStudent = privateStudent;
            Active = true;
            CreationDate = DateTime.Now;

        }

        public void Update(string name, bool privateStudent, string address, string contact, string cpf)
        {
            Name = name;
            CPF = cpf;
            Address = address;
            Contact = contact;
            PrivateStudent = privateStudent;
            Active = true;
            AlterationDate = DateTime.Now;
        }

        public string Name { get; protected set; }
        public string CPF { get; protected set; }
        public string Address { get; protected set; }
        public string Contact { get; protected set; }
        public bool PrivateStudent { get; protected set; }
        public DateTime AlterationDate { get; protected set; }
        public DateTime CreationDate { get; protected set; }
    }
}