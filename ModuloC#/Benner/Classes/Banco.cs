using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Benner.Classes
{
    public class Banco
    {

        public void Inserir(Paciente paciente)
        {
            StreamWriter sw = new StreamWriter("d:\\benner\\moduloc#\\benner\\arquivos\\Exames.txt");

            var pacie = paciente.GetType().GetProperties();
 

            foreach (var p in pacie)
            {
                if (p.Name.ToUpper().Contains("EXAMES")) continue;
                sw.WriteLine(p.Name + ": " + p.GetValue(paciente, null));
            }

            foreach (var e in paciente.ExamesRealizados)
            {
                sw.WriteLine("Valor: " + e.Valor.ToString("N2"));
                sw.WriteLine("Data realização: " + e.DataRealizacao);
                sw.WriteLine("Exame:  " + e.Exame);
            }

            sw.Close();
        }

    }
}
