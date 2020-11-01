using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTech.Gton.Infra.Data.Models;
using System;

namespace SafeTech.Gton.Infra.Data.Mappings
{
    public class OrganMapping : IEntityTypeConfiguration<Organ>
    {
        public void Configure(EntityTypeBuilder<Organ> builder)
        {
            builder.ToTable("Orgao");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("idOrgao");

            builder
                .HasOne(x => x.OrganType)
                .WithMany(x => x.OrganCollection)
                .HasForeignKey(x => x.OrganTypeId);

            builder
                .HasOne(x => x.GiverPatient)
                .WithMany(x => x.DonatedOrgan)
                .HasForeignKey(x => x.GiverPatientId);

            builder
               .HasOne(x => x.ReceiverPatient)
               .WithMany(x => x.ReceivedOrgan)
               .HasForeignKey(x => x.ReceiverPatientId);
        }
    }
}
