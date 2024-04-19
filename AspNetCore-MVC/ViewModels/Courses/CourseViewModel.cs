namespace AspNetCore_MVC.ViewModels.Courses;

public class CourseViewModel
{
    public int Id { get; set; }
    public bool IsBestseller { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Auther { get; set; } = null!;
    public string Prise { get; set; } = null!;

    public string? DiscountPrise { get; set; }
    public string Hours { get; set; } = null!;
    public string LikeInProcent { get; set; } = null!;
    public string LiksInNumbers { get; set; } = null!;
}
