using britanicoCore.Enumerations;
using britanicoCore.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace britanicoDb.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Security");
            builder.HasKey(e => e.Id).HasName("PK_Security");

            builder.Property(e => e.Id).HasColumnName("IdSecurity").UseIdentityColumn(1, 1);

            builder.Property(e => e.User)
                .HasColumnName("Login")
                .HasColumnType("varchar(50)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar(100)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar(300)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Role)
                .HasColumnName("Role")
                .HasColumnType("varchar(20)")
                .HasConversion(
                    x => x.ToString(),
                    x => (RolType)Enum.Parse(typeof(RolType), x)
                )
                .IsRequired();


        }
    }
}
