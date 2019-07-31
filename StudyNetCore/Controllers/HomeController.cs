﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyNetCore.Models;
using StudyNetCore.Service;
using StudyNetCore.ViewModels;

namespace StudyNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentService _studentService=new StudentService();

        public IActionResult Index()
        {
            List<Student> studentList = _studentService.getStudentList();
            var vms = studentList.Select(x => new HomeIndexViewModel
            {
                Name = x.FirstName + x.LastName,
                Age = DateTime.Now.Subtract(x.BirthDay).Days / 365
            });
            return View(vms);
        }
        public string data()
        {
            return "你好,许嵩";
        }
    }
}