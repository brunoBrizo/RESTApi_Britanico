using britanicoCore.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace britanicoDb.Data.Configurations
{
    public class NumeradorConfiguration : IEntityTypeConfiguration<Numerador>
    {
        public void Configure(EntityTypeBuilder<Numerador> builder)
        {
            builder.ToTable("Numerador");
            builder.HasKey(e => e.Id).HasName("PK_Numerador");

            builder.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn(1, 1);

            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(e => e.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(e => e.EmpId)
                .HasColumnName("EmpId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Empresa)
                .WithMany()
                .HasForeignKey(e => e.EmpId)
                .HasConstraintName("FK_Numerador_EmpId");
        }
    }
}
