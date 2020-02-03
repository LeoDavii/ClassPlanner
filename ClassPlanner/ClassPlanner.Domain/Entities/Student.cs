namespace ClassPlanner.Domain.Entities
{
    public class Student : BaseEntity
    {
        protected Student()
        {
        }

        public Student(string name)
        {
            Name = name;
            Active = true;
        }

        public void Update(string name)
        {
            Name = name;
            Active = true;
        }

        public string Name { get; protected set; }
    }
}
