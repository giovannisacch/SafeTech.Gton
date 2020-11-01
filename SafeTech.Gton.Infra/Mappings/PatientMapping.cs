using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Mappings
{
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Paciente");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("idPaciente");
        }
    }
}
