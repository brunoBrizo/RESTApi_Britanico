using britanicoCore.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace britanicoCore.Modelo
{
    public class Security : BaseModel
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string User { get; set; }
        [Required, MaxLength(100)]
        public string UserName { get; set; }
        [Required, MaxLength(300)]
        public string Password { get; set; }
        [Required]
        public RolType Role { get; set; }
    }
}
