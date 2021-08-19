using britanicoCore.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace britanicoDb.Data.Configurations
{
    public class ParametroEmpresaConfiguration : IEntityTypeConfiguration<ParametroEmpresa>
    {
        public void Configure(EntityTypeBuilder<ParametroEmpresa> builder)
        {
            builder.ToTable("ParametroEmpresa");
            builder.HasKey(e => e.Id).HasName("PK_ParametroEmpresa");

            builder.Property(e => e.Id).HasColumnName("IdParametro").UseIdentityColumn(1, 1);

            builder.Property(e => e.EmpId)
                .HasColumnName("EmpId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(100)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Valor)
                .HasColumnName("Valor")
                .HasColumnType("varchar(1000)")
                .IsUnicode(false)
                .IsRequired();

            builder.HasOne(e => e.Empresa)
                .WithMany()
                .HasForeignKey(e => e.EmpId)
                .HasConstraintName("FK_ParametroEmpresa_EmpId");


        }
    }
}
