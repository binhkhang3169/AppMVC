using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Contact{
    public class Contact{
        [Key]
        public int Id{get;set;}
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required ]
        public string FullName{get;set;}
        [Required]
        [StringLength(100)]
        public string Email{get;set;}
        public DateTime DateSend{get;set;}
        public string Message{get;set;}
        [StringLength(50)]
        public string Phone{get;set;}
    }
}
