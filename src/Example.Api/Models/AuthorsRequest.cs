namespace Example.Api.Models
{
    public class AuthorsRequest
    {
        public int Page { get; set; } = 1;
        public int HowMany { get; set; } = 10;
    }
}
