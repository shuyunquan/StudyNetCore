using StudyNetCore.Models;
using System.Collections.Generic;

namespace StudyNetCore.Service
{
    public interface IStudentService
    { 
        Student getStudent(int Id);
        void addStudent(Student student);
        List<Student> getStudentList();
    }
}
