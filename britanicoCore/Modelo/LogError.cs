using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace britanicoCore.Modelo
{
    public class LogError : BaseModel
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        [MaxLength(200)]
        public string StackTrace { get; set; }

        [Required]
        [MaxLength]
        public string Msg { get; set; }

        [Required]
        public int EmpId { get; set; }


        [ForeignKey("EmpId")]
        public virtual Empresa Empresa { get; set; }

    }
}
