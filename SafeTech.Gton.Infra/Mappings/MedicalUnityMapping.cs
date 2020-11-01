using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Mappings
{
    public class MedicalUnityMapping : IEntityTypeConfiguration<MedicalUnity>
    {
        public void Configure(EntityTypeBuilder<MedicalUnity> builder)
        {
            builder.ToTable("Unidade");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("idUnidade");
            builder
                .HasOne(x => x.Address)
                .WithOne(x => x.MedicalUnity)
                .HasForeignKey<MedicalUnity>(x => x.AddressId);
        }
    }
}
