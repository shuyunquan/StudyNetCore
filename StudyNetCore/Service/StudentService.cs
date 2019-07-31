using StudyNetCore.Models;
using System;
using System.Collections.Generic;

namespace StudyNetCore.Service
{
    public class StudentService : IStudentService
    {
        public void addStudent(Student student)
        {
            Console.WriteLine("我添加了一个Student");
        }

        public Student getStudent(int id)
        {
            return new Student() {
                FirstName = "许嵩",
                LastName = "甜甜",
                BirthDay = new DateTime(1854,5,14)
            }; 
        }

        public List<Student> getStudentList()
        {
            return new List<Student>()
            {
                new Student()
                {
                    FirstName = "许嵩",
                    LastName = "甜甜",
                    BirthDay = new DateTime(1854, 5, 14)
                },
                new Student()
                {
                    FirstName = "蜀云泉",
                    LastName = "杳杳",
                    BirthDay = new DateTime(1954, 5, 14)
                }
            };
        }
    }
}
