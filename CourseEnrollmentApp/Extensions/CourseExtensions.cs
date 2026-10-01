// Import the Course model
using CourseEnrollmentApp.Models;

// Namespace for extension methods
namespace CourseEnrollmentApp.Extensions
{
    // Static class is required to create an extension method
    public static class CourseExtensions
    {
        // Extension method to calculate the final fees after discount
        // "this Course course" allows us to call the method using a Course object
        public static double CalculateFinalFees(this Course course)
        {
            // Calculate the discount amount
            double discount = course.Fees * course.DiscountPercentage / 100;

            // Subtract the discount from the original fees
            // and return the final fees
            return course.Fees - discount;
        }
    }
}