using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Models
{
    public sealed class AgendamentoMOD
    {

        public AgendamentoMOD()
        {

            Medico = new MedicoMOD();
            Paciente = new PacienteMOD();
        }

        public Int32 Id { get; set; }

        public DateTime DtAgendamento { get; set; }

        public MedicoMOD Medico { get; set; }

        public PacienteMOD Paciente { get; set; }
    }
}
