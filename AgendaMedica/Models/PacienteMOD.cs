using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Models
{
    public class PacienteMOD
    {
        public PacienteMOD() { }

        public Int32 Id { get; set; }

        public String Nome { get; set; }

        public String Cpf { get; set; }

        public DateTime? DtNascimento { get; set; }

        public DateTime DtCadastro { get; set; }

    }
}
