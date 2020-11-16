using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC_CRUD.Models
{
    public class Comment
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Contents { get; set; }
        [Required]
        [MaxLength(64)]
        public string Author { get; set; }
        [Required]
        public DateTime? DateOfCreation { get; set; }
    }
}
