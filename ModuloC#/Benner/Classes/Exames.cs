using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Benner.Classes
{
    public class Exames
    {
        [DllImport(@"CoParticipacao.dll")]
        public static extern Double Calcular([MarshalAs(UnmanagedType.R8)] Double Valor);

        public Double Valor { get; set; }
        public string Exame { get; set; }
        public DateTime DataRealizacao { get; set; }

        public Exames()
        {

        }

        public Exames( double valor, string exame, DateTime datarealizacao)
        {
            Exame = exame;
            Valor = valor;
            DataRealizacao = datarealizacao;
        
        }

        public Double CalcularValorPagar()
        {
            return Calcular(Valor);

        }


    }
}
