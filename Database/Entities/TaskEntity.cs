using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Api.Database.Entities
{
    [Table("tasks")]
    public class TaskEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [Column("title")]
        public String Title { get; set; }

        [Required]
        [Column("description")]
        public String Description { get; set; }

    }
}
