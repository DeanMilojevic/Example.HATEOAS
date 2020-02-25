using System.ComponentModel.DataAnnotations;

namespace Example.Api.Models
{
    public class CreateAuthorRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
