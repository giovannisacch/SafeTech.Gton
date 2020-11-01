using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Mappings
{
    public class OrganTypeMapping : IEntityTypeConfiguration<OrganType>
    {
        public void Configure(EntityTypeBuilder<OrganType> builder)
        {
            builder.ToTable("TipoOrgao");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("idTipoOrgao");
        }
    }
}
