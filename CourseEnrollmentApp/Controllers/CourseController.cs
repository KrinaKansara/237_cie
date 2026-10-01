// Import MVC functionality
using Microsoft.AspNetCore.Mvc;

// Import the Course model
using CourseEnrollmentApp.Models;

// Import extension methods
using CourseEnrollmentApp.Extensions;

// Controller namespace
namespace CourseEnrollmentApp.Controllers
{
    // Controller for course-related operations
    public class CourseController : Controller
    {
        // Display all available courses
        public IActionResult Index()
        {
            // Create course list
            List<Course> courses = GetCourses();

            // Send courses to the Index view
            return View(courses);
        }


        // Display details of a selected course
        // CourseId is received through the Query String
        // Example: /Course/Details?CourseId=1
        public IActionResult Details(int CourseId)
        {
            // Get all courses
            List<Course> courses = GetCourses();

            // Find the course with the requested ID
            Course? course = courses.FirstOrDefault(c => c.CourseId == CourseId);

            // If course does not exist, return 404
            if (course == null)
            {
                return NotFound();
            }

            // Send selected course to Details view
            return View(course);
        }


        // Display the enrollment form
        // CourseId is passed to this action
        public IActionResult Enroll(int CourseId)
        {
            // Get all courses
            List<Course> courses = GetCourses();

            // Find the selected course
            Course? course = courses.FirstOrDefault(c => c.CourseId == CourseId);

            // If course does not exist, return 404
            if (course == null)
            {
                return NotFound();
            }

            // Send course information to enrollment page
            return View(course);
        }


        // Handle the submitted enrollment form
        [HttpPost]
        public IActionResult Enroll(int CourseId, string StudentName)
        {
            // Store student name in a Cookie
            CookieOptions options = new CookieOptions();

            // Cookie will be available for 1 day
            options.Expires = DateTime.Now.AddDays(1);

            // Create the StudentName cookie
            Response.Cookies.Append("StudentName", StudentName, options);

            // Store the selected CourseId in Session
            HttpContext.Session.SetInt32("SelectedCourse", CourseId);

            // Display enrollment confirmation
            ViewBag.StudentName = StudentName;
            ViewBag.CourseId = CourseId;

            // Return the enrollment confirmation page
            return View("EnrollmentSuccess");
        }


        // Method used to create the course list
        private List<Course> GetCourses()
        {
            // Return sample course data
            return new List<Course>
            {
                // Course 1
                new Course
                {
                    CourseId = 1,
                    CourseName = "ASP.NET Core MVC",
                    Duration = 3,
                    Fees = 30000,
                    DiscountPercentage = 10
                },

                // Course 2
                new Course
                {
                    CourseId = 2,
                    CourseName = "Python for Data Science",
                    Duration = 4,
                    Fees = 40000,
                    DiscountPercentage = 15
                },

                // Course 3
                new Course
                {
                    CourseId = 3,
                    CourseName = "Machine Learning",
                    Duration = 6,
                    Fees = 50000,
                    DiscountPercentage = 20
                }
            };
        }
    }
}