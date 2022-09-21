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

            PropriedadesApp = (App)Application.Current;

            NavigationPage.SetHasNavigationBar(this, false);

            imgbtn_mostrar_ocultar_senha.Source = ImageSource.FromResource(
                                                  "App_Hotel.View.Images.show_password.png");

        }

        private async void btn_entrar_Clicked(object sender, EventArgs e)
        {

            try
            {

                if(txt_usuario.Text == "" || txt_senha.Text == "")
                {

                    await DisplayAlert("Erro!", "Preencha todos os campos antes de prosseguir", "OK");

                }

                else
                {

                    if (PropriedadesApp.lista_usuarios_cadastrados.Any(i => i.usuario == txt_usuario.Text &&
                        i.senha == txt_senha.Text))
                    {

                        App.Current.Properties.Add("logado", txt_usuario.Text);

                        App.Current.MainPage = new NavigationPage(new Contratacao_Hospedagem());

                    }

                    else
                    {

                        throw new Exception("Dados incorretos! Tente novamente.");

                    }

                }

            }

            catch(Exception ex)
            {

                await DisplayAlert("Erro!", ex.Message, "OK");

            }

        }

        private void imgbtn_mostrar_ocultar_senha_Clicked(object sender, EventArgs e)
        {

            if(txt_senha.IsPassword)
            {

                imgbtn_mostrar_ocultar_senha.Source = ImageSource.FromResource(
                                                      "App_Hotel.View.Images.hide_password.png");

                txt_senha.IsPassword = false;

            }

            else
            {

                imgbtn_mostrar_ocultar_senha.Source = ImageSource.FromResource(
                                                      "App_Hotel.View.Images.show_password.png");

                txt_senha.IsPassword = true;

            }

        }

    }

}