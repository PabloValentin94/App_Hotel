using System;
using System.Collections.Generic;
using System.Text;

//using System.Transactions;

namespace App_Hotel.Model
{

    public class Hospedagem
    {

        // Variáveis da Classe:

        public Suites quarto { get; set; }

        public int qnt_adultos { get; set; }

        public int qnt_criancas { get; set; }

        public int qnt_dias { get; set; }

        public DateTime data_checkin { get; set; }

        public DateTime data_checkout { get; set; }

        public double valor_total { get; set; }

        // Métodos da Classe:

        public static int Tempo_Estadia(DateTime checkin, DateTime checkout)
        {

            int total_dias = checkout.Subtract(checkin).Days;

            return total_dias;

        }

        public double Valor_Estadia()
        {

            double valor_adultos = (qnt_adultos * quarto.valor_diaria_adultos) * qnt_dias;

            double valor_criancas = (qnt_criancas * quarto.valor_diaria_criancas) * qnt_dias;

            double valor_total_hospedagem = valor_adultos + valor_criancas;

            return valor_total_hospedagem;

        }

    }

}
