using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Mapping
{
    public class AgendamentoMap : IEntityTypeConfiguration<AgendamentoMOD>
    {
        public void Configure(EntityTypeBuilder<AgendamentoMOD> builder)
        {
            builder.HasOne(p => p.Paciente).WithMany().HasForeignKey(x => x.Paciente.Id);
        }
    }
}
