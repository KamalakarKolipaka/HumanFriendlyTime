using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoItems.Core.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        [StringLength(100)]
        public string ItemDescription { get; set; } 

        [Required]
        public ItemStatus ItemStatus { get; set; }

        [Required]
        public DateTime ItemCreatedDate { get; set; }
    }

    public enum ItemStatus
    {
        Incomplete,
        Complete
    }
}
