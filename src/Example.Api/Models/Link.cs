namespace Example.Api.Models
{
    public class Link
    {
        public Link(string method, string rel, string href)
        {
            Method = method;
            Rel = rel;
            Href = href;
        }

        public string Method { get; }
        public string Rel { get; }
        public string Href { get; }
    }
}
