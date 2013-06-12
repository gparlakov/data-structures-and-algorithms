using System;
using System.Linq;

namespace Students
{
    public class Student
    {
        public string Name { get; private set; }
        
        public Student(string name)
        {
            this.Name = name;
        }
    }
}
