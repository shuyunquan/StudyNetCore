using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test;

namespace StudyNetCore.Service
{
    public class StudentService : IStudentService
    {
        public void addStudent(Student student)
        {
            Console.WriteLine("我添加了一个Student");
        }

        public Student getStudent(int Id)
        {
            return new Student();
        }
    }
}
