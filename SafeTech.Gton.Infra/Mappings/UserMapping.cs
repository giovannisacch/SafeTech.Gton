using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("idusuario");

            builder
                .HasOne(x => x.MedicalUnity)
                .WithMany(x => x.UserCollection)
                .HasForeignKey(x => x.MedicalUnityId);

            builder.Property(x => x.ImageByteBase).HasColumnType("blob");

        }
    }
}
