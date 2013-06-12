using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Students
{
    class Program
    {
        const string StudentsFile = "..\\..\\students.txt";

        static void Main()
        {
            var coursesAndStudents = GenerateStudentsDataStructure();

            var coursesStudents = new StringBuilder();
            foreach (var course in coursesAndStudents)
            {
                coursesStudents.AppendLine(course.Key + " : " + ReadStudentsInCourse(course));
            }

            Console.WriteLine(coursesStudents);
        }

        private static string ReadStudentsInCourse(KeyValuePair<string, ICollection<Student>> course)
        {
            StringBuilder students = new StringBuilder();
            foreach (var stud in course.Value)
            {
                students.AppendFormat("{0}; ", stud.Name);
            }

            return students.ToString();
        }

        private static OrderedMultiDictionary<string, Student> GenerateStudentsDataStructure()
        {
            var coursesAndStudents = new OrderedMultiDictionary<string, Student>(true, (x,y)=>x.CompareTo(y) , (x,y) => x.Name.CompareTo(y.Name));
            var content = ReadFile(StudentsFile);

            foreach (var line in content)
            {
                var firstLastCours = line.Split(new char[]{ '|' }, StringSplitOptions.RemoveEmptyEntries);

                var student = GetStudentFromInput(firstLastCours);

                var course = firstLastCours[2].Trim();

                coursesAndStudents.Add(course, student);
            }

            return coursesAndStudents;
        }
  
        private static Student GetStudentFromInput(string[] firstLastCours)
        {
            var firstName = firstLastCours[0].Trim();
            var lastName = firstLastCours[1].Trim();

            var student = new Student(firstName + " " + lastName);
            return student;
        }

        private static string[] ReadFile(string file)
        {
            var reader = new StreamReader(file);
            string content = null;
            using (reader)
            {
                content = reader.ReadToEnd();
            }

            var contentLines = content.Split(new char[] {'\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return contentLines;
        }
    }
}
