// Import the namespace for this project
namespace CourseEnrollmentApp.Models
{
    // Course class represents a course in our application
    public class Course
    {
        // Stores the unique ID of the course
        public int CourseId { get; set; }

        // Stores the name of the course
        public string CourseName { get; set; }

        // Stores the course duration in months
        public int Duration { get; set; }

        // Stores the original course fees
        public double Fees { get; set; }

        // Stores the discount percentage
        public double DiscountPercentage { get; set; }
    }
}