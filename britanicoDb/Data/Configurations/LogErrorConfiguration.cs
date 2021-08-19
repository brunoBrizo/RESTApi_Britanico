using britanicoCore.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace britanicoDb.Data.Configurations
{
    public class LogErrorConfiguration : IEntityTypeConfiguration<LogError>
    {
        public void Configure(EntityTypeBuilder<LogError> builder)
        {
            builder.ToTable("LogError");
            builder.HasKey(l => l.Id).HasName("PK_LogError");

            builder.Property(l => l.Id).HasColumnName("LogErrorId").UseIdentityColumn(1, 1);

            builder.Property(l => l.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(l => l.StackTrace)
                .HasColumnName("StackTrace")
                .HasColumnType("varchar(200)");

            builder.Property(l => l.Msg)
                .HasColumnName("Msg")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(l => l.EmpId)
                .HasColumnName("EmpId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Empresa)
                .WithMany()
                .HasForeignKey(e => e.EmpId)
                .HasConstraintName("FK_LogError_EmpId");
            
                

        }
    }
}
