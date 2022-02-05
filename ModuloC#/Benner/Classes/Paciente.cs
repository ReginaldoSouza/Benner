using System;
using System.Collections.Generic;
using System.Text;

namespace Benner.Classes
{
    public class Paciente
    {
        public string Nome { get; set; } = "";
        public DateTime DataNascimento { get; set; } 
        public int Idade { get; set; } = 0;
        public string CPF { get; set; }
        public List<Exames> ExamesRealizados { get; set; } = new List<Exames>();

        public Paciente()
        {

        }

        public Paciente(string nome, DateTime dataNascimento, int idade, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = idade;
            CPF = cpf;
           
        }


        public void AdicionarExames( Exames exames)
        {
            ExamesRealizados.Add(exames);
        }

        public void RemoverExames(Exames exames)
        {
            ExamesRealizados.Remove(exames);
        }
        

        public  double TotalizarExames()
        {
            double ValorExame = 0;
            foreach (Exames exame in ExamesRealizados)
                ValorExame += exame.CalcularValorPagar();

            return ValorExame;
        }

        
    }
}
