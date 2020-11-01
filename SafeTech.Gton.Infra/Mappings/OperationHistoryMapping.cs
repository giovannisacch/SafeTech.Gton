using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTech.Gton.Infra.Data.Enums;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Mappings
{
    public class OperationHistoryMapping : IEntityTypeConfiguration<OperationHistory>
    {
        public void Configure(EntityTypeBuilder<OperationHistory> builder)
        {
            builder.ToTable("HistoricoOperacao");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("idHistoricoOperacao");

            builder
                .Property(x => x.Status)
                .HasConversion(
                    asEnum => (int)asEnum,
                    asInt => (EOperationStepStatus)asInt
                );

            builder
                .HasOne(x => x.Operation)
                .WithMany(x => x.OperationHistoryCollection)
                .HasForeignKey(x => x.OperationId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
