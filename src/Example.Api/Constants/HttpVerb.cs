namespace Example.Api.Constants
{
    /// <summary>
    /// HTTP defines a set of request methods to indicate the desired action to be performed for a given resource.
    /// Although they can also be nouns, these request methods are sometimes referred to as HTTP verbs.
    /// Each of them implements a different semantic, but some common features are shared by a group of them: e.g. a request method can be safe, idempotent, or cacheable.
    /// 
    /// <see cref="https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods"/>
    /// </summary>
    public static class HttpVerb
    {
        /// <summary>
        /// The GET method requests a representation of the specified resource. Requests using GET should only retrieve data.
        /// </summary>
        public const string Get = "GET";

        /// <summary>
        /// The HEAD method asks for a response identical to that of a GET request, but without the response body.
        /// </summary>
        public const string Head = "HEAD";

        /// <summary>
        /// The POST method is used to submit an entity to the specified resource, often causing a change in state or side effects on the server.
        /// </summary>
        public const string Post = "POST";

        /// <summary>
        /// The PUT method replaces all current representations of the target resource with the request payload.
        /// </summary>
        public const string Put = "PUT";

        /// <summary>
        /// The DELETE method deletes the specified resource.
        /// </summary>
        public const string Delete = "DELETE";

        /// <summary>
        /// The CONNECT method establishes a tunnel to the server identified by the target resource.
        /// </summary>
        public const string Connect = "CONNECT";

        /// <summary>
        /// The OPTIONS method is used to describe the communication options for the target resource.
        /// </summary>
        public const string Options = "OPTIONS";

        /// <summary>
        /// The TRACE method performs a message loop-back test along the path to the target resource.
        /// </summary>
        public const string Trace = "TRACE";

        /// <summary>
        /// The PATCH method is used to apply partial modifications to a resource.
        /// </summary>
        public const string Patch = "PATCH";
    }
}
