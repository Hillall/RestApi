using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using todoApp.Models.Base;
namespace todoApp.Models
{
    public class User : EntityBase
    {
        [StringLength (50)]
        public string FirstName { get; set; }
        [StringLength (50)]
        public string LastName { get; set; }
        public List<TodoTask> Tasks { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
