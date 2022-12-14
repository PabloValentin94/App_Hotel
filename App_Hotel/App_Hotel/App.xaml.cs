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

            }

        };

        public List<Model.dados_login> lista_usuarios_cadastrados = new List<Model.dados_login>()
        {

            new Model.dados_login()
            {

                usuario = "PABLO VALENTIN",

                senha = "211066"

            },

            new Model.dados_login()
            {

                usuario = "TIAGO ANTONIO DA SILVA",

                senha = "tiagotas"

            },

            new Model.dados_login()
            {

                usuario = "MARCOS ROGERIO PAGAGNOTTI",

                senha = "marcao"

            },

            new Model.dados_login()
            {

                usuario = "VISITANTE",

                senha = "1234"

            }

        };

        public App()
        {

            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");

            // Usado para testes:

            //MainPage = new NavigationPage(new View.Contratacao_Hospedagem());

            if (Properties.ContainsKey("logado"))
            {

                MainPage = new NavigationPage(new View.Contratacao_Hospedagem());

            }

            else
            {

                MainPage = new NavigationPage(new View.Login());

            }

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
