namespace Example.Api.Models
{
    public class CoursesRequest
    {
        public string SearchQuery { get; set; }
        public int Page { get; set; } = 1;
        public int HowMany { get; set; } = 10;
    }
}
