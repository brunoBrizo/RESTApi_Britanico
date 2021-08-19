using britanicoCore.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace britanicoDb.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
 
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(e => e.Id).HasName("PK_Empresa");

            builder.Property(e => e.Id).HasColumnName("EmpId").UseIdentityColumn(1, 1);
            
            builder.Property(e => e.RUT)
                .HasColumnName("RUT")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(e => e.RazonSocial)
                .HasColumnName("RazonSocial")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.NombreFantasia)
                .HasColumnName("NombreFantasia")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Direccion)
                .HasColumnName("Direccion")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Departamento)
                .HasColumnName("Departamento")
                .HasColumnType("varchar(100)")
                .IsRequired();
            
        }
    }
}
