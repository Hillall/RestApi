using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using todoApp.Models.Base;
namespace todoApp.Models
{
    public class TodoTask : EntityBase
    {
        [StringLength(500)]
        public string Description { get; set; }
        public bool Complited { get; set; }       
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
