namespace Example.Api.Models
{
    public class AuthorsRequest
    {
        public string SearchQuery { get; set; } = "";
        public int Page { get; set; } = 1;
        public int HowMany { get; set; } = 10;
        public string Fields { get; set; } = "";
    }
}
