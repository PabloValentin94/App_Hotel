using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Hotel.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Login : ContentPage
    {

        App PropriedadesApp;

        public Login()
        {

            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;

        }

        private void btn_entrar_Clicked(object sender, EventArgs e)
        {

            if(PropriedadesApp.lista_usuarios_cadastrados.Any(i => i.usuario == txt_usuario.Text &&
               i.senha == txt_senha.Text))
            {

                App.Current.MainPage = new View.Contratacao_Hospedagem();

            }

        }
    }

}