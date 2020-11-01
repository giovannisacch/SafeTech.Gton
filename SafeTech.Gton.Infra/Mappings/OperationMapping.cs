using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Mappings
{
    public class OperationMapping : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable("Operacao");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("idOperacao");

            builder.Ignore(x => x.AmbulanceId);

            builder
                .HasOne(x => x.SourceUnity)
                .WithMany(x => x.OperationSourceCollection)
                .HasForeignKey(x => x.SourceUnityId);

            builder
                .HasOne(x => x.TargetUnity)
                .WithMany(x => x.OperationTargetCollection)
                .HasForeignKey(x => x.TargetUnityId);

            builder
                .HasOne(x => x.Organ)
                .WithOne(x => x.Operation)
                .HasForeignKey<Operation>(x => x.OrganId);

        }
    }
}
