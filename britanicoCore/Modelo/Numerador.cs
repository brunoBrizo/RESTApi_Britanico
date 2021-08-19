using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace britanicoCore.Modelo
{
    public class Numerador : BaseModel
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int EmpId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Nombre { get; set; }

        [Required]
        public decimal Valor { get; set; }


        [ForeignKey("EmpId")]
        public virtual Empresa Empresa { get; set; }
    }
}
