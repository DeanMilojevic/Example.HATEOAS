using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Example.Core.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
