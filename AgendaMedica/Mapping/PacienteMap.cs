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
    public class PacienteMap : IEntityTypeConfiguration<PacienteMOD>
    {
        void IEntityTypeConfiguration<PacienteMOD>.Configure(EntityTypeBuilder<PacienteMOD> builder)
        {
            builder.ToTable("AGM_Paciente");

            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("varchar(400)").IsRequired();
            builder.Property(p => p.DtCadastro).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Cpf).HasColumnType("varchar(14)").IsRequired();

            /**********************************************************************************************/
            //Ao criar o banco, cria o registro padrao
            builder.HasData(
                new PacienteMOD
                {
                    Id = 1,
                    Nome = "DANILO DE PAULA VIEIRA",
                    Cpf = "1234567897",
                    DtNascimento = new DateTime(2001, 7, 6)
                }
                );
        }
    }
}
