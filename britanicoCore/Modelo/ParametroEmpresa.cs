using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace britanicoCore.Modelo
{
    public class ParametroEmpresa : BaseModel
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Valor { get; set; }
        [Required]
        public int EmpId { get; set; }

        [ForeignKey("EmpId")]
        public virtual Empresa Empresa { get; set; }
    }
}
