using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbapp.Models;
using dbapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dbapp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService courseService;
        private readonly IConfiguration config;

        public CourseController(CourseService courseService, IConfiguration config)
        {
            this.courseService = courseService;
            this.config = config;
        }

        public IActionResult Index()
        {
            //IEnumerable<Course> courses = courseService.GetCourses();
            IEnumerable<Course> courses = courseService.GetCourses(config.GetConnectionString("SQLConnection"));
            return View(courses);
        }
    }
}
