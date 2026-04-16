using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskAPI.Models
{
    [Table("TypeActivite")]
    public class TypeActivite
    {
        [Key]
        public int TypeID { get; set; }

        [Required]
        public string NomType { get; set; } = null!; // correction pour supprimer le warning
    }
}