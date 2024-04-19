namespace AspNetCore_MVC.ViewModels.Courses;

public class CourseIndexViewModel
{
    public IEnumerable<CourseViewModel> Courses { get; set; } = [];
}
