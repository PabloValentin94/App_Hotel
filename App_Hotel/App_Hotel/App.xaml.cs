using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.Generic; // Biblioteca que possui o elemento List.
using System.Globalization; // Biblioteca que possui o método CultureInfo.
using System.Threading; // Biblioteca que possui o elemento Thread.

namespace App_Hotel
{

    public partial class App : Application
    {

        public List<Model.Suites> tipos_de_suite = new List<Model.Suites>()
        {

            new Model.Suites()
            {

                descricao = "Suite Cellbit",

                valor_diaria_adultos = 1000.00,

                valor_diaria_criancas = 500.00

            },

            new Model.Suites()
            {

                descricao = "Suite Super Luxo",

                valor_diaria_adultos = 200.00,

                valor_diaria_criancas = 100.00

            },

            new Model.Suites()
            {

                descricao = "Suite Luxo",

                valor_diaria_adultos = 140.00,

                valor_diaria_criancas = 70.00

            },

            new Model.Suites()
            {

                descricao = "Suite Comum",

                valor_diaria_adultos = 80.00,

                valor_diaria_criancas = 40.00

            },

            new Model.Suites()
            {

                descricao = "Quarto da Limpeza",

                valor_diaria_adultos = 20.00,

                valor_diaria_criancas = 10.00

            }

        };

        public App()
        {

            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");

            MainPage = new NavigationPage(new View.Contratacao_Hospedagem());

        }

        protected override void OnStart()
        {



        }

        protected override void OnSleep()
        {



        }

        protected override void OnResume()
        {



        }

    }

}
