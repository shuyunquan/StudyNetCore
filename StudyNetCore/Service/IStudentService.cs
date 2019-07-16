using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test;

namespace StudyNetCore.Service
{
    public interface IStudentService
    { 
        Student getStudent(int Id);
        void addStudent(Student student);
    }
}
