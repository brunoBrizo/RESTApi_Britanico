using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace britanicoCore.Modelo
{
    public class Empresa : BaseModel
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string RUT { get; set; }

        [Required, MaxLength(100)]
        public string RazonSocial { get; set; }

        [Required, MaxLength(100)]
        public string NombreFantasia { get; set; }

        [Required, MaxLength(100)]
        public string Direccion { get; set; }

        [Required, MaxLength(100)]
        public string Departamento { get; set; }
    }
}
